using System.Globalization;


internal partial class Program
{
    private static void ConfigureConsole(
        string culture = "en-US",
        bool useComputerCulture = false)
    {
        OutputEncoding = System.Text.Encoding.UTF8;
        if (!useComputerCulture)
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
        }

        WriteLine($"CurrentCulture: {CultureInfo.CurrentCulture.DisplayName}");
    }

    private static void WriteLineInColor(string value,
        ConsoleColor color = ConsoleColor.White)
    {
        var previousColor = ForegroundColor;

        ForegroundColor = color;

        WriteLine(value);

        ForegroundColor = previousColor;
    }

    private static string ReadPassword()
    {
        string password = "";
        while (true)
        {
            ConsoleKeyInfo info = Console.ReadKey(true); // true per non visualizzare il carattere
            if (info.Key == ConsoleKey.Enter)
            {
                break; // Interrompe il ciclo quando viene premuto Enter
            }
            if (info.Key == ConsoleKey.Backspace)
            {
                if (password.Length > 0)
                {
                    // Rimuove l'ultimo carattere dalla password e il cursore
                    password = password[0..^1];
                    Console.Write("\b \b"); // Simula la cancellazione del carattere dalla console
                }
            }
            else
            {
                password += info.KeyChar; // Aggiunge il carattere alla password
                Console.Write("*"); // Visualizza un asterisco per ogni carattere digitato
            }
        }

        Console.WriteLine();

        return password;
    }
}