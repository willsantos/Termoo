using Termoo.src.Models;
namespace Termoo.src
{
  public class Termo
  {
    public string wordOfDay { get; set; }
    public static List<char> LettersUsed = new List<char>();

    public int Attempts = 0;

    public Word words = new Word();

    public Termo()
    {
      this.wordOfDay = words.sortWordOfDay();
    }


    public Status Play(string wordPlayed)
    {
      Attempts++;
      wordPlayed = Answer.formatWord(wordPlayed);

      if (wordPlayed == this.wordOfDay)
        return Status.WIN;

      if (!words.isValidWord(wordPlayed))
      {
        Attempts--;
        return Status.UNKNOWN;
      }

      if (Attempts > 4)
        return Status.GAMEOVER;

      Answer.checkLetters(wordPlayed, this.wordOfDay);
      return Status.WRONG;

    }



    public void colorLetter()
    {
      for (int i = 0; i < 5; i++)
      {
        switch (Answer.Hits[i])
        {
          case CharHits.INVALID:
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(Answer.LastWord[i]);
            Console.ResetColor();
            break;
          case CharHits.WRONG:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(Answer.LastWord[i]);
            Console.ResetColor();
            break;
          case CharHits.OK:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Answer.LastWord[i]);
            Console.ResetColor();
            break;
          default:
            throw new Exception();
        }
      }
      Console.WriteLine();

    }




  }
}