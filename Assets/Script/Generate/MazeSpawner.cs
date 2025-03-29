
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject _CellPrefab;
    [SerializeField] private GameObject _CoinPrefab;
    [SerializeField] private GameObject _Finish;

    [Header("Generation Settings")]
    [SerializeField, Range(0.1f, 0.25f)] private float _SpawnCoinChance;
    [SerializeField] private MaterialGenerator _materialGenerator;

    private Vector3 CellSize = new Vector3(3f, 0f, 3f);
    private List<Cell> SpawnnedCell = new List<Cell>();

    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private float _fallTime = 0.2f;

    private void Start()
    {
        StartCoroutine(SpawnMaze());
    }

    private IEnumerator SpawnMaze()
    {
        MazeGenerator _generator = new MazeGenerator();
        MazeGenerateCell[,] maze = _generator.GenerateMaze();

        Material planeMaterial = _materialGenerator.GetRandomPlaneMaterial();
        Material wallMaterial = _materialGenerator.GetRandomWallMaterial();

        for (int x = 0; x < maze.GetLength(0); x++)
        {
            for (int y = 0; y < maze.GetLength(1); y++)
            {
                Cell c = Instantiate(_CellPrefab, new Vector3(x * CellSize.x, 1f, y * CellSize.z), Quaternion.identity).GetComponent<Cell>();

                c._WallLeft.SetActive(maze[x, y].WallLeft);
                c._WallDown.SetActive(maze[x, y].WallDown);
                c._Plane.SetActive(maze[x, y].Plane);

                if (maze[x, y].Plane)
                    c.SetPlaneMaterial(planeMaterial);
                
                if (maze[x, y].WallLeft || maze[x, y].WallDown)
                    c.SetWallMaterial(wallMaterial);

                SpawnnedCell.Add(c);

                if (maze[x, y].Plane && Random.value < _SpawnCoinChance)
                  {Instantiate(_CoinPrefab, new Vector3(x * CellSize.x, 1f, y * CellSize.z), Quaternion.identity);}

                yield return new WaitForSeconds(_delay);
                StartCoroutine(FallEffect(c.transform));
            }
        }
                int _randX = Mathf.Max(_generator._widthX);
                int _randZ = Mathf.Max(_generator._heightZ);
                int _randSpawnFinish = Random.Range(3,7);
                
                Vector3 spawnFinish = new Vector3 ((_randX * CellSize.x) - (CellSize.x * _randSpawnFinish) , 1f, (_randZ * CellSize.z) - (CellSize.z * _randSpawnFinish));
                Instantiate(_Finish, spawnFinish, Quaternion.identity);
    }

    private IEnumerator FallEffect(Transform obj)
    {
        Vector3 startPos = obj.position;
        Vector3 targetPos = new Vector3(startPos.x, 0f, startPos.z);
        float elapsedTime = 0f;

        while (elapsedTime < _fallTime)
        {
            obj.position = Vector3.Lerp(startPos, targetPos, elapsedTime / _fallTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.position = targetPos;
    }
}