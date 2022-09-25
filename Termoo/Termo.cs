using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Termoo
{
  public class Termo
  {
    public string wordOfDay { get; set; }
    //private List<string> words = new List<string>();
    private string[] words = new string[10];
    private int attempts = 0;

    public Status checkWords(string wordPlayed)
    {
      attempts++;

      if (wordPlayed == this.wordOfDay)
        return Status.WIN;

      this.getValidWords();
      if (!this.words.Contains(wordPlayed))
      {
        attempts--;
        return Status.UNKNOWN;
      }


      if (attempts > 4)
        return Status.GAMEOVER;
      return Status.WRONG;
    }

    public CharHits[] checkLetters(string wordPlayed)
    {

      char[] lettersPlayed = wordPlayed.ToCharArray();
      char[] lettersDay = this.wordOfDay.ToCharArray();
      CharHits[] hits = new CharHits[5];

      for (int i = 0; i < 5; i++)
      {
        if (lettersDay.Contains(lettersPlayed[i]))
        {
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
          hits[i] = CharHits.INVALID;
        }
      }

      return hits;

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