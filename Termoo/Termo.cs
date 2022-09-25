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

    private void getValidWords()
    {
      this.words[0] = "AVIÃO";
      this.words[1] = "PAVÃO";
      this.words[2] = "AVIAR";
      this.words[3] = "PAVIO";
      this.words[4] = "ÁUDIO";
      this.words[5] = "COISA";
      this.words[6] = "VEIAS";
      this.words[7] = "ÉGUA";
      this.words[8] = "ÁGUIA";
      this.words[9] = "ESPIÃ";

    }
  }
}