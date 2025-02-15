using System.Collections.Generic;
using UnityEngine;

public class Dictionary : MonoBehaviour
{
    private readonly List<string> words = new();

    private void Awake()
    {
        InitializeDictionary();
    }

    private void InitializeDictionary()
    {
        // Frutas
        words.Add("Apple");
        words.Add("Banana");
        words.Add("Orange");
        words.Add("Strawberry");
        words.Add("Grape");
        words.Add("Watermelon");
        words.Add("Pineapple");
        words.Add("Mango");
        words.Add("Papaya");
        words.Add("Cherry");

        // Verduras
        words.Add("Carrot");
        words.Add("Tomato");
        words.Add("Potato");
        words.Add("Lettuce");
        words.Add("Cucumber");
        words.Add("Broccoli");
        words.Add("Spinach");
        words.Add("Onion");
        words.Add("Pepper");
        words.Add("Corn");
    }

    public string GetRandomWord()
    {
        if (words.Count > 0)
        {
            return words[Random.Range(0, words.Count)];
        }

        return "No hay palabras disponibles.";
    }
}