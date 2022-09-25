namespace Termoo
{
  public class Termo
  {
    public string wordOfDay { get; set; }
    private string[] words = new string[10];
    public List<char> LettersUsed = new List<char>();
    public CharHits[] hits = new CharHits[5];

    private char[] LastWord = new char[5];
    public int Attempts = 0;

    public Status checkWords(string wordPlayed)
    {
      Attempts++;

      if (wordPlayed == this.wordOfDay)
        return Status.WIN;

      this.getValidWords();
      if (!this.words.Contains(wordPlayed))
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

    public void sortWordOfDay()
    {
      Random rnd = new Random();
      int position = rnd.Next(0, 9);
      getValidWords();
      this.wordOfDay = this.words[position];
    }

    //Isso ficaria bonitão em sqlite
    private void getValidWords()
    {
      this.words[0] = "AVIÃO";
      this.words[1] = "PAVÃO";
      this.words[2] = "AVIAR";
      this.words[3] = "PAVIO";
      this.words[4] = "ÁUDIO";
      this.words[5] = "COISA";
      this.words[6] = "VEIAS";
      this.words[7] = "ESQUI";
      this.words[8] = "ÁGUIA";
      this.words[9] = "ESPIÃ";

    }
  }
}