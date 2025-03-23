using System.Collections.Generic;
using UnityEngine;

public class GenerateMaterial : MonoBehaviour
{
    [Header("Material Maze")]
    [SerializeField] private List<Material> _PlaneMaterials;
    [SerializeField] private List<Material> _WallMaterials;
    
    
    public void PlaneMaterial(List<Cell> cells)
    {

        if (_PlaneMaterials.Count == 0 || cells.Count == 0) return;

        Material choosePlaneMaterial = _PlaneMaterials[Random.Range(0, _PlaneMaterials.Count)];
        
        foreach(Cell cell in cells)
        {
            Renderer _planeRenderer = cell._Plane.GetComponent<Renderer>();
            
            if(_planeRenderer != null)
            {
                _planeRenderer.material = choosePlaneMaterial;
            }
        }
    }

    public void WallMaterial(List<Cell> cells)
    {
        if (_WallMaterials.Count == 0 || cells.Count == 0) return;

        Material chooseWallMaterial = _WallMaterials[Random.Range(0, _WallMaterials.Count)];

        foreach(Cell cell in cells)
        {
            Renderer _leftWallrenderer = cell._WallLeft.GetComponent<Renderer>();
            Renderer _downWallrenderer = cell._WallDown.GetComponent<Renderer>();

            if (_leftWallrenderer != null)
            {
                _leftWallrenderer.material = chooseWallMaterial;
            }

            if (_downWallrenderer != null)
            {
                _downWallrenderer.material = chooseWallMaterial;
            }
        }
    }

}
