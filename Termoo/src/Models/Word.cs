using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Termoo.src.Models
{
  public class Word
  {
    private string[] words = new string[10];

    
    public string sortWordOfDay()
    {
      Random rnd = new Random();
      int position = rnd.Next(0, 9);
      getValidWords();
      return this.words[position];
    }

    public bool isValidWord(string word)
        => this.words.Contains(word);

    //Isso ficaria bonitão em sqlite
    public void getValidWords()
    {
      this.words[0] = "AVIAO";
      this.words[1] = "PAVAO";
      this.words[2] = "AVIAR";
      this.words[3] = "PAVIO";
      this.words[4] = "AUDIO";
      this.words[5] = "COISA";
      this.words[6] = "VEIAS";
      this.words[7] = "ESQUI";
      this.words[8] = "AGUIA";
      this.words[9] = "ESPIA";

    }

  }
}