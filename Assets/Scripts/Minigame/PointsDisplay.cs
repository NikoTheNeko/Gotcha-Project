using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsDisplay : MonoBehaviour
{
    private static GameObject PointsTrackerObject;

    private void Awake()
    {
        PointsTrackerObject = GameObject.Find("Point Tracker");
    }

    private void Update()
    {
        //PointChecky.text = "Points: " + PointsTrackerObject.GetComponent<PointsTracker>().GetPoints().ToString();
        GetComponent<Text>().text = "Points: " + PointsTrackerObject.GetComponent<PointsTracker>().GetPoints().ToString();
    }
}
