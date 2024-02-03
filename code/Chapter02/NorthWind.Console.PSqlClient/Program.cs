using System.Collections.Immutable;
using System.Data;
using System.Text.Json;
using Dapper; // to use query
using NorthWind.Console.PSqlClient; // to use Entities
using Npgsql;


ConfigureConsole();

#region Create connection

NpgsqlConnectionStringBuilder builder = new()
{
    Database = "northwind",
    // SslMode = SslMode.Require,
    Timeout = 10
};
/*
WriteLine("Connect to:");
WriteLine("  1 - PostgresSql Server on remote machine");
WriteLine();

Write("Press a key: ");

var key = ReadKey().Key;

WriteLine();
WriteLine();

switch (key)

{
    case ConsoleKey.D1 or ConsoleKey.NumPad1:
        builder.Host = "ANNALIST";
        break;

    default:
        WriteLine("No data source selected.");
        return;
}

WriteLine("Authenticate using:");
WriteLine("  1 – SQL Login, for example, sa");
WriteLine();

Write("Press a key: ");

key = ReadKey().Key;

WriteLine();
WriteLine();

if (key is ConsoleKey.D1 or ConsoleKey.NumPad1)

{
    Write("Enter your SQL Server user ID: ");
    var userId = ReadLine();
    if (string.IsNullOrWhiteSpace(userId))
    {
        WriteLine("User ID cannot be empty or null.");
        return;
    }

    builder.Username = userId;
    Write("Enter your SQL Server password: ");
    var password = ReadPassword();

    if (string.IsNullOrWhiteSpace(password))
    {
        WriteLine("Password cannot be empty or null.");
        return;
    }

    builder.Password = password;
    builder.PersistSecurityInfo = false;
}
else
{
    WriteLine("No authentication selected.");
    return;
}
*/
builder.Host = "ANNALIST";
builder.Username = "postgres";
Write("Enter your Postgresql Server password: ");
builder.Password = ReadPassword();
builder.PersistSecurityInfo = false;

await using var dataSource = NpgsqlDataSource.Create(builder.ConnectionString);
WriteLine(dataSource.ConnectionString);

WriteLine();

var connection = dataSource.CreateConnection();

connection.StateChange += Connection_StateChange;

connection.Notice += Connection_InfoMessage;

try
{
    WriteLine("Opening connection. Please wait up to {0} seconds...",
        builder.Timeout);
    WriteLine();
    await connection.OpenAsync();
    WriteLineInColor($"Postgres Server version: {connection.ServerVersion}",
        ConsoleColor.Green);
}

catch (NpgsqlException ex)
{
    WriteLineInColor($"SQL exception: {ex.Message}",
        ConsoleColor.Red);
    return;
}

#endregion


/*
WriteLineInColor("Enter a unit price: ", ConsoleColor.Magenta);

var priceText = ReadLine();
if (!decimal.TryParse(priceText, out decimal price))
{
    WriteLineInColor("You must enter a valid unit price.", ConsoleColor.Red);
    connection.Close();
    return;
}

var command = connection.CreateCommand();
command.CommandType = CommandType.Text;
command.CommandText = """
                        select
                          p."ProductID",
                          p."ProductName",
                          p."UnitPrice"
                      from
                          public.products as p
                      where p."UnitPrice" >= @minimumPrice;
                      """;

command.Parameters.AddWithValue("minimumPrice", price);

var reader = await command.ExecuteReaderAsync();

string horizontalLine = new string('-', 60);
WriteLine(horizontalLine);
WriteLine("| {0,5} | {1,-35} | {2,10} |",
    arg0: "Id", arg1: "Name", arg2: "Price");
WriteLine(horizontalLine);
var storage = ImmutableList<Product>.Empty;
while (await reader.ReadAsync())
{
    var product = new Product(await reader.GetFieldValueAsync<int>("ProductId"),
        await reader.GetFieldValueAsync<string>("ProductName"),
        await reader.GetFieldValueAsync<float>("UnitPrice"));

    WriteLine("| {0,5} | {1,-35} | {2,10:C} |",
        product.ProductId,
        product.ProductName,
        product.UnitPrice
        );
    storage = storage.Add(product);
}

WriteLine(horizontalLine);

await reader.CloseAsync();

await connection.CloseAsync();

var json = JsonSerializer.Serialize(storage);

Console.Write(json);

*/

WriteLineInColor("Using Dapper", ConsoleColor.DarkGreen);
IEnumerable<Supplier> suppliers = connection.Query<Supplier>(
    sql: """
         select "SupplierID" as "SupplierId",
                "CompanyName",
                "City",
                "Country"
         from suppliers as s
         where "Country" = @Country;
         """,
    param: new { Country = "Germany" }
    );

foreach (Supplier s in suppliers)

{
    WriteLine("{0}: {1}, {2}, {3}",
        s.SupplierId, s.CompanyName, s.City, s.Country);
}

WriteLineInColor(JsonSerializer.Serialize(suppliers),
    ConsoleColor.Green);


await connection.CloseAsync();