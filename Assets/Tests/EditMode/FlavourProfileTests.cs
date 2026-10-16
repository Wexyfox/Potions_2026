using NUnit.Framework;
using Potions2026.DataStructures;
using Potions2026.DataStructures.Enums;
using System;
using System.Linq;

public class FlavourProfileTests
{
    [Test]
    public void MeetsValidQueryProfile()
    {
        //Assign
        FlavourProfile testingProfile = new FlavourProfile();
        FlavourProfile queryProfile = new FlavourProfile();

        //Act
        FlavourType[] allFlavours = Enum.GetValues(typeof(FlavourType)).Cast<FlavourType>().ToArray();
        foreach (FlavourType flavour in allFlavours)
        {
            testingProfile.AddFlavour(flavour);
            queryProfile.AddFlavour(flavour);
        }
        bool testProfileMeetsQueryProfile = testingProfile.MeetsFlavourProfile(queryProfile);

        //Assert
        Assert.IsTrue(testProfileMeetsQueryProfile);
    }

    [Test]
    public void DoesntMeetInvalidQueryProfile()
    {
        //Assign
        FlavourProfile testingProfile = new FlavourProfile();
        FlavourProfile queryProfile = new FlavourProfile();

        //Act
        FlavourType[] allFlavours = Enum.GetValues(typeof(FlavourType)).Cast<FlavourType>().ToArray();
        foreach (FlavourType flavour in allFlavours)
        {
            queryProfile.AddFlavour(flavour);
        }

        bool testProfileDoesntMeetQueryProfile = !testingProfile.MeetsFlavourProfile(queryProfile);

        //Assert
        Assert.IsTrue(testProfileDoesntMeetQueryProfile);
    }
}
