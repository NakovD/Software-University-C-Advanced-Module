using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballPlayer player;

        private FootballTeam team;

        [SetUp]
        public void Setup()
        {
            player = new FootballPlayer("Gosho", 10, "Goalkeeper");
            team = new FootballTeam("some team", 20);
        }

        [Test]
        [TestCase(null, 2, "Goalkeeper")]
        [TestCase("", 2, "Goalkeeper")]
        [TestCase("Player", 0, "Goalkeeper")]
        [TestCase("Player", -5, "Goalkeeper")]
        [TestCase("Player", 22, "Goalkeeper")]
        [TestCase("Player", 5, "writer")]
        public void FootballPlayerCtorThrowsWithInvalidArgs(string name, int playerNumber, string position)
        {
            Assert.Throws<ArgumentException>(() => player = new FootballPlayer(name, playerNumber, position));
        }

        [Test]
        public void FootballPlayerCtorCreatesThePlayerWithValidArgsAndSetsScoredGoalsToZero()
        {
            var expectedName = "Player";
            var expectedNumber = 15;
            var expectedPosition = "Midfielder";
            var expectedGoals = 0;

            player = new FootballPlayer(expectedName, expectedNumber, expectedPosition);

            var actualName = player.Name;
            var actualNumber = player.PlayerNumber;
            var actualPosition = player.Position;
            var actualGoals = player.ScoredGoals;

            Assert.IsTrue(expectedName == actualName);
            Assert.IsTrue(expectedNumber == actualNumber);
            Assert.IsTrue(expectedPosition == actualPosition);
            Assert.IsTrue(expectedGoals == actualGoals);
        }

        [Test]
        public void FootballPlayerScoreMethodIncreasesTheScoredGoals()
        {
            var expectedGoals = 1;

            player.Score();

            var actualGoals = player.ScoredGoals;

            Assert.IsTrue(expectedGoals == actualGoals);
        }

        [Test]
        [TestCase(null, 20)]
        [TestCase("", 20)]
        [TestCase("Some team", 10)]
        public void FootballTeamCtorThrowsWithInvalidArgs(string name, int capacity)
        {
            Assert.Throws<ArgumentException>(() => team = new FootballTeam(name, capacity));
        }

        [Test]
        public void FootballTeamCtorCreatesTheTeamCorreclty()
        {
            var expectedName = "Some team";
            var expectedCapacity = 20;
            var expectedCollection = new List<FootballPlayer>();

            team = new FootballTeam(expectedName, expectedCapacity);

            var actualName = team.Name;
            var actualCapacity = team.Capacity;
            var actualCollection = team.Players;

            Assert.IsTrue(expectedName == actualName);
            Assert.IsTrue(expectedCapacity == actualCapacity);
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void AddPlayerMethodReturnsStringForNoPositions()
        {
            team.Capacity = 15;
            var players = new List<FootballPlayer>();

            for (int i = 0; i < 15; i++)
            {
                team.AddNewPlayer(player);
                players.Add(player);
            }

            var expectedResult = "No more positions available!";
            var expectedCount = 15;
            var expectedCollection = players;

            var actualResult = team.AddNewPlayer(player);
            var actualCount = team.Players.Count;
            var actualCollection = team.Players;

            Assert.IsTrue(expectedResult == actualResult);
            Assert.IsTrue(expectedCount == actualCount);
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void AddPlayerAddsThePlayerToTheTeam()
        {
            var expectedResult = $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";
            var expectedCount = 1;
            var expectedCollection = new List<FootballPlayer>() { player };


            var actualResult = team.AddNewPlayer(player);
            var actualCount = team.Players.Count;
            var actualCollection = team.Players;

            Assert.IsTrue(expectedResult == actualResult);
            Assert.IsTrue(expectedCount == actualCount);
            CollectionAssert.AreEqual(expectedCollection, actualCollection);
        }

        [Test]
        public void PickPlayerReturnsNullWithNameOfNonExistentPlayer()
        {
            team.AddNewPlayer(player);

            var result = team.PickPlayer("gosho");

            Assert.IsNull(result);
        }

        [Test]
        public void PickPlayerReturnsCorrectPlayer()
        {
            team.AddNewPlayer(player);
            team.AddNewPlayer(new FootballPlayer("gosho", 14, "Midfielder"));
            team.AddNewPlayer(new FootballPlayer("dawdaw", 11, "Forward"));

            var resultPlayer = team.PickPlayer(player.Name);

            Assert.AreEqual(player, resultPlayer);
        }

        [Test]
        public void PlayerScoreThrowsWithInvalidPlayerNumber()
        {
            Assert.Throws<NullReferenceException>(() => team.PlayerScore(7));
        }

        [Test]
        public void PlayerScoreIncreasesThePlayerScoreAndReturnsCorrectString()
        {
            team.AddNewPlayer(player);

            var expectedResult = $"{player.Name} scored and now has {player.ScoredGoals + 1} for this season!";
            var expectedGoals = player.ScoredGoals + 1;

            var actualResult = team.PlayerScore(player.PlayerNumber);
            var actualGoals = player.ScoredGoals;

            Assert.IsTrue(expectedResult == actualResult);
            Assert.IsTrue(expectedGoals == actualGoals);
        }
    }
}