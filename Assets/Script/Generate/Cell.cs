using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ProBuilder;
using UnityEngine.ProBuilder.MeshOperations;

public class Cell : MonoBehaviour
{
   public GameObject _WallLeft, _WallDown, _Plane;
   

    public void SetPlaneMaterial(Material material)
    {
        if (_Plane != null)
        {
            Renderer planeRenderer = _Plane.GetComponent<Renderer>();
            if (planeRenderer != null)
            {
                planeRenderer.material = material;
            }
        }
    }

    public void SetWallMaterial(Material material)
    {
        if (_WallLeft != null)
        {
            Renderer wallLeftRenderer = _WallLeft.GetComponent<Renderer>();
            if (wallLeftRenderer != null)
            {
                wallLeftRenderer.material = material;
            }
        }

        if (_WallDown != null)
        {
            Renderer wallDownRenderer = _WallDown.GetComponent<Renderer>();
            if (wallDownRenderer != null)
            {
                wallDownRenderer.material = material;
            }
        }
    }
}