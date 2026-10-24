using NUnit.Framework;
using Potions2026.DataStructures;
using Potions2026.DataStructures.Enums;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EssenceProfileTests
{
    [Test]
    public void ReturnsValidPotionRecipe()
    {
        //Assign
        RecipeData[] allRecipes = GetAllRecipeScriptableObjects();
        EssenceProfile essenceProfile = new EssenceProfile();

        //Act
        RecipeData testRecipe = allRecipes[0];
        Debug.Log($"Testing using {testRecipe.Name} recipe.");

        EssenceType[] essenceRequirements = testRecipe.EssenceRequirements;
        foreach (EssenceType essence in essenceRequirements)
        {
            Debug.Log($"{essence} added.");
            essenceProfile.AddEssence(essence);
        }

        RecipeData returnedRecipe = essenceProfile.Brew(allRecipes);
        bool returnedRecipeIsExpected = returnedRecipe == testRecipe;
        Debug.Log($"Test recipe is {testRecipe.Name}, returned recipe is {returnedRecipe.Name}.");

        //Assert
        Assert.IsTrue(returnedRecipeIsExpected);
    }

    [Test]
    public void ReturnsNullPotionRecipe()
    {
        //Assign
        RecipeData[] allRecipes = GetAllRecipeScriptableObjects();
        EssenceProfile essenceTracker = new EssenceProfile();

        //Act
        essenceTracker.AddEssence(EssenceType.INVALID);
        RecipeData returnedRecipe = essenceTracker.Brew(allRecipes);
        bool returnedRecipeIsNull = returnedRecipe == null;

        //Assert
        Assert.IsTrue(returnedRecipeIsNull);
    }

    private RecipeData[] GetAllRecipeScriptableObjects()
    {
        string[] guids = AssetDatabase.FindAssets("t:PotionRecipe");

        List<RecipeData> recipes = new();
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            recipes.Add(AssetDatabase.LoadAssetAtPath<RecipeData>(path));
        }

        return recipes.ToArray();
    }
}
