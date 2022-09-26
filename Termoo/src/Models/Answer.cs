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
    public static string formatWord(string wordPlayed)
        => removeAccent(wordPlayed.ToUpper());

    private static string removeAccent(string word)
        => new string(word
            .Normalize(NormalizationForm.FormD)
            .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
            .ToArray());
  }
}