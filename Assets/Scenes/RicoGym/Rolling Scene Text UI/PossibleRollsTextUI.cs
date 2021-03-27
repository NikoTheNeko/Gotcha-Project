using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PossibleRollsTextUI : MonoBehaviour
{
    public Text possibleRollsText;

    private void Start()
    {
        UpdatePossibleRollsText();
    }

    public void UpdatePossibleRollsText()
    {
        string newText = "Possible Rolls:\n\n";

        foreach (var character in PersistentData.instance.characterDatabase.GetComponent<CharacterDatabase>().database)
        {
            if (!character.owned)
            {
                newText += (character.id + 1) + ". " + character.name + "\n";
            }
        }

        possibleRollsText.text = newText;
    }
}
