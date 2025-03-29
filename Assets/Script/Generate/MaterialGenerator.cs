using UnityEngine;
using System.Collections.Generic;

public class MaterialGenerator : MonoBehaviour
{
    [SerializeField] private List<Material> _PlaneMaterials;
    [SerializeField] private List<Material> _WallMaterials;

    public Material GetRandomPlaneMaterial()
    {
        if (_PlaneMaterials == null || _PlaneMaterials.Count == 0)
        {
            Debug.LogError("No plane materials assigned!");
            return null;
        }
        return _PlaneMaterials[Random.Range(0, _PlaneMaterials.Count)];
    }

    public Material GetRandomWallMaterial()
    {
        if (_WallMaterials == null || _WallMaterials.Count == 0)
        {
            Debug.LogError("No wall materials assigned!");
            return null;
        }
        return _WallMaterials[Random.Range(0, _WallMaterials.Count)];
    }
}
