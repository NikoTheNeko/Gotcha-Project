using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmRollTextUI : MonoBehaviour
{
    public Text confirmRollText;

    public void UpdateConfirmRollText()
    {
        confirmRollText.text = "You will spend 1 Roll (<color=#e9a84a>999</color> Queso Points). You currently have <color=#1ba11b>" + 
            PersistentData.instance.GetPoints() + "</color> Queso Points and will have <color=#b42929>" + 
            PersistentData.instance.CheckUpdatedTotal(-999) + "</color> Queso Points. Do you wish to proceed?";
    }
}
