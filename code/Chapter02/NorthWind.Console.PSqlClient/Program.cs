
using Npgsql;


ConfigureConsole();

NpgsqlConnectionStringBuilder builder = new()
{
    Database = "NorthWind",
    // SslMode = SslMode.Require,
    Timeout = 10
};
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

await using var dataSource  = NpgsqlDataSource.Create(builder.ConnectionString);
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
    WriteLine($"Postgres Server version: {connection.ServerVersion}");
}

catch (NpgsqlException ex)
{
    WriteLineInColor($"SQL exception: {ex.Message}", 
        ConsoleColor.Red);
    return;
}
