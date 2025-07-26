using NUnit.Framework;
using System.Linq;
using TMPro;
using UnityEngine;
using System.Collections.Generic;

public class Dropdown_Manager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    public GameObject continueButton;
    public TMP_Text list;
    public List<string> options;

    private void Update()
    {
        if (options.Count == 0)
        {
            continueButton.SetActive(false);
        }
        else
        {
            continueButton.SetActive(true);
        }
    }
    public void SelectMenuOption()
    {
        if (dropdown.value == 0)
        {
            return; // No option selected
        }
        int selectedValue = dropdown.value;
        string selectedOption = dropdown.options[selectedValue].text;
        options.Add(selectedOption);
        int index = options.Count;
        list.text = list.text + "\n" + index.ToString() + ". " + selectedOption;
        int indexToRemove = selectedValue;
        dropdown.options.RemoveAt(indexToRemove);
        dropdown.value = 0;
    }

    public void deleteMenuOption()
    {
        int valueToDelete = options.Count - 1;
        if (valueToDelete < 0)
        {
            return; // No options to delete
        }
        string optionToDelete = options[valueToDelete];
        dropdown.options.Add(new TMP_Dropdown.OptionData(optionToDelete, null, color:Color.white));
        options.RemoveAt(valueToDelete);
        list.text = list.text.Replace("\n" + (valueToDelete + 1).ToString() + ". " + optionToDelete, "");
    }
}

