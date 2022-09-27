using Termoo.src;
using Termoo.src.Models;
namespace Termoo;

public class Program
{

  private static bool DEBUG = true;
  public static void Main(string[] args)
  {


    Termo game = new Termo();


    Status WordResult = Status.UNKNOWN;



    Console.WriteLine("Encontre a palavra do dia! São apenas 5 letras");

    if (DEBUG == true)
      Console.WriteLine($"DEBUG: A PALAVRA ATUAL É {game.wordOfDay}");

    do
    {
      Console.ForegroundColor = ConsoleColor.Magenta;
      Console.WriteLine($"\u2665 Você ainda tem {5 - game.Attempts} tentativas");
      Console.ResetColor();
      if (Termo.LettersUsed.Count() > 0)
      {
        Console.WriteLine("Letras já usadas");
        foreach (char item in Termo.LettersUsed.Distinct())
        {

          Console.Write($"{item} ");
        }
        Console.WriteLine();
      }




      Console.WriteLine("Digite sua palavra");
      string wordPlayed = Console.ReadLine();

      WordResult = game.Play(wordPlayed);

      switch (WordResult)
      {
        case Status.WIN:
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine("Parabens você acertou");
          Console.ResetColor();
          break;
        case Status.UNKNOWN:
          Console.ForegroundColor = ConsoleColor.DarkMagenta;
          Console.WriteLine("==>Não conheço essa palavra");
          Console.ResetColor();
          break;
        case Status.GAMEOVER:
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("Não tem chororo, esse jogo acabou!");
          Console.ResetColor();
          break;
        case Status.WRONG:
          Console.ForegroundColor = ConsoleColor.DarkYellow;
          Console.WriteLine("Acertou alguma coisa");
          Console.ResetColor();
          break;
        default:
          throw new Exception();
      }
      if (WordResult != Status.WIN)
        game.colorLetter();
    } while (game.Attempts < 5 && WordResult != Status.WIN);
  }

}








