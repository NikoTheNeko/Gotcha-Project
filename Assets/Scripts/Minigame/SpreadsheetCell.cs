using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpreadsheetCell : MonoBehaviour
{
    public Text text;
    private bool active = false;
    public Vector2 pos; //x = row, y = collumn
    private void Awake()
    {
        text = transform.GetChild(0).GetChild(0).GetComponent<Text>();
        text.text = "";
    }
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

    /*
    private void OnMouseDown()
    {
        if(active)
        {
            active = false;
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    */

    public void SetActive(bool active)
    {
        this.active = active;
        if(active)
        {
            text.text = "Bitch";
            GetComponent<SpriteRenderer>().color = Color.cyan;
        }
            
        else
        {
            text.text = "";
            GetComponent<SpriteRenderer>().color = Color.white;
        }
            
    }

    public bool isActive()
    {
        return active;
    }
}
