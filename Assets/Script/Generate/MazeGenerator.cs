using System.Collections.Generic;
using UnityEngine;

public class MazeGenerateCell
{
public int X, Y;

public bool WallLeft = true, WallDown = true, Plane = true;

public bool Visited = false;
}

public class MazeGenerator
{
    public int _widthX{get;set;} = Random.Range(11,21); 
    public int _heightZ{get; set;} = Random.Range(11,21);


    public MazeGenerateCell[,] GenerateMaze()
    {

        MazeGenerateCell[,] maze = new MazeGenerateCell[_widthX, _heightZ];

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                maze[x,y] = new MazeGenerateCell {X = x, Y = y };
            }
        }

        for (int x = 0; x < maze.GetLength(0); x ++)
        {
            maze [x, _heightZ - 1].WallLeft = false;
            maze [x, _heightZ - 1].Plane = false;
        }

        for (int y = 0; y < maze.GetLength(1); y ++)
        {
            maze [_widthX - 1, y].WallDown = false;
            maze [_widthX - 1, y].Plane = false;
        }

        RemoveWallsWithBacktracker(maze);

        return maze;

        
    }

    private void RemoveWallsWithBacktracker(MazeGenerateCell[,] maze)
    {
        MazeGenerateCell current = maze[0, 0];
        current.Visited = true;

        Stack<MazeGenerateCell> stack = new Stack<MazeGenerateCell>();
        do 
        {
            List<MazeGenerateCell> unvisit = new List<MazeGenerateCell>();

            int x = current.X;
            int y = current.Y;
            
            if (x > 0 && !maze[x - 1, y].Visited) unvisit.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].Visited) unvisit.Add(maze[x, y - 1]);

            if (x < _widthX - 2 && !maze[x + 1, y].Visited) unvisit.Add(maze[x + 1, y]);
            if (y < _heightZ - 2 && !maze[x, y + 1].Visited) unvisit.Add(maze[x, y + 1]);

            if (unvisit.Count > 0)
            {
                MazeGenerateCell chosen = unvisit[Random.Range(0, unvisit.Count)];
                RemoveWall(current, chosen);
                chosen.Visited = true;
                stack.Push(chosen);
                current = chosen;
            }
            else
            {
                current = stack.Pop();
            }

        }
        while (stack.Count > 0);
    }

    private void RemoveWall(MazeGenerateCell a, MazeGenerateCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y) a.WallDown = false;
            else b.WallDown = false;
        }
        else
        {
            if (a.X > b.X) a.WallLeft = false;
            else b.WallLeft = false;
        }
    }
}
