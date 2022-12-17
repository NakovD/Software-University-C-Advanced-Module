using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using NUnit.Framework;

[TestFixture]
public class HeroRepositoryTests
{
    private Hero hero;

    private HeroRepository heroes;

    [SetUp]
    public void SetUp()
    {
        hero = new Hero("Gosho", 15);
        heroes = new HeroRepository();
    }

    [Test]
    [TestCase("Tosho", 5)]
    [TestCase("Gosho", 15)]
    [TestCase("Pesho", 150)]
    public void HeroCtorSetsTheObjPropsWithValidArgs(string name, int level)
    {
        var expectedName = name;
        var expectedLevel = level;

        hero = new Hero(name, level);

        var actualName = hero.Name;
        var actualLevel = hero.Level;

        Assert.IsTrue(expectedName == actualName);
        Assert.IsTrue(expectedLevel == actualLevel);
    }

    [Test]
    public void HeroRepositoryCtorCreatesCollectionCorrectly()
    {
        var expectedCollection = new List<Hero>().AsReadOnly();
        var expectedCount = expectedCollection.Count;

        var actualCollection = heroes.Heroes;
        var actualCount = actualCollection.Count;

        CollectionAssert.AreEqual(expectedCollection, actualCollection);
        Assert.IsTrue(expectedCount == actualCount);
    }

    [Test]
    public void CreateMethodThrowsWithNullHero()
    {
        hero = null;

        Assert.Throws<ArgumentNullException>(() => heroes.Create(hero));
    }

    [Test]
    public void CreateMethodThrowsIfTheRepositoryAlreadyHasAHeroWithTheSameName()
    {
        heroes.Create(hero);

        Assert.Throws<InvalidOperationException>(() => heroes.Create(hero));
    }

    [Test]
    public void CreateMethodAddsHeroWhenRepositoryIsEmpty()
    {
        var expectedCollection = new List<Hero>() { hero }.AsReadOnly();
        var expectedCount = expectedCollection.Count;
        var expectedMethodResult = $"Successfully added hero {hero.Name} with level {hero.Level}";

        var actualMethodResult = heroes.Create(hero);
        var actualCollection = heroes.Heroes;
        var actualCount = actualCollection.Count;

        CollectionAssert.AreEqual(expectedCollection, actualCollection);
        Assert.IsTrue(expectedCount == actualCount);
        Assert.IsTrue(expectedMethodResult == actualMethodResult);
    }

    [Test]
    public void CreateMethodAddsHeroWhenRepositoryHasHeroes()
    {
        var anotherHero = new Hero("Tosho", 151);
        var andAnotherOne = new Hero("Gogo", 1);

        var expectedCollection = new List<Hero>() { anotherHero, andAnotherOne, hero }.AsReadOnly();
        var expectedCount = expectedCollection.Count;
        var expectedMethodResult = $"Successfully added hero {hero.Name} with level {hero.Level}";

        heroes.Create(anotherHero);
        heroes.Create(andAnotherOne);

        var actualMethodResult = heroes.Create(hero);
        var actualCollection = heroes.Heroes;
        var actualCount = actualCollection.Count;

        CollectionAssert.AreEqual(expectedCollection, actualCollection);
        Assert.IsTrue(expectedCount == actualCount);
        Assert.IsTrue(expectedMethodResult == actualMethodResult);
    }

    [Test]
    [TestCase(null)]
    [TestCase("")]
    [TestCase("   ")]
    public void RemoveMethodThrowsWithInvalidPassedName(string name)
    {
        Assert.Throws<ArgumentNullException>(() => heroes.Remove(name));
    }

    [Test]
    public void RemoveMethodReturnsFalseWithNonExistingHero()
    {
        var expectedMethodResult = false;

        var actualResult = heroes.Remove("gosho");

        Assert.IsTrue(expectedMethodResult == actualResult);

    }

    [Test]
    public void RemoveMethodRemovesCorrectly()
    {
        var hero1 = new Hero("gosho", 15);
        var hero2 = new Hero("tosho", 150);

        heroes.Create(hero);
        heroes.Create(hero1);
        heroes.Create(hero2);

        var expectedMethodResult = true;
        var expectedCollection = new List<Hero>()
        {
            hero1, hero2
        }.AsReadOnly();
        var expectedCount = expectedCollection.Count;

        var actualMethodResult = heroes.Remove(hero.Name);
        var actualCollection = heroes.Heroes;
        var actualCount = actualCollection.Count;

        CollectionAssert.AreEqual(expectedCollection, actualCollection);
        Assert.IsTrue(expectedMethodResult == actualMethodResult);
        Assert.IsTrue(expectedCount == actualCount);
    }

    [Test]
    public void GetHeroWithHighestLevelReturnsCorrectHero()
    {
        var expectedResult = hero;

        heroes.Create(hero);
        heroes.Create(new Hero("gosho", 5));
        heroes.Create(new Hero("tosho", 10));

        var actualResult = heroes.GetHeroWithHighestLevel();

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void GetHeroReturnsNullWhenSearchingForNonExistentHero()
    {
        heroes.Create(new Hero("gosho", 5));
        heroes.Create(new Hero("tosho", 10));

        var actualResult = heroes.GetHero(hero.Name);

        Assert.IsNull(actualResult);
    }

    [Test]
    public void GetHeroReturnsCorrectHero()
    {
        heroes.Create(new Hero("gosho", 5));
        heroes.Create(new Hero("tosho", 10));
        heroes.Create(hero);

        var expectedResult = hero;

        var actualResult = heroes.GetHero(hero.Name);

        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void HeroesPropertyReturnsCorrectReadonlyCollection()
    {
        var hero1 = new Hero("gosho", 5);
        var hero2 = new Hero("tosho", 10);

        var expectedCollection = new List<Hero>()
        {
            hero, hero1, hero2
        }.AsReadOnly();

        heroes.Create(hero);
        heroes.Create(hero1);
        heroes.Create(hero2);

        var actualCollection = heroes.Heroes;

        CollectionAssert.AreEqual(expectedCollection, actualCollection);
    }
}