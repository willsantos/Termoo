using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
  [TestClass]
  public class TermoTest
  {
    [TestMethod]
    public void TestWordIsEqual()
    {
      Termo game = new Termo();  
      game.wordOfDay = "PAVÃO";
      string wordPlayed = "PAVÃO";
      var result = game.checkWords(wordPlayed);
      Assert.AreEqual(Status.WIN, result);
    }
    [TestMethod]
    public void TestWordWithDifferentLetters()
    {
      Termo game = new Termo();  
      game.wordOfDay = "PAVÃO";
      string wordPlayed = "PAVIO";
      var result = game.checkWords(wordPlayed);
      Assert.AreEqual(Status.WRONG, result);
    }

    [TestMethod]
    public void TestWordWithLettersDifferentPosition()
    {
      Termo game = new Termo();  
      game.wordOfDay = "PAVÃO";
      string wordPlayed = "AVIÃO";
      var result = game.checkWords(wordPlayed);
      Assert.AreEqual(Status.WRONG, result);
    }

    [TestMethod]
    public void TestWordUnknown()
    {
      Termo game = new Termo();  
      game.wordOfDay = "PAVÃO";
      string wordPlayed = "ABIÃO";
      var result = game.checkWords(wordPlayed);
      Assert.AreEqual(Status.UNKNOWN, result);
    }

    [TestMethod]
    public void TestAttempts()
    {
      Termo game = new Termo();  
      game.wordOfDay = "PAVÃO";

      string wordPlayed = "AVIÃO";
      var result = game.checkWords(wordPlayed);
      result = game.checkWords(wordPlayed);
      wordPlayed = "AVIAR";
      result = game.checkWords(wordPlayed);
      wordPlayed = "PAVIO";
      result = game.checkWords(wordPlayed);
      wordPlayed = "ÁUDIO";
      result = game.checkWords(wordPlayed);
      wordPlayed = "COISA";
      result = game.checkWords(wordPlayed);
      Assert.AreEqual(Status.GAMEOVER, result);
    }

     [TestMethod]
    public void TestAttemptsWithUnknownWords()
    {
      Termo game = new Termo();  
      game.wordOfDay = "PAVÃO";

      string wordPlayed = "LLLLL";
      var result = game.checkWords(wordPlayed);
      result = game.checkWords(wordPlayed);
      wordPlayed = "HHHHH";
      result = game.checkWords(wordPlayed);
      wordPlayed = "MMMMM";
      result = game.checkWords(wordPlayed);
      wordPlayed = "AAAAA";
      result = game.checkWords(wordPlayed);
      wordPlayed = "PAVÃO";
      result = game.checkWords(wordPlayed);
      Assert.AreEqual(Status.WIN, result);
    }

  }
}