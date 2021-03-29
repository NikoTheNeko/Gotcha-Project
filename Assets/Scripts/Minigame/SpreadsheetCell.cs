using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpreadsheetCell : MonoBehaviour
{
    public TextMeshProUGUI text;
    private bool active = false;
    public Vector2 pos; //x = row, y = collumn
    private void Awake()
    {
        text = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        text.transform.localScale = new Vector2(0.5f, 1);
        text.rectTransform.rect.Set(text.rectTransform.rect.x, text.rectTransform.rect.y, text.rectTransform.rect.width * 2, text.rectTransform.rect.height);
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
