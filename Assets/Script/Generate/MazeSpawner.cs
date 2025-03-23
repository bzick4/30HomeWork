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

    [Header("Position")]
    [SerializeField] private Vector3 CellSize = new Vector3();

    private GameObject _finishSpawn;



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

              if (maze[x, y].Plane && Random.value < _SpawnCoinChance)
              {
                Instantiate(_CoinPrefab, new Vector3(x * CellSize.x, 1f, y *  CellSize.z), Quaternion.identity);
              }

             
        
            }
        }

        Vector3 spawnFinish = new Vector3 (_generator._height, 1, _generator._width);
             Instantiate(_Finish, spawnFinish, Quaternion.identity);
    }






}
