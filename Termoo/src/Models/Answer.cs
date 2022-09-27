using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termoo.src.Models
{
  public class Answer
  {
    public static CharHits[] Hits = new CharHits[5];
    
    public static char[] LastWord = new char[5];

    public static string formatWord(string wordPlayed)
        => removeAccent(wordPlayed.ToUpper());

    private static string removeAccent(string word)
        => new string(word
            .Normalize(NormalizationForm.FormD)
            .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
            .ToArray());

   
    public static CharHits[] checkLetters(string wordPlayed, string wordOfDay)
    {

      char[] lettersPlayed = wordPlayed.ToCharArray();
      char[] lettersDay = wordOfDay.ToCharArray();


      for (int i = 0; i < 5; i++)
      {
        if (lettersDay.Contains(lettersPlayed[i]))
        {
          LastWord = lettersPlayed;

          if (lettersDay[i] == lettersPlayed[i])
          {
            Hits[i] = CharHits.OK;
          }
          else
          {
            Hits[i] = CharHits.WRONG;
          }

        }
        else
        {
          Termo.LettersUsed.Add(lettersPlayed[i]);
          Hits[i] = CharHits.INVALID;
        }

      }

      return Hits;

    }
  }


}