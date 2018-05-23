using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    public Renderer Renderer;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseEnter()
    {
        if (Renderer != null)
        {
            Renderer.materials[1].SetFloat("_Outline", 0.06f);
        }
    }

    private void OnMouseExit()
    {
        if (Renderer != null)
        {
            Renderer.materials[1].SetFloat("_Outline", 0f);
        }
    }
}