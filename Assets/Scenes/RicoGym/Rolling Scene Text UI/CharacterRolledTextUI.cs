using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterRolledTextUI : MonoBehaviour
{
    public Text characterRolledText;

    public void UpdateCharacterRolledText(Character character)
    {
        characterRolledText.text = "You rolled <b>" + character.name + "</b>!";
    }
}
