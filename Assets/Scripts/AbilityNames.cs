using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[System.Serializable]
public class Ability
{
    public string abilityName;
}

[System.Serializable]
public class CharacterClass
{
    public string className;
    public List<Ability> firstAbility;
    public List<Ability> secondAbility;
    public List<Ability> ultimate;
}

[System.Serializable]
public class ClassesContainer
{
    public List<CharacterClass> classes;
}

public class AbilityNames : MonoBehaviour
{
    static public List<string> firstAbilities = new List<string>();
    static public List<string> secondAbilities = new List<string>();
    static public List<string> ultimates = new List<string>();
    static public string className = "Paladyn"; // Paladyn as default class
    static public string firstAbilityName;
    static public string secondAbilityName;
    static public string ultimateName;

    public TMP_Dropdown classDropdown;

    static public void LoadAbilities(string className)
    {
        // Read JSON file
        TextAsset jsonFile = Resources.Load<TextAsset>("abilities"); // Make sure to place your JSON file in a "Resources" folder
        if (jsonFile == null)
        {
            Debug.LogError("Unable to load JSON file.");
            return;
        }

        // Deserialize JSON using Unity's JsonUtility
        ClassesContainer classesContainer = JsonUtility.FromJson<ClassesContainer>(jsonFile.text);

        // Find the specified class
        CharacterClass characterClass = classesContainer.classes.Find(c => c.className == className);

        if (characterClass != null)
        {
            // Assign values to firstAbilities and secondAbilities lists
            firstAbilities = characterClass.firstAbility.ConvertAll(ability => ability.abilityName);
            secondAbilities = characterClass.secondAbility.ConvertAll(ability => ability.abilityName);
            ultimates = characterClass.ultimate.ConvertAll(ability => ability.abilityName);

            // Display the results
            Debug.Log($"Class: {className}");
            Debug.Log("First Abilities:");
            foreach (var ability in firstAbilities)
            {
                Debug.Log($"- {ability}");
            }
            Debug.Log("Second Abilities:");
            foreach (var ability in secondAbilities)
            {
                Debug.Log($"- {ability}");
            }
            foreach (var ability in ultimates)
            {
                Debug.Log($"- {ability}");
            }
        }
        else
        {
            Debug.LogError($"Class '{className}' not found in the JSON file.");
        }
    }

    public void ChooseAbilitiesScene()
    {
        className = classDropdown.options[classDropdown.value].text;
        LoadAbilities(className);
        SceneManager.LoadScene(1);
    }
}
