using NUnit.Framework;
using Potions2026.Cauldron;
using Potions2026.DataStructures;
using Potions2026.DataStructures.Enums;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CauldronEssenceTrackerTests
{
    [Test]
    public void ReturnsValidPotionRecipe()
    {
        //Assign
        List<PotionRecipe> allRecipes = GetAllRecipeScriptableObjects();
        CauldronEssenceTracker essenceTracker = new CauldronEssenceTracker(allRecipes);

        //Act
        PotionRecipe testRecipe = allRecipes[0];
        Debug.Log($"Testing using {testRecipe.Name} recipe.");

        IngredientEssenceType[] essenceRequirements = testRecipe.EssenceRequirements;
        foreach (IngredientEssenceType essence in essenceRequirements)
        {
            Debug.Log($"{essence} added.");
            essenceTracker.AddEssence(essence);
        }

        PotionRecipe returnedRecipe = essenceTracker.Brew();
        bool returnedRecipeIsExpected = returnedRecipe == testRecipe;
        Debug.Log($"Test recipe is {testRecipe.Name}, returned recipe is {returnedRecipe.Name}.");

        //Assert
        Assert.IsTrue(returnedRecipeIsExpected);
    }

    [Test]
    public void ReturnsNullPotionRecipe()
    {
        //Assign
        List<PotionRecipe> allRecipes = GetAllRecipeScriptableObjects();
        CauldronEssenceTracker essenceTracker = new CauldronEssenceTracker(allRecipes);

        //Act
        essenceTracker.AddEssence(IngredientEssenceType.INVALID);
        PotionRecipe returnedRecipe = essenceTracker.Brew();
        bool returnedRecipeIsNull = returnedRecipe == null;

        //Assert
        Assert.IsTrue(returnedRecipeIsNull);
    }

    private List<PotionRecipe> GetAllRecipeScriptableObjects()
    {
        string[] guids = AssetDatabase.FindAssets("t:PotionRecipe");

        List<PotionRecipe> recipes = new();
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            recipes.Add(AssetDatabase.LoadAssetAtPath<PotionRecipe>(path));
        }

        return recipes;
    }
}
