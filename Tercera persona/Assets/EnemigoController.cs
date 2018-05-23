using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour
{
    public Renderer Renderer;

    private Animator _animator;
    
    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("atacando!");
            transform.LookAt(other.transform);
            _animator.SetTrigger("ataca");
        }
    }
}