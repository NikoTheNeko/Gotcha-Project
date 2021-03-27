using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmRollUI : MonoBehaviour
{
    public Text confirmRollText;

    public void UpdateConfirmRollText()
    {
        confirmRollText.text = "You will spend 1 Roll (999 Queso Points). You currently have " + 
            PersistentData.instance.GetPoints() + " Queso Points and will have " + 
            PersistentData.instance.CheckUpdatedTotal(-999) + " Queso Points. Do you wish to proceed?";
    }
}
