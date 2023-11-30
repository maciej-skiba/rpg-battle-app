using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AbilityPicker : MonoBehaviour
{
    public TMP_Dropdown firstAbilityDD;
    public TMP_Dropdown secondAbilityDD;
    public TMP_Dropdown ultimateDD;

    private void Start()
    {
        PutStringsToDropdown(AbilityNames.firstAbilities, firstAbilityDD);
        PutStringsToDropdown(AbilityNames.secondAbilities, secondAbilityDD);
        PutStringsToDropdown(AbilityNames.ultimates, ultimateDD);
    }

    public void GameScene()
    {
        AbilityNames.firstAbilityName = firstAbilityDD.options[firstAbilityDD.value].text;
        AbilityNames.secondAbilityName = secondAbilityDD.options[secondAbilityDD.value].text;
        AbilityNames.ultimateName = ultimateDD.options[ultimateDD.value].text;

        SceneManager.LoadScene(2);
    }
    private void PutStringsToDropdown(List<string> listOfStrings, TMP_Dropdown dropdown) 
    {
        // Clear existing options
        dropdown.ClearOptions();

        // Add options from the list
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        foreach (string item in listOfStrings)
        {
            options.Add(new TMP_Dropdown.OptionData(item));
        }

        // Populate the dropdown with options
        dropdown.AddOptions(options);
    }
}
