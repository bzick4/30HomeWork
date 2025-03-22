using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject _CoinPrefab, _Finish;

    [SerializeField] private int _CoinCount;

    private MazeGenerator _mazeGenerator;
    private int _width, _height;
    private List<Vector2Int> usedPositions = new List<Vector2Int>(); // Запоминаем использованные координаты



    void Start()
    {
         _width = _mazeGenerator._width;
        _height = _mazeGenerator._height;
        SpawnObjects();
    }

    private void  Awake() 
    {  
     _mazeGenerator = GetComponentInParent<MazeGenerator>();
    }

    void SpawnObjects()
    {
       
        for (int i = 0; i < _CoinCount; i++)
        {
            Vector2Int position = GetRandomPosition(1, _width -2, 1, _height - 2);
            Instantiate(_CoinPrefab, new Vector3(position.x, 0, position.y), Quaternion.identity);
        }


    
        Vector2Int ballPosition = GetRandomPosition(1, _width -2, 1, _height - 2);
        Instantiate(_Finish, new Vector3(ballPosition.x, 0, ballPosition.y), Quaternion.identity);


    }

    Vector2Int GetRandomPosition(int minX, int maxX, int minY, int maxY)
    {
        Vector2Int position;
        do
        {
             position = new Vector2Int(Random.Range(minX, maxX), Random.Range(minY, maxY));
        } 
        while (usedPositions.Contains(position)); // Проверяем, чтобы не было дубликатов

        usedPositions.Add(position); // Запоминаем использованную позицию
        return position;
    }
}
