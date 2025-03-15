using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _coin;
    public int totalCoin { get; private set; }
    private void Start()
    {
        CoinScript.OnGiveCoin += OnCoin;
    }
    
    private void OnDisable()
    {
        CoinScript.OnGiveCoin -= OnCoin;
    }
    
    public void OnCoin()
    {
        totalCoin++;
        _coin.text = totalCoin.ToString();
    }
   
}
