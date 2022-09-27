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
      var result = game.Play(wordPlayed);
      Assert.AreEqual(Status.WIN, result);
    }
    [TestMethod]
    public void TestWordWithDifferentLetters()
    {
      Termo game = new Termo();
      game.wordOfDay = "PAVÃO";
      string wordPlayed = "PAVIO";
      var result = game.Play(wordPlayed);
      Assert.AreEqual(Status.WRONG, result);
    }

    [TestMethod]
    public void TestWordWithLettersDifferentPosition()
    {
      Termo game = new Termo();
      game.wordOfDay = "PAVÃO";
      string wordPlayed = "AVIÃO";
      var result = game.Play(wordPlayed);
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
      var result = game.Play(wordPlayed);
      Assert.AreEqual(Status.UNKNOWN, result);
    }

    [TestMethod]
    public void TestAttempts()
    {
      Termo game = new Termo();
      game.wordOfDay = "PAVAO";

      string wordPlayed = "AVIÃO";
      var result = game.Play(wordPlayed);
      result = game.Play(wordPlayed);
      wordPlayed = "VEIAS";
      result = game.Play(wordPlayed);
      wordPlayed = "PAVIO";
      result = game.Play(wordPlayed);
      wordPlayed = "AUDIO";
      result = game.Play(wordPlayed);
      wordPlayed = "COISA";
      result = game.Play(wordPlayed);
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
      var result = game.Play(wordPlayed);
      result = game.Play(wordPlayed);
      wordPlayed = "HHHHH";
      result = game.Play(wordPlayed);
      wordPlayed = "MMMMM";
      result = game.Play(wordPlayed);
      wordPlayed = "AAAAA";
      result = game.Play(wordPlayed);
      wordPlayed = "PAVÃO";
      result = game.Play(wordPlayed);
      Assert.AreEqual(Status.WIN, result);
    }

  }
}