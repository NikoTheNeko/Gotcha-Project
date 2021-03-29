using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadsheetManager : MonoBehaviour
{
    public GameObject spreadSheetCell; //Reference to spreadSheetCell prefab. Used to create spreadsheet cells
    public GameObject spreadSheet; //Reference to object cells are assigned to be the child of, this way there arent a million cells in the scene view
    public int spreadSheetHeight; //Height of spreadsheet in pixels
    public int spreadSheetWidth; //Width of spreadsheet in pixels
    public int rows; //number of rows
    public int cols; //number of collumns
    public float xOffset;
    public float yOffset;
    public int maxActiveCells; //number of cells to be set to active when there are no active cells
    private GameObject[,] cells; //Array of spread sheet cells

    //Size of a spreadsheet cell in pixels
    private int cellHeight;
    private int cellWidth;
    private int numberOfActiveCells;

    private Vector2 rng; //Used to randomly select cells
    private RaycastHit2D rayHit; //Used to detect what cell the mouse is hovering over

    //private static GameObject PointsTrackerObject;

    private void Awake()
    {
        //PointsTrackerObject = GameObject.Find("PointsTracker");
    }

    void Start()
    {
        spreadSheet.transform.localPosition = new Vector2(xOffset, yOffset);
        //Calculate size of each cell
        cellHeight = spreadSheetHeight / rows;
        cellWidth = spreadSheetWidth / cols;

        cells = new GameObject[rows, cols];

        //These values are used to make sure spreadsheet is centered on x axis, and starts at the bottom of the screen
        int startX = -960;
        int startY = -540 + spreadSheetHeight - cellHeight;
        int centerXOffset = (1920 - (cellWidth * cols)) / 2;

        //Populates cells array
        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < cols; j++)
            {
                cells[i, j] = Instantiate(spreadSheetCell);
                cells[i, j].GetComponent<SpreadsheetCell>().pos = new Vector2(i, j);
                cells[i, j].transform.SetParent(spreadSheet.transform);
                cells[i, j].transform.localScale = new Vector3(cellWidth, cellHeight, 1);
                cells[i, j].transform.localPosition = new Vector2(startX + (cellWidth*j) + (centerXOffset), startY - (cellHeight * i));
            }
        }

        TurnOnCells(maxActiveCells);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            rayHit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector2.zero);
            //If the mouse is hovering over a cell
            if(rayHit.collider != null && rayHit.collider.GetComponent<SpreadsheetCell>())
            {
                //If the cell is active
                if (rayHit.collider.GetComponent<SpreadsheetCell>().isActive())
                {
                    rayHit.collider.GetComponent<SpreadsheetCell>().SetActive(false);
                    numberOfActiveCells -= 1;
                    if (numberOfActiveCells == 0)
                        TurnOnCells(maxActiveCells);
                    //PointsTrackerObject.GetComponent<PointsTracker>().AddPoints(100);
                    PersistentData.instance.AddPoints(100);
                }  
                //Debug.Log("Clicked on cell " + rayHit.collider.GetComponent<SpreadsheetCell>().pos);
            }
        }
    }

    //Randomly selects n number of cells to be set to active
    private void TurnOnCells(int n)
    {
        for(int i = 0; i < n; i++)
        {
            //Randomly picks a cell
            rng.x = Random.Range(0, cols - 1);
            rng.y = Random.Range(0, rows - 1);
            //Ensures that the same cell won't be chosen twice
            while (cells[(int)rng.y, (int)rng.x].GetComponent<SpreadsheetCell>().isActive())
            {
                rng.x = Random.Range(0, cols - 1);
                rng.y = Random.Range(0, rows - 1);
            }
            cells[(int)rng.y, (int)rng.x].GetComponent<SpreadsheetCell>().SetActive(true);
        }
        numberOfActiveCells = n;
    }
}
