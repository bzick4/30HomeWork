using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _CellPrefab;
    public Vector3 CellSize = new Vector3(1,1,0);

    private void Start() 
    {
        
        MazeGenerator _generator = new MazeGenerator();
        MazeGenerateCell[,] maze = _generator.GenerateMaze();

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y ++)
            {
              Cell c = Instantiate(_CellPrefab, new Vector3(x * CellSize.x, y * CellSize.y, y * CellSize.z), Quaternion.identity).GetComponent<Cell>();

              c._WallLeft.SetActive(maze[x, y].WallLeft);
              c._WallDown.SetActive(maze[x, y].WallDown);
              c._Plane.SetActive(maze[x, y].Plane);
            }
        }
    }
}
