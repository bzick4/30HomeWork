using System;
using TMPro;
using UnityEngine;



public class CoinScript : MonoBehaviour
{
    public static event Action OnGiveCoin;
    [SerializeField] private GameObject _destroyEffect;
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.TryGetComponent<BallWalk>(out var ballWalk)) return;
        {
            OnGiveCoin?.Invoke();
            DestroyEffect();
            DestroyCoin();
        }
    }
    
    private void DestroyCoin()
    {
        gameObject.SetActive(false);
    }
    
    private void DestroyEffect()
    {
        _destroyEffect.SetActive(true);
    }
   

}
