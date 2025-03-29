
using System.Collections.Generic;
using UnityEngine;

public class GenerateSkyBox : MonoBehaviour
{
    [SerializeField] private List<Material> _SkyBoxes;


    public void Start()
    {
         if (_SkyBoxes.Count > 0)
        {
            int randomIndex = Random.Range(0, _SkyBoxes.Count);
            RenderSettings.skybox = _SkyBoxes[randomIndex];
            
            DynamicGI.UpdateEnvironment();
        }
        else
        {
            Debug.LogWarning("No skybox materials assigned!");
        }
    }
}
