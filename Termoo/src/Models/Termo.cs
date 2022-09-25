using Termoo.src.Models;
namespace Termoo.src
{
  public class Termo
  {
    public string wordOfDay { get; set; }

    public List<char> LettersUsed = new List<char>();
    public CharHits[] hits = new CharHits[5];

    private char[] LastWord = new char[5];
    public int Attempts = 0;

    public Word words = new Word();

    public Termo()
    {
      this.wordOfDay = words.sortWordOfDay();
    }

    public Status checkWords(string wordPlayed)
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

      checkLetters(wordPlayed);
      return Status.WRONG;
    }


    public void colorLetter()
    {
      for (int i = 0; i < 5; i++)
      {
        switch (this.hits[i])
        {
          case CharHits.INVALID:
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(this.LastWord[i]);
            Console.ResetColor();
            break;
          case CharHits.WRONG:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(this.LastWord[i]);
            Console.ResetColor();
            break;
          case CharHits.OK:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(this.LastWord[i]);
            Console.ResetColor();
            break;
          default:
            throw new Exception();
        }
      }
      Console.WriteLine();

    }
    public CharHits[] checkLetters(string wordPlayed)
    {

      char[] lettersPlayed = wordPlayed.ToCharArray();
      char[] lettersDay = this.wordOfDay.ToCharArray();


      for (int i = 0; i < 5; i++)
      {
        if (lettersDay.Contains(lettersPlayed[i]))
        {
          this.LastWord = lettersPlayed;

          if (lettersDay[i] == lettersPlayed[i])
          {
            hits[i] = CharHits.OK;
          }
          else
          {
            hits[i] = CharHits.WRONG;
          }

        }
        else
        {
          LettersUsed.Add(lettersPlayed[i]);
          hits[i] = CharHits.INVALID;
        }

      }

      return hits;

    }



  }
}