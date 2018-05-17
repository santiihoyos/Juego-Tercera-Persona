using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnMouseEnter()
	{
		print("entra");
		GetComponent<MeshRenderer>().materials[1].SetFloat("_Outline", 0.06f);
	}

	private void OnMouseExit()
	{
		print("entra");
		GetComponent<MeshRenderer>().materials[1].SetFloat("_Outline", 0.00f);
	}
}
