using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class webCamTexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
		WebCamTexture webcamtexture = new WebCamTexture ();
		GetComponent<MeshRenderer> ().material.mainTexture = webcamtexture ;
		webcamtexture.Play ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
