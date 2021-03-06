﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathGrid : MonoBehaviour {

    [SerializeField] int number;
    float lastFall = 0;

    void Start()
    {
        // If the default is not valid, that means the grids has reach the top
        // Which means game over
        if (!isValidGridPos())
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            LeftMove();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            RightMove();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            Rotation();
        }

        // The Fall function will be updated by time
        if (Input.GetKeyDown(KeyCode.S) || Time.deltaTime - lastFall >= 1)
        {
            Fall();
        }
    }

    // LeftMove:
    // Use keyboard to control the block move to left
    private void LeftMove()
    {

        transform.position += new Vector3(-1, 0, 0);

        if (isValidGridPos())
        {
            UpdateGrid();
        }

        else
        {
            transform.position += new Vector3(1, 0, 0);
        }
    }

    private void RightMove()
    {

        transform.position += new Vector3(1, 0, 0);

        if (isValidGridPos())
        {
            UpdateGrid();
        }

        else
        {
            transform.position += new Vector3(-1, 0, 0);
        }
    }

    private void Rotation()
    {
        transform.Rotate(0, 0, -90);

        if (isValidGridPos())
        {
            UpdateGrid();
        }

        else
        {
            transform.Rotate(0, 0, 90);
        }
    }

    private void Fall()
    {
        // Move downwards
        transform.position += new Vector3(0, -1, 0);


        if (isValidGridPos())
        {
            UpdateGrid();
        }

        else
        {
            transform.position += new Vector3(0, 1, 0);

            // Clean the full rows
            Grid.DeleteFullRows();

            // Spawn next shape
            FindObjectOfType<Spawner>().SpawnNext();

            // Disable the script of the obj, since it needs to be stop from controlling
            enabled = false;
        }
        lastFall = Time.deltaTime;
    }

    public bool isValidGridPos()
    {
        foreach (Transform child in transform)
        {
            Vector2 pos = Grid.RoundPosition(child.position);

            // detect if the grid is inside border or not
            if (!Grid.InsideBoarder(pos))
            {
                return false;
            }

            // Used in rotation: find the grid that is in the position already.
            // If there is a grid that at the position, return false.
            if (Grid.grid[(int)pos.x, (int)pos.y] != null &&
                Grid.grid[(int)pos.x, (int)pos.y].parent != transform)
            {
                return false;
            }

            // Add if the 
        }
        return true;
    }

    // UpdataGrid:
    // update all grids that belongs to a certain shape.
    void UpdateGrid()
    {
        // Remove old children from grid
        for (int x = 0; x < Grid.width; ++x)
        {
            for (int y = 0; y < Grid.height; ++y)
            {
                if (Grid.grid[x, y] != null) // if has a grid
                {
                    if (Grid.grid[x, y].parent == transform) // if the parent is the shape
                    {
                        Grid.grid[x, y] = null;
                    }
                }
            }
        }

        // put new grid to the position
        foreach (Transform child in transform)
        {
            Vector2 pos = Grid.RoundPosition(child.position);
            Grid.grid[(int)pos.x, (int)pos.y] = child;
        }
    }


}
