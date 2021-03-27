using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsufficientPointsUI : MonoBehaviour
{
    public Text insufficientPointsText;

    public void UpdateInsufficientText()
    {
        insufficientPointsText.text = "Insufficient Queso Points! You only have " + PersistentData.instance.GetPoints() + " points.";
    }
}
