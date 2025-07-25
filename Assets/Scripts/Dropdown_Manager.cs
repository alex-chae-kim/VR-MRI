using TMPro;
using UnityEngine;

public class Dropdown_Manager
{
    [SerializeField] private TMP_Dropdown dropdown;

    public void GetDropdownValue()
    {
        int selectedValue = dropdown.value;
        string selectedOption = dropdown.options[selectedValue].text;
        Debug.Log("Selected Dropdown Value: " + selectedValue);
    }
}

