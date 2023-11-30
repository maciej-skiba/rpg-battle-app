using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    static public Abilities Instance { get; private set; }

    [SerializeField]
    private Button[] abilityButtons;
    [SerializeField]
    private TextMeshProUGUI[] cooldownText;
    [SerializeField]
    private Button ultimateButton;
    private int[] abilityRemainingCds = new int[2];

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        abilityButtons[0].GetComponentInChildren<TextMeshProUGUI>().text = AbilityNames.firstAbilityName;
        abilityButtons[1].GetComponentInChildren<TextMeshProUGUI>().text = AbilityNames.secondAbilityName;
        ultimateButton.GetComponentInChildren<TextMeshProUGUI>().text = AbilityNames.ultimateName;
    }

    static public void UseAbility(int abilityIndex)
    {
        if (Instance.abilityRemainingCds[abilityIndex] <= 0)
        {
            print($"Ability {abilityIndex} used.");
            Instance.abilityRemainingCds[abilityIndex] = 3;
            Instance.cooldownText[abilityIndex].text = "Cooldown: 3";
            Instance.abilityButtons[abilityIndex].interactable = false;
        }
    }

    static public void UseUltimate()
    {
        Instance.ultimateButton.interactable = false;
    }

    static public void NewTurn()
    {
        UpdateAbilityCd(abilityIndex: 0);
        UpdateAbilityCd(abilityIndex: 1);
        UpdateAbilityButton(abilityIndex: 0);
        UpdateAbilityButton(abilityIndex: 1);
    }

    static public void NewFight()
    {
        UpdateAbilityCd(abilityIndex: 0, resetCd: true);
        UpdateAbilityCd(abilityIndex: 1, resetCd: true);
        Instance.ultimateButton.interactable = true;
    }

    static private void UpdateAbilityCd(int abilityIndex, bool resetCd = false)
    {
        if (resetCd || Instance.abilityRemainingCds[abilityIndex] == 1) 
        { 
            Instance.abilityRemainingCds[abilityIndex] = 0;
            Instance.abilityButtons[abilityIndex].interactable = true;
            Instance.cooldownText[abilityIndex].text = string.Empty;
        }
        else if (Instance.abilityRemainingCds[abilityIndex] >= 2)
        {
            Instance.abilityRemainingCds[abilityIndex]--;
            Instance.cooldownText[abilityIndex].text = "Cooldown: " + Instance.abilityRemainingCds[abilityIndex].ToString();
        }
    }

    static private void UpdateAbilityButton(int abilityIndex)
    {
        if (Instance.abilityRemainingCds[abilityIndex] == 0)
        {
            Instance.abilityButtons[abilityIndex].interactable = true;
        }
    }
}
