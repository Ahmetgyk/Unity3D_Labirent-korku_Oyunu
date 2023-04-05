using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField] MazeGenerator mazeGenerator;
    [SerializeField] GameObject MazeCellPrefab;
    [SerializeField] GameObject Wall;

    public float CellSize = 1f;

    void Start()
    {
        MazeCell[,] maze = mazeGenerator.GetMaze();

        for (int x = 0; x < mazeGenerator.mazeWidht; x++)
        {
            for (int y = 0; y < mazeGenerator.mazeHeight; y++)
            {
                GameObject newCell = Instantiate(MazeCellPrefab, new Vector3((float)x * CellSize, 0f, (float)y * CellSize), Quaternion.identity, transform);
                string name = "MazeCell" + x + y;
                newCell.transform.name = name;
                MazeCellObject mazeCell = newCell.GetComponent<MazeCellObject>();

                bool top = maze[x, y].topWall;
                bool left = maze[x, y].leftWall;

                bool right = false;
                bool bottom = false;
                if(x == mazeGenerator.mazeWidht - 1) right = true;
                if(y == 0) bottom = true;

                mazeCell.Init(top, bottom, left, right); 
            }
        }

        GameObject wall = Instantiate(Wall, new Vector3(maze[30, 59].x - 0.5f, 0.5f, maze[30, 59].y + 0.5f), Quaternion.identity, transform);
        wall.transform.localScale = new Vector3(mazeGenerator.mazeWidht, 1, 0.05f);
    }
}
