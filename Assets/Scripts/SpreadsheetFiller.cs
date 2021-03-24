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

    private Vector2 mousePos;

    private Vector2 rng;

    int numberOfActiveCells;
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

        for(int i = 0; i < 3; i++)
        {
            rng.x = Random.Range(0, cols - 1);
            rng.y = Random.Range(0, rows - 1);
            cells[(int)rng.x, (int)rng.y].GetComponent<SpreadsheetCell>().SetActive();

        }


        // cells[0,0] = Instantiate(spreadSheetCell);
        //cells[0, 0].transform.SetParent(spreadSheet.transform);
        //cells[0, 0].transform.localScale = new Vector3(cellWidth, cellHeight, 1);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log(mousePos.x + "," + mousePos.y);
            Debug.Log(cells[0, 0].transform.position);
        }
    }
}
