using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private MaterialGenerator _materialGenerator;

    // Start is called before the first frame update
    void Start()
    {
        _materialGenerator= GetComponentInChildren<MaterialGenerator>();
        _materialGenerator.enabled = false;
    }

    // Update is called once per frame
    public void MaterialGeneratorOn()
    {
        _materialGenerator.enabled = true;
    }

}
