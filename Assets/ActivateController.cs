using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateController : MonoBehaviour {

    public void ToggleActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);

    }




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
