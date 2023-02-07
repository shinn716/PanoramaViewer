using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObj : MonoBehaviour
{
    Renderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<Renderer>();
    }
    public void ChangeBoxColor()
    {
        meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }
}
