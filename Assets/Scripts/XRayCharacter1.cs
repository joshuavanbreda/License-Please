using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class XRayCharacter1 : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Material[] baseMaterials;
    int baseLayer;
    public bool xRayOn;
    public Material xRayMaterial;
    List<Material> xRayMaterials;
    public UnityEvent onXRay;
    public UnityEvent offXRay;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        baseMaterials = meshRenderer.materials;
        baseLayer = gameObject.layer;
        xRayMaterials = new List<Material> { xRayMaterial };
        for (int i = 0; i < baseMaterials.Length - 1; i++)
        {
            xRayMaterials.Add(xRayMaterial);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    xRayOn = !xRayOn;
        //}
        if (xRayOn != true)
        {
            gameObject.layer = baseLayer;
            meshRenderer.materials = baseMaterials;
            offXRay.Invoke();
        }
        else
        {
            gameObject.layer = 8;
            meshRenderer.materials = xRayMaterials.ToArray();
            onXRay.Invoke();
        }
    }
}
