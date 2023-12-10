using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using Xunit;
using DesignPatternsInCSharp.KATA.Singleton_AdamAndEve;

public class SingletonFacts
{
    [Fact]
    public void Adam_is_unique()
    {
        Adam adam = Adam.GetInstance();
        Adam anotherAdam = Adam.GetInstance();

        Assert.True(adam is Adam);
        Assert.Equal(adam, anotherAdam);

        // GetInstance() is the only static method on Adam
        Assert.Single(typeof(Adam).GetMethods().Where(x => x.IsStatic));

        // Adam has no public constructor nor can Adam be overriden
        Assert.DoesNotContain(typeof(Adam).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
, x => x.IsPublic || x.IsAssembly);
        Assert.True(typeof(Adam).IsSealed);
    }

    [Fact]
    public void Adam_is_a_human()
    {
        Assert.True(Adam.GetInstance() is Human);
    }

    [Fact]
    public void Adam_is_a_male()
    {
        Assert.True(Adam.GetInstance() is Male);
    }

    [Fact]
    public void Eve_is_unique_and_created_from_a_rib_of_adam()
    {
        Adam adam = Adam.GetInstance();
        Eve eve = Eve.GetInstance(adam);
        Eve anotherEve = Eve.GetInstance(adam);

        Assert.True(eve is Eve);
        Assert.Equal(eve, anotherEve);

        // GetInstance() is the only static method on Eve
        Assert.Single(typeof(Eve).GetMethods().Where(x => x.IsStatic));

        // Eve has no public constructor nor can Eve be overriden
        Assert.DoesNotContain(typeof(Eve).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
, x => x.IsPublic || x.IsAssembly);
        Assert.True(typeof(Eve).IsSealed);
    }

    [Fact]
    public void Eve_can_only_be_created_of_a_rib_of_adam()
    {
        Assert.Throws<ArgumentNullException>(() => Eve.GetInstance(null));
    }

    [Fact]
    public void Eve_is_a_human()
    {
        Assert.True(Eve.GetInstance(Adam.GetInstance()) is Human);
    }

    [Fact]
    public void Eve_is_a_female()
    {
        Assert.True(Eve.GetInstance(Adam.GetInstance()) is Female);
    }

    [Fact]
    public void Reproduction_always_results_in_either_a_male_or_female()
    {
        Assert.True(typeof(Human).IsAbstract);
    }

    [Fact]
    public void Humans_can_reproduce_when_there_is_a_name_a_mother_and_a_father()
    {
        var adam = Adam.GetInstance();
        var eve = Eve.GetInstance(adam);
        var seth = new Male("Seth", eve, adam);
        var azura = new Female("Azura", eve, adam);
        var enos = new Male("Enos", azura, seth);

        Assert.Equal("Eve", eve.Name);
        Assert.Equal("Adam", adam.Name);
        Assert.Equal("Seth", seth.Name);
        Assert.Equal("Azura", azura.Name);
        Assert.Equal("Enos", ((Human)enos).Name);
        Assert.Equal(seth, ((Human)enos).Father);
        Assert.Equal(azura, ((Human)enos).Mother);
    }

    [Fact]
    public void Father_and_mother_are_essential_for_reproduction()
    {
        // There is just 1 way to reproduce 
        Assert.Single(typeof(Male).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
          .Where(x => x.IsPublic || x.IsAssembly));
        Assert.Single(typeof(Female).GetConstructors(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).
          Where(x => x.IsPublic || x.IsAssembly));

        var adam = Adam.GetInstance();
        var eve = Eve.GetInstance(adam);
        Assert.Throws<ArgumentNullException>(() => new Male("Seth", null, null));
        Assert.Throws<ArgumentNullException>(() => new Male("Abel", eve, null));
        Assert.Throws<ArgumentNullException>(() => new Male("Seth", null, adam));
        Assert.Throws<ArgumentNullException>(() => new Female("Azura", null, null));
        Assert.Throws<ArgumentNullException>(() => new Female("Awan", eve, null));
        Assert.Throws<ArgumentNullException>(() => new Female("Dina", null, adam));
        Assert.Throws<ArgumentNullException>(() => new Female("Eve", null, null));
        Assert.Throws<ArgumentNullException>(() => new Male("Adam", null, null));
    }
}