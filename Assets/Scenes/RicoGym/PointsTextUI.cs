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
        pointsText.text = "Queso Points: " + PersistentData.instance.GetPoints();
    }
}
