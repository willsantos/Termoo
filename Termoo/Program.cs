using Termoo;

Termo game = new Termo();
game.sortWordOfDay();

//DEBUG
game.wordOfDay = "PAVÃO";


Console.WriteLine("Encontre a palavra do dia! São apenas 5 letras");
Console.WriteLine($"DEBUG: A PALAVRA ATUAL É {game.wordOfDay}");
do
{
  Console.WriteLine($"Você ainda tem {5 - game.Attempts} tentativas");
  if (game.LettersUsed.Count() > 0)
  {
    Console.WriteLine("Letras já usadas");
    foreach (char item in game.LettersUsed)
    {

      Console.Write($"{item} ");
    }
    Console.WriteLine();
  }

  string wordPlayed = null;


  Console.WriteLine("Digite sua palavra");
  wordPlayed = Console.ReadLine();

  var WordResult = game.checkWords(wordPlayed);

  switch (WordResult)
  {
    case Status.WIN:
      Console.WriteLine("Parabens");
      break;
    case Status.UNKNOWN:
      Console.WriteLine("Não conheço essa palavra");
      break;
    case Status.GAMEOVER:
      Console.WriteLine("Não tem chororo, esse jogo acabou!");
      break;
    case Status.WRONG:
      Console.WriteLine("Acertou alguma coisa");
      break;
    default:
      throw new Exception();
  }

  game.colorLetter();
} while (game.Attempts < 5);


