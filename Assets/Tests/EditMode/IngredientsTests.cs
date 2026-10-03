using NUnit.Framework;
using Potions2026.DataStructures;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IngredientsTests
{
    [Test]
    public void AllIngredientsHaveNames()
    {
        //Assign
        List<IngredientData> ingredients = GetAllIngredientScriptableObjects();

        //Act
        bool allIngredientsHaveNames = true;
        foreach (IngredientData ingredient in ingredients)
        {
            if (ingredient.Name == string.Empty)
            {
                allIngredientsHaveNames = false;
                Debug.LogWarning($"'{ingredient.name}' asset has no name.");
            }
        }

        //Assert
        Assert.IsTrue(allIngredientsHaveNames);
    }

    [Test]
    public void NoDuplicateIngredientNames()
    {
        //Assign
        List<IngredientData> ingredients = GetAllIngredientScriptableObjects();

        //Act
        bool noDuplicateIngredientNames = true;
        for (int i = 0; i < ingredients.Count; i++)
        {
            for (int j = i + 1; j < ingredients.Count; j++)
            {
                if (ingredients[i].Name == ingredients[j].Name)
                {
                    noDuplicateIngredientNames = false;
                    Debug.LogWarning($"'{ingredients[i].name}' asset and '{ingredients[j].name}' have the same name.");
                }
            }
        }

        //Assert
        Assert.IsTrue(noDuplicateIngredientNames);
    }

    [Test]
    public void AllIngredientsHaveDescriptions()
    {
        //Assign
        List<IngredientData> ingredients = GetAllIngredientScriptableObjects();

        //Act
        bool allIngredientsHaveDescriptions = true;
        foreach (IngredientData ingredient in ingredients)
        {
            if (ingredient.Description == string.Empty)
            {
                allIngredientsHaveDescriptions = false;
                Debug.LogWarning($"'{ingredient.name}' asset has no descriptions.");
            }
        }

        //Assert
        Assert.IsTrue(allIngredientsHaveDescriptions);
    }

    [Test]
    public void NoDuplicateIngredientDescriptions()
    {
        //Assign
        List<IngredientData> ingredients = GetAllIngredientScriptableObjects();

        //Act
        bool noDuplicateIngredientDescriptions = true;
        for (int i = 0; i < ingredients.Count; i++)
        {
            for (int j = i + 1; j < ingredients.Count; j++)
            {
                if (ingredients[i].Description == ingredients[j].Description)
                {
                    noDuplicateIngredientDescriptions = false;
                    Debug.LogWarning($"'{ingredients[i].name}' asset and '{ingredients[j].name}' have the same description.");
                }
            }
        }

        //Assert
        Assert.IsTrue(noDuplicateIngredientDescriptions);
    }

    [Test]
    public void AllIngredientsHaveEssences()
    {
        //Assign
        List<IngredientData> ingredients = GetAllIngredientScriptableObjects();

        //Act
        bool allIngredientsHaveEssence = true;
        foreach (IngredientData ingredient in ingredients)
        {
            if (!ingredient.HasEssences)
            {
                allIngredientsHaveEssence = false;
                Debug.LogWarning($"'{ingredient.name}' has no preparation essences.");
            }
        }

        //Assert
        Assert.IsTrue(allIngredientsHaveEssence);
    }

    private List<IngredientData> GetAllIngredientScriptableObjects()
    {
        string[] guids = AssetDatabase.FindAssets("t:IngredientData");

        List<IngredientData> ingredients = new();
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            ingredients.Add(AssetDatabase.LoadAssetAtPath<IngredientData>(path));
        }

        return ingredients;
    }
}
