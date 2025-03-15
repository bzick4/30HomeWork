using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public int levelIndex; // Индекс текущего уровня

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Сохраняем прогресс прохождения текущего уровня
            PlayerPrefs.SetInt("Level_" + levelIndex.ToString(), 1);
        }
    }
}
