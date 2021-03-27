using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollManager : MonoBehaviour
{
    [Header("Confirm Roll UI")]
    public GameObject confirmCanvas;
    public ConfirmRollUI confirmRollUI;

    [Header("Insufficient Points UI")]
    public GameObject insufficientCanvas;
    public InsufficientPointsUI insufficientUI;

    private void Start()
    {
        confirmCanvas.SetActive(false);
        insufficientCanvas.SetActive(false);
    }

    public void CheckPoints()
    {
        if (PersistentData.instance.GetPoints() < 999)
        {
            insufficientUI.UpdateInsufficientText();
            insufficientCanvas.SetActive(true);
        }
        else
        {
            confirmRollUI.UpdateConfirmRollText();
            confirmCanvas.SetActive(true);
        }
    }
}
