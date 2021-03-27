using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsTextUI : MonoBehaviour
{
    public Text pointsText;

    private void Start()
    {
        UpdatePointsText();
    }

    public void UpdatePointsText()
    {
        pointsText.text = "<color=#ffffff>Queso Points:</color> " + PersistentData.instance.GetPoints();
    }
}
