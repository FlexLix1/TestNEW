using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOfLife : ProcessingLite.GP21
{
    GameCell[,] cells; //Our game grid matrix
    float cellSize = 0.25f; //Size of our cells
    public int numberOfColums, numberOfRows;
    int spawnChancePercentage = 10;
    public Gradient fadeColor;
    void Start()
    {
        //Lower framerate makes it easier to test and see whats happening.
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;

        //Calculate our grid depending on size and cellSize
        numberOfColums = (int)Mathf.Floor(Width / cellSize);
        numberOfRows = (int)Mathf.Floor(Height / cellSize);

        //Initiate our matrix array
        cells = new GameCell[numberOfColums, numberOfRows];

        //For each row
        for (int y = 0; y < numberOfRows; y++)
        {
            //for each column in each row
            for (int x = 0; x < numberOfColums; x++)
            {
                //Create our game cell objects, multiply by cellSize for correct world placement
                cells[x, y] = new GameCell(x * cellSize, y * cellSize, cellSize, fadeColor);

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

        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
                if (CheckNeighbour(x, y)) cells[x, y].nextGeneration = true;
                else cells[x, y].nextGeneration = false;
            }
        }

        //Draw all cells.
        for (int y = 0; y < numberOfRows; y++)
        {
            for (int x = 0; x < numberOfColums; x++)
            {
                cells[x, y].alive = cells[x, y].nextGeneration;
                cells[x, y].nextGeneration = false;
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
                catch (IndexOutOfRangeException Error)
                {
                    continue;
                }
            }
        }
        if (Check < 4)
        {
            if (Check == 3) { return true; }
            if (Check == 2 && cells[posX, posY].alive) { return true; }
        }
        return false;
    }
}
//You will probebly need to keep track of more things in this class
public class GameCell : ProcessingLite.GP21
{
    Gradient fadeColor;
    Color currentColor = Color.black;
    float gradientTime = 0;
    float x, y; //Keep track of our position
    float size; //our size

    //Keep track if we are alive
    public bool alive = false;
    public bool nextGeneration = false;
    //Constructor
    public GameCell(float x, float y, float size, Gradient fadeColor)
    {
        //Our X is equal to incoming X, and so forth
        //adjust our draw position so we are centered
        this.x = x + size / 2;
        this.y = y + size / 2;
        this.fadeColor = fadeColor;
        //diameter/radius draw size fix
        this.size = size / 2;
    }
    public void Draw()
    {
        //If we are alive, draw our dot.
        if (alive)
        {
            Stroke(255, 255, 255, 255);
            Circle(x, y, size);
            currentColor = Color.white;
        } else //if (currentColor != Color.black)
        {
            gradientTime += 0.5f * Time.deltaTime;
            //if (gradientTime > 1) gradientTime = 1;

            int r = (int)Mathf.Round(fadeColor.Evaluate(gradientTime).r * 255);
            int g = (int)Mathf.Round(fadeColor.Evaluate(gradientTime).g * 255);
            int b = (int)Mathf.Round(fadeColor.Evaluate(gradientTime).b * 255);


            //Debug.Log(r + " " + g + " " + b);
            currentColor = fadeColor.Evaluate(gradientTime);

            Stroke(r, g, b);
            Circle(x, y, size);
            Stroke(0, 0, 0, 255);
        }
    }
}
