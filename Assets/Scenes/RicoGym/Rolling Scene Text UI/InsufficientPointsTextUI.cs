using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsufficientPointsTextUI : MonoBehaviour
{
    public Text insufficientPointsText;

    public void UpdateInsufficientText()
    {
        insufficientPointsText.text = "Insufficient Queso Points! You only have <color=#b42929>" + 
            PersistentData.instance.GetPoints() + "</color> points. You need <color=#e9a84a>999</color> Queso Points.";
    }
}
