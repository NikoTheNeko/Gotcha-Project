using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadsheetCell : MonoBehaviour
{
    private bool active = false;
    private void OnMouseEnter()
    {
        if(!active)
            GetComponent<SpriteRenderer>().color = Color.gray;
        else
            GetComponent<SpriteRenderer>().color = Color.blue;
    }
    private void OnMouseExit()
    {
        if (!active)
            GetComponent<SpriteRenderer>().color = Color.white;
        else
            GetComponent<SpriteRenderer>().color = Color.cyan;
    }

    private void OnMouseDown()
    {
        if(active)
        {
            active = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    public void SetActive()
    {
        active = true;
        GetComponent<SpriteRenderer>().color = Color.cyan;
    }
}
