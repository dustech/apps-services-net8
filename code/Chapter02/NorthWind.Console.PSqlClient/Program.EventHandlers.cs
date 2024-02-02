using System.Data; // to use StateChangeEventArgs
using Npgsql; // to use NpgsqlNoticeEventArgs
 
internal partial class Program
{
  private static void Connection_StateChange(object sender, StateChangeEventArgs e)
  {
    WriteLineInColor(
      $"State change from {e.OriginalState} to {e.CurrentState}.",
      ConsoleColor.DarkYellow);
  }

  private static void Connection_InfoMessage(object sender, NpgsqlNoticeEventArgs e)
  {
    WriteLineInColor($"Info: {e.Notice}.", ConsoleColor.DarkBlue);
  }
}
