using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadsheetFiller : MonoBehaviour
{
    public GameObject spreadSheetCell;
    public GameObject spreadSheet;
    public int spreadSheetHeight;
    public int spreadSheetWidth;
    public int rows;
    public int cols;
    public GameObject[,] cells;

    private int cellHeight;
    private int cellWidth;
    // Start is called before the first frame update
    void Start()
    {
        cellHeight = spreadSheetHeight / rows;
        cellWidth = spreadSheetWidth / cols;
        Debug.Log(spreadSheetCell.transform.localScale.x + "," + spreadSheetCell.transform.localScale.y);
        cells = new GameObject[rows, cols];

        int startX = -960;
        int startY = -540 + spreadSheetHeight - cellHeight;
        int centerXOffset = (1920 - (cellWidth * cols)) / 2;

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                cells[i, j] = Instantiate(spreadSheetCell);
                cells[i, j].transform.SetParent(spreadSheet.transform);
                cells[i, j].transform.localScale = new Vector3(cellWidth, cellHeight, 1);
                cells[i, j].transform.localPosition = new Vector2(startX + (cellWidth*j) + (centerXOffset), startY - (cellHeight * i));
            }
        }


       // cells[0,0] = Instantiate(spreadSheetCell);
        //cells[0, 0].transform.SetParent(spreadSheet.transform);
        //cells[0, 0].transform.localScale = new Vector3(cellWidth, cellHeight, 1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
