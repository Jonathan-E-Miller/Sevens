using BJSS;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BJSSTests
{
  public class InputTests
  {
    [SetUp]
    public void SetUp()
    {

    }

    [TestCase("2D", true)]
    [TestCase("3D", true)]
    [TestCase("4D", true)]
    [TestCase("5D", true)]
    [TestCase("6D", true)]
    [TestCase("7D", true)]
    [TestCase("8D", true)]
    [TestCase("9D", true)]
    [TestCase("10D", true)]
    [TestCase("JD", true)]
    [TestCase("QD", true)]
    [TestCase("KD", true)]
    [TestCase("AD", true)]
    [TestCase("2H", true)]
    [TestCase("3H", true)]
    [TestCase("4H", true)]
    [TestCase("5H", true)]
    [TestCase("6H", true)]
    [TestCase("7H", true)]
    [TestCase("8H", true)]
    [TestCase("9H", true)]
    [TestCase("10H", true)]
    [TestCase("JH", true)]
    [TestCase("QH", true)]
    [TestCase("KH", true)]
    [TestCase("AH", true)]
    [TestCase("BoB", false)]
    [TestCase("1", false)]
    [TestCase("Some Rubbish Input", false)]
    public void TestParseInput(string input, bool valid)
    {
      ManualPlayer player = new ManualPlayer("Test");
      Card card = player.ParseInput(input);

      if (valid)
      {
        Assert.IsNotNull(card);
      }
      else
      {
        Assert.IsNull(card);
      }
    }
  }
}
