using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : ProcessingLite.GP21
{
    GameCell[,] cells; //Our game grid matrix
    float cellSize = 0.25f; //Size of our cells
    public int numberOfColums, numberOfRows;
    int spawnChancePercentage = 5;

    void Start()
    {
        //Lower framerate makes it easier to test and see whats happening.
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        //Calculate our grid depending on size and cellSize
        numberOfColums = (int)Mathf.Floor(Width / cellSize);
        numberOfRows = (int)Mathf.Floor(Height / cellSize);

        //Initiate our matrix array
        cells = new GameCell[numberOfColums, numberOfRows];

        //Create all objects

        //For each row
        for (int y = 0; y < numberOfRows; y++)
        {
            //for each column in each row
            for (int x = 0; x < numberOfColums; x++)
            {
                //Create our game cell objects, multiply by cellSize for correct world placement
                cells[x, y] = new GameCell(x * cellSize, y * cellSize, cellSize);

                //Random check to see if it should be alive
                if (UnityEngine.Random.Range(0, 100) < spawnChancePercentage)
                {
                    cells[x, y].alive = true;
                }
            }
        }
        
    }


    void Update()
    {
        //Clear screen
        Background(0);

        GameCell[,] _cells = cells;

        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x= 0; x < numberOfColums; x++)
            {
                CheckNeighbour(x, y);
                if (CheckNeighbour(x, y)) _cells[x, y].alive = true;
                else _cells[x, y].alive = false;
            }
        }
        cells = _cells;
        //TODO: Calculate next generation



        //TODO: update buffer



        //Draw all cells.
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
                //Draw current cell
                cells[x, y].Draw();
            }
        }
    }
    bool CheckNeighbour(int posX, int posY)
    {
        int Check = 0;
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {

                if (y == 0 && x == 0) continue;
                try
                {
                    if (cells[posX + x, posY + y].alive)
                    {
                        Check++;
                    }
                }
                catch(IndexOutOfRangeException e)
                {
                    Debug.Log((posX+ x) + " : " + (posY + y));
                    continue;
                }
            }
        }
        Debug.Log(Check);
        if (Check == 3) { return true; }
        if (Check == 2 && cells[posX,posY].alive) { return true; }
        else { return false; }
    }

}

//You will probebly need to keep track of more things in this class
public class GameCell : ProcessingLite.GP21
{
    float x, y; //Keep track of our position
    float size; //our size

    //Keep track if we are alive
    public bool alive = false;

    //Constructor
    public GameCell(float x, float y, float size)
    {
        //Our X is equal to incoming X, and so forth
        //adjust our draw position so we are centered
        this.x = x + size / 2;
        this.y = y + size / 2;

        //diameter/radius draw size fix
        this.size = size / 2;
    }

    public void Draw()
    {
        //If we are alive, draw our dot.
        if (alive)
        {
            //draw our dots
            Circle(x, y, size);
        }
    }
}
