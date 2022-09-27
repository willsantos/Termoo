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
      game.wordOfDay = "PAVAO";
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
    public void TestHitsLetters()
    {
      Termo game = new Termo();
      game.wordOfDay = "PAVÃO";
      string wordPlayed = "AVIÃO";
      CharHits[] hits = new CharHits[5];
      hits[0] = CharHits.WRONG;
      hits[1] = CharHits.WRONG;
      hits[2] = CharHits.INVALID;
      hits[3] = CharHits.OK;
      hits[4] = CharHits.OK;


      var result = Answer.checkLetters(wordPlayed,game.wordOfDay);

      CollectionAssert.AreEquivalent(hits, result);
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
      game.wordOfDay = "PAVAO";

      string wordPlayed = "AVIÃO";
      var result = game.checkWords(wordPlayed);
      result = game.checkWords(wordPlayed);
      wordPlayed = "VEIAS";
      result = game.checkWords(wordPlayed);
      wordPlayed = "PAVIO";
      result = game.checkWords(wordPlayed);
      wordPlayed = "AUDIO";
      result = game.checkWords(wordPlayed);
      wordPlayed = "COISA";
      result = game.checkWords(wordPlayed);
      Assert.AreEqual(Status.GAMEOVER, result);
    }

    [TestMethod]
    public void TestAcceptsFormat()
    {
      string wordPlayed = "PaVÃo";
      var result = Answer.formatWord(wordPlayed);
      Assert.AreEqual("PAVAO", result);
    }

    [TestMethod]
    public void TestAttemptsWithUnknownWords()
    {
      Termo game = new Termo();
      game.wordOfDay = "PAVAO";

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