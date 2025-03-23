using System;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public static event Action OnGiveCoin;
    [SerializeField] private GameObject _destroyEffect;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
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
