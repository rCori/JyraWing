using UnityEngine;
using NUnit.Framework;
using System.Collections;

public class HighScoreDataTest {

    private HighScoreData.SavedScore[] makeTestData() {
        HighScoreData.SavedScore[] newScoreData = new HighScoreData.SavedScore[10];
        newScoreData[0] = new HighScoreData.SavedScore(100, "A");
        newScoreData[1] = new HighScoreData.SavedScore(90, "B");
        newScoreData[2] = new HighScoreData.SavedScore(80, "C");
        newScoreData[3] = new HighScoreData.SavedScore(70, "D");
        newScoreData[4] = new HighScoreData.SavedScore(60, "E");
        newScoreData[5] = new HighScoreData.SavedScore(50, "F");
        newScoreData[6] = new HighScoreData.SavedScore(40, "G");
        newScoreData[7] = new HighScoreData.SavedScore(30, "H");
        newScoreData[8] = new HighScoreData.SavedScore(20, "I");
        newScoreData[9] = new HighScoreData.SavedScore(10, "J");
        return newScoreData;
    }

    [Test]
    public void test_CheckScoreInFirstPlace() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        int scoreRank = HighScoreData.Instance.CheckScore(105);
        //Assert
        Assert.AreEqual(scoreRank, 1);
    }

    [Test]
    public void test_CheckScoreInPlace2() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        int scoreRank = HighScoreData.Instance.CheckScore(95);
        //Assert
        Assert.AreEqual(scoreRank, 2);
    }

    [Test]
    public void test_CheckScoreInPlace3() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        int scoreRank = HighScoreData.Instance.CheckScore(85);
        //Assert
        Assert.AreEqual(scoreRank, 3);
    }

    [Test]
    public void test_CheckScoreInPlace4() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        int scoreRank = HighScoreData.Instance.CheckScore(75);
        //Assert
        Assert.AreEqual(scoreRank, 4);
    }

    [Test]
    public void test_CheckScoreInPlace5() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        int scoreRank = HighScoreData.Instance.CheckScore(65);
        //Assert
        Assert.AreEqual(scoreRank, 5);
    }

    [Test]
    public void test_CheckScoreInPlace6() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        int scoreRank = HighScoreData.Instance.CheckScore(55);
        //Assert
        Assert.AreEqual(scoreRank, 6);
    }

    [Test]
    public void test_CheckScoreInPlace7() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        int scoreRank = HighScoreData.Instance.CheckScore(45);
        //Assert
        Assert.AreEqual(scoreRank, 7);
    }

    [Test]
    public void test_CheckScoreInPlace8() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        int scoreRank = HighScoreData.Instance.CheckScore(35);
        //Assert
        Assert.AreEqual(scoreRank, 8);
    }

    [Test]
    public void test_CheckScoreInPlace9() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        int scoreRank = HighScoreData.Instance.CheckScore(25);
        //Assert
        Assert.AreEqual(scoreRank, 9);
    }

    [Test]
    public void test_CheckScoreInLastPlace() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        int scoreRank = HighScoreData.Instance.CheckScore(15);
        //Assert
        Assert.AreEqual(scoreRank, 10);
    }

    [Test]
    public void test_CheckScoreNotPlacing() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        int scoreRank = HighScoreData.Instance.CheckScore(5);
        //Assert
        Assert.AreEqual(scoreRank, -1);
    }



    [Test]
    public void test_EnterScoreInFirstPlace() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        HighScoreData.Instance.EnterScore(105, "NEWHIGH");
        //Assert
        HighScoreData.SavedScore currentTestScore = HighScoreData.Instance.GetScore(1);
        Assert.AreEqual(currentTestScore.score, 105);
        Assert.AreEqual(currentTestScore.name, "NEWHIGH");

        currentTestScore = HighScoreData.Instance.GetScore(2);
        Assert.AreEqual(currentTestScore.score, 100);
        Assert.AreEqual(currentTestScore.name, "A");

        currentTestScore = HighScoreData.Instance.GetScore(3);
        Assert.AreEqual(currentTestScore.score, 90);
        Assert.AreEqual(currentTestScore.name, "B");

        currentTestScore = HighScoreData.Instance.GetScore(4);
        Assert.AreEqual(currentTestScore.score, 80);
        Assert.AreEqual(currentTestScore.name, "C");

        currentTestScore = HighScoreData.Instance.GetScore(10);
        Assert.AreEqual(currentTestScore.score, 20);
        Assert.AreEqual(currentTestScore.name, "I");
    }
    
    [Test]
    public void test_EnterScoreInLastPlace() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        HighScoreData.Instance.EnterScore(15, "NEWLAST");
        //Assert
        HighScoreData.SavedScore currentTestScore = HighScoreData.Instance.GetScore(10);
        Assert.AreEqual(currentTestScore.score, 15);
        Assert.AreEqual(currentTestScore.name, "NEWLAST");

        currentTestScore = HighScoreData.Instance.GetScore(1);
        Assert.AreEqual(currentTestScore.score, 100);
        Assert.AreEqual(currentTestScore.name, "A");

        currentTestScore = HighScoreData.Instance.GetScore(2);
        Assert.AreEqual(currentTestScore.score, 90);
        Assert.AreEqual(currentTestScore.name, "B");

        currentTestScore = HighScoreData.Instance.GetScore(3);
        Assert.AreEqual(currentTestScore.score, 80);
        Assert.AreEqual(currentTestScore.name, "C");

        currentTestScore = HighScoreData.Instance.GetScore(8);
        Assert.AreEqual(currentTestScore.score, 30);
        Assert.AreEqual(currentTestScore.name, "H");

        currentTestScore = HighScoreData.Instance.GetScore(9);
        Assert.AreEqual(currentTestScore.score, 20);
        Assert.AreEqual(currentTestScore.name, "I");
    }

    [Test]
    public void test_EnterScoreInPlace2() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        HighScoreData.Instance.EnterScore(95, "NEWTWO");
        //Assert
        HighScoreData.SavedScore currentTestScore = HighScoreData.Instance.GetScore(2);
        Assert.AreEqual(currentTestScore.score, 95);
        Assert.AreEqual(currentTestScore.name, "NEWTWO");

        currentTestScore = HighScoreData.Instance.GetScore(1);
        Assert.AreEqual(currentTestScore.score, 100);
        Assert.AreEqual(currentTestScore.name, "A");

        currentTestScore = HighScoreData.Instance.GetScore(3);
        Assert.AreEqual(currentTestScore.score, 90);
        Assert.AreEqual(currentTestScore.name, "B");

        currentTestScore = HighScoreData.Instance.GetScore(4);
        Assert.AreEqual(currentTestScore.score, 80);
        Assert.AreEqual(currentTestScore.name, "C");

        currentTestScore = HighScoreData.Instance.GetScore(8);
        Assert.AreEqual(currentTestScore.score, 40);
        Assert.AreEqual(currentTestScore.name, "G");

        currentTestScore = HighScoreData.Instance.GetScore(9);
        Assert.AreEqual(currentTestScore.score, 30);
        Assert.AreEqual(currentTestScore.name, "H");

        currentTestScore = HighScoreData.Instance.GetScore(10);
        Assert.AreEqual(currentTestScore.score, 20);
        Assert.AreEqual(currentTestScore.name, "I");
    }

    [Test]
    public void test_EnterScoreInPlace3() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        HighScoreData.Instance.EnterScore(85, "NEWTHREE");
        //Assert
        HighScoreData.SavedScore currentTestScore = HighScoreData.Instance.GetScore(3);
        Assert.AreEqual(currentTestScore.score, 85);
        Assert.AreEqual(currentTestScore.name, "NEWTHREE");

        currentTestScore = HighScoreData.Instance.GetScore(1);
        Assert.AreEqual(currentTestScore.score, 100);
        Assert.AreEqual(currentTestScore.name, "A");

        currentTestScore = HighScoreData.Instance.GetScore(2);
        Assert.AreEqual(currentTestScore.score, 90);
        Assert.AreEqual(currentTestScore.name, "B");

        currentTestScore = HighScoreData.Instance.GetScore(4);
        Assert.AreEqual(currentTestScore.score, 80);
        Assert.AreEqual(currentTestScore.name, "C");

        currentTestScore = HighScoreData.Instance.GetScore(8);
        Assert.AreEqual(currentTestScore.score, 40);
        Assert.AreEqual(currentTestScore.name, "G");

        currentTestScore = HighScoreData.Instance.GetScore(9);
        Assert.AreEqual(currentTestScore.score, 30);
        Assert.AreEqual(currentTestScore.name, "H");

        currentTestScore = HighScoreData.Instance.GetScore(10);
        Assert.AreEqual(currentTestScore.score, 20);
        Assert.AreEqual(currentTestScore.name, "I");
    }

    [Test]
    public void test_EnterScoreInPlace4() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        HighScoreData.Instance.EnterScore(75, "NEWFOUR");
        //Assert
        HighScoreData.SavedScore currentTestScore = HighScoreData.Instance.GetScore(4);
        Assert.AreEqual(currentTestScore.score, 75);
        Assert.AreEqual(currentTestScore.name, "NEWFOUR");

        currentTestScore = HighScoreData.Instance.GetScore(2);
        Assert.AreEqual(currentTestScore.score, 90);
        Assert.AreEqual(currentTestScore.name, "B");

        currentTestScore = HighScoreData.Instance.GetScore(3);
        Assert.AreEqual(currentTestScore.score, 80);
        Assert.AreEqual(currentTestScore.name, "C");

        currentTestScore = HighScoreData.Instance.GetScore(9);
        Assert.AreEqual(currentTestScore.score, 30);
        Assert.AreEqual(currentTestScore.name, "H");

        currentTestScore = HighScoreData.Instance.GetScore(10);
        Assert.AreEqual(currentTestScore.score, 20);
        Assert.AreEqual(currentTestScore.name, "I");
    }

    [Test]
    public void test_EnterScoreInPlace5() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        HighScoreData.Instance.EnterScore(65, "NEWFIVE");
        //Assert
        HighScoreData.SavedScore currentTestScore = HighScoreData.Instance.GetScore(5);
        Assert.AreEqual(currentTestScore.score, 65);
        Assert.AreEqual(currentTestScore.name, "NEWFIVE");

        currentTestScore = HighScoreData.Instance.GetScore(2);
        Assert.AreEqual(currentTestScore.score, 90);
        Assert.AreEqual(currentTestScore.name, "B");

        currentTestScore = HighScoreData.Instance.GetScore(3);
        Assert.AreEqual(currentTestScore.score, 80);
        Assert.AreEqual(currentTestScore.name, "C");

        currentTestScore = HighScoreData.Instance.GetScore(9);
        Assert.AreEqual(currentTestScore.score, 30);
        Assert.AreEqual(currentTestScore.name, "H");

        currentTestScore = HighScoreData.Instance.GetScore(10);
        Assert.AreEqual(currentTestScore.score, 20);
        Assert.AreEqual(currentTestScore.name, "I");
    }

    [Test]
    public void test_EnterScoreInPlace6() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        HighScoreData.Instance.EnterScore(55, "NEWSIX");
        //Assert
        HighScoreData.SavedScore currentTestScore = HighScoreData.Instance.GetScore(6);
        Assert.AreEqual(currentTestScore.score, 55);
        Assert.AreEqual(currentTestScore.name, "NEWSIX");

        currentTestScore = HighScoreData.Instance.GetScore(1);
        Assert.AreEqual(currentTestScore.score, 100);
        Assert.AreEqual(currentTestScore.name, "A");

        currentTestScore = HighScoreData.Instance.GetScore(2);
        Assert.AreEqual(currentTestScore.score, 90);
        Assert.AreEqual(currentTestScore.name, "B");

        currentTestScore = HighScoreData.Instance.GetScore(8);
        Assert.AreEqual(currentTestScore.score, 40);
        Assert.AreEqual(currentTestScore.name, "G");

        currentTestScore = HighScoreData.Instance.GetScore(9);
        Assert.AreEqual(currentTestScore.score, 30);
        Assert.AreEqual(currentTestScore.name, "H");

        currentTestScore = HighScoreData.Instance.GetScore(10);
        Assert.AreEqual(currentTestScore.score, 20);
        Assert.AreEqual(currentTestScore.name, "I");
    }


    [Test]
    public void test_EnterScoreNotPlacing() {
        //Arrange
        HighScoreData.Instance.LoadAlternateScores(makeTestData());
        //Act
        HighScoreData.Instance.EnterScore(5, "NOPLACE");
        //Assert

        HighScoreData.SavedScore currentTestScore = HighScoreData.Instance.GetScore(1);
        Assert.AreEqual(currentTestScore.score, 100);
        Assert.AreEqual(currentTestScore.name, "A");

        currentTestScore = HighScoreData.Instance.GetScore(2);
        Assert.AreEqual(currentTestScore.score, 90);
        Assert.AreEqual(currentTestScore.name, "B");

        currentTestScore = HighScoreData.Instance.GetScore(8);
        Assert.AreEqual(currentTestScore.score, 30);
        Assert.AreEqual(currentTestScore.name, "H");

        currentTestScore = HighScoreData.Instance.GetScore(9);
        Assert.AreEqual(currentTestScore.score, 20);
        Assert.AreEqual(currentTestScore.name, "I");

        currentTestScore = HighScoreData.Instance.GetScore(10);
        Assert.AreEqual(currentTestScore.score, 10);
        Assert.AreEqual(currentTestScore.name, "J");
    }
    

}
