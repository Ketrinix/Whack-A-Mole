using TMPro;
using UnityEngine;

public class Chart : MonoBehaviour
{
    public Dictionary dictionary;
    public TextMeshProUGUI chartText;

    private void Start()
    {
        if (dictionary != null && chartText != null)
        {
            string word = dictionary.GetRandomWord();

            chartText.text = ReplaceVowels(word);
        }
    }

    private string ReplaceVowels(string word)
    {
        string vowels = "AEIOUaeiou";  // Vocales a reemplazar

        foreach (char vowel in vowels)
        {
            word = word.Replace(vowel, '_');
        }

        return word;
    }
}