using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PointsDisplayText : MonoBehaviour{
    public Text PointChecky;
    private static GameObject PointsTrackerObject;

    private void Awake() {
        PointsTrackerObject = GameObject.Find("PointsTracker");
    }

    // Update is called once per frame
    void Update(){
        PointChecky.text = "Points: " + PointsTrackerObject.GetComponent<PointsTracker>().GetPoints().ToString();
    }
}
