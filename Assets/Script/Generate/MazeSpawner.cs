using UnityEngine;
using System.Collections.Generic;
public class MazeSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _CellPrefab;
    [SerializeField] private GameObject _CoinPrefab;
    [SerializeField] private GameObject _Finish;

    [Header("% Generation")]
    [SerializeField, Range(0.1f, 0.25f)] private float _SpawnCoinChance;

    private Vector3 CellSize = new Vector3(3.5f,0f,3.5f);

    private List<Cell> SpawnnedCell = new List<Cell>();

   
    private void Start() 
    {
        SpawnMaze();
    }

    private void SpawnMaze()
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

              SpawnnedCell.Add(c);

              if (maze[x, y].Plane && Random.value < _SpawnCoinChance)
              {
                Instantiate(_CoinPrefab, new Vector3(x * CellSize.x, 1f, y *  CellSize.z), Quaternion.identity);
              }
            }
        }

        FindObjectOfType<GenerateMaterial>()?.PlaneMaterial(SpawnnedCell);
        FindObjectOfType<GenerateMaterial>()?.WallMaterial(SpawnnedCell);
            
        int _randX = Mathf.Max(_generator._widthX);
        int _randZ = Mathf.Max(_generator._heightZ);
        int _randSpawn = Random.Range(3,7);

        Vector3 spawnFinish = new Vector3 ((_randX * CellSize.x) - (CellSize.x * _randSpawn) , 1f, (_randZ * CellSize.z) - (CellSize.z * _randSpawn));
        Instantiate(_Finish, spawnFinish, Quaternion.identity);
    }

}
