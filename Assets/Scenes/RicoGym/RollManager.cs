using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollManager : MonoBehaviour
{
    [Header("Main Screen UI")]
    public PointsTextUI pointsText;
    public PossibleRollsTextUI possibleRolls;

    [Header("Confirm Roll UI")]
    public GameObject confirmCanvas;
    public ConfirmRollTextUI confirmRoll;

    [Header("Insufficient Points UI")]
    public GameObject insufficientCanvas;
    public InsufficientPointsTextUI insufficient;

    [Header("Character Rolled UI")]
    public GameObject characterRolledCanvas;
    public CharacterRolledTextUI characterRolled;

    [Header("No More Characters UI")]
    public GameObject noMoreCharactersCanvas;

    private void Start()
    {
        //------------------
        // hide all popups
        //------------------
        confirmCanvas.SetActive(false);
        insufficientCanvas.SetActive(false);
        characterRolledCanvas.SetActive(false);
        noMoreCharactersCanvas.SetActive(false);
    }

    public void CheckPoints()
    {
        //----------------------------------------------------
        // check if there's anymore characters to roll first
        //----------------------------------------------------
        if (PersistentData.instance.characterDatabase.GetComponent<CharacterDatabase>().CheckUnrolled())
        {
            //-------------------------------------------------------
            // all characters owned, show no more characters canvas
            //-------------------------------------------------------
            noMoreCharactersCanvas.SetActive(true);
            return;
        }

        if (PersistentData.instance.GetPoints() < 999)
        {
            //---------------------------------
            // insufficient points for a roll
            //---------------------------------
            insufficient.UpdateInsufficientText();
            insufficientCanvas.SetActive(true);
        }
        else
        {
            //----------------------------------------
            // good for a roll, ask for confirmation
            //----------------------------------------
            confirmRoll.UpdateConfirmRollText();
            confirmCanvas.SetActive(true);
        }
    }

    public void Roll()
    {
        //-----------------------------------------
        // do the roll and disable confirm screen
        //-----------------------------------------
        Character rolled = PersistentData.instance.characterDatabase.GetComponent<CharacterDatabase>().Roll();
        confirmCanvas.SetActive(false);

        //----------------------------------------------------------------
        // show what character was rolled and update text on main screen
        //----------------------------------------------------------------
        characterRolledCanvas.SetActive(true);
        characterRolled.UpdateCharacterRolledText(rolled);
        pointsText.UpdatePointsText();
        possibleRolls.UpdatePossibleRollsText();
    }
}
