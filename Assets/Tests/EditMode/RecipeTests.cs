using NUnit.Framework;
using Potions2026.DataStructures;
using Potions2026.DataStructures.Enums;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class RecipeTests
{
    [Test]
    public void AllRecipesHaveNames()
    {
        //Assign
        List<PotionRecipe> recipes = GetAllRecipeScriptableObjects();

        //Act
        bool allRecipesHaveNames = true;
        foreach (PotionRecipe recipe in recipes)
        {
            if (recipe.Name == string.Empty)
            {
                allRecipesHaveNames = false;
                Debug.LogWarning($"'{recipe.name}' asset has no name.");
            }
        }

        //Assert
        Assert.IsTrue(allRecipesHaveNames);
    }

    [Test]
    public void NoDuplicateRecipeNames()
    {
        //Assign
        List<PotionRecipe> recipes = GetAllRecipeScriptableObjects();

        //Act
        bool noDuplicateRecipeNames = true;
        for (int i = 0; i < recipes.Count; i++)
        {
            for (int j = i + 1; j < recipes.Count; j++)
            {
                if (recipes[i].Name == recipes[j].Name)
                {
                    noDuplicateRecipeNames = false;
                    Debug.LogWarning($"'{recipes[i].name}' asset and '{recipes[j].name}' have the same name.");
                }
            }
        }

        //Assert
        Assert.IsTrue(noDuplicateRecipeNames);
    }

    [Test]
    public void AllRecipesHaveDescriptions()
    {
        //Assign
        List<PotionRecipe> recipes = GetAllRecipeScriptableObjects();

        //Act
        bool allRecipesHaveDescriptions = true;
        foreach (PotionRecipe recipe in recipes)
        {
            if (recipe.Description == string.Empty)
            {
                allRecipesHaveDescriptions = false;
                Debug.LogWarning($"'{recipe.name}' asset has no descriptions.");
            }
        }

        //Assert
        Assert.IsTrue(allRecipesHaveDescriptions);
    }

    [Test]
    public void NoDuplicateRecipeDescriptions()
    {
        //Assign
        List<PotionRecipe> recipes = GetAllRecipeScriptableObjects();

        //Act
        bool noDuplicateRecipeDescriptions = true;
        for (int i = 0; i < recipes.Count; i++)
        {
            for (int j = i + 1; j < recipes.Count; j++)
            {
                if (recipes[i].Description == recipes[j].Description)
                {
                    noDuplicateRecipeDescriptions = false;
                    Debug.LogWarning($"'{recipes[i].name}' asset and '{recipes[j].name}' have the same description.");
                }
            }
        }

        //Assert
        Assert.IsTrue(noDuplicateRecipeDescriptions);
    }

    [Test]
    public void AllRecipesAreValid()
    {
        //Assign
        List<PotionRecipe> recipes = GetAllRecipeScriptableObjects();

        //Act
        bool allRecipesAreValid = true;
        foreach (PotionRecipe recipe in recipes)
        {
            if (recipe.EssenceRequirements.Contains(IngredientEssenceType.INVALID))
            {
                allRecipesAreValid = false;
                Debug.LogWarning($"'{recipe.name}' has IngredientEssenceType.INVALID as an ingredient.");
            }
        }

        //Assert
        Assert.IsTrue(allRecipesAreValid);
    }

    [Test]
    public void NoDuplicateEssenceRequirements()
    {
        //Assign
        List<PotionRecipe> recipes = GetAllRecipeScriptableObjects();

        //Act
        bool noDuplicateEssenceRequirements = true;
        for (int i = 0; i < recipes.Count; i++)
        {
            for (int j = i + 1; j < recipes.Count; j++)
            {
                if (recipes[i].EssenceRequirements.SequenceEqual(recipes[j].EssenceRequirements))
                {
                    noDuplicateEssenceRequirements = false;
                    Debug.LogWarning($"'{recipes[i].name}' asset and '{recipes[j].name}' have the same essence requirements.");
                }
            }
        }

        //Assert
        Assert.IsTrue(noDuplicateEssenceRequirements);
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
