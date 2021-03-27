using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InsufficientPointsUI : MonoBehaviour
{
    public Text insufficientText;

    public void UpdateInsufficientText()
    {
        insufficientText.text = "Insufficient Queso Points! You only have " + PersistentData.instance.GetPoints() + " points.";
    }
}
