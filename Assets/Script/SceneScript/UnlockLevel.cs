using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] levelTriggers;

    private void Start()
    {
        UnlockLevels();
    }
    
    void UnlockLevels()
    {
        for (int i = 0; i < levelTriggers.Length; i++)
        {
            if (PlayerPrefs.GetInt("Level_" + i.ToString()) == 1)
            {
                levelTriggers[i].SetActive(true); 
            }
            else
            {
                levelTriggers[i].SetActive(false);
            }
        }
        
        levelTriggers[0].SetActive(true);
    }
}
