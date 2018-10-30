using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class OperationBlock : MonoBehaviour {

    [SerializeField] public string operation = "";


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void Calculation ()
    {
        if(IsConnected())
        {
            if (operation == "add")
            {
                Debug.Log(1);
            }
        }
    }

    private bool IsConnected()
    {
        Vector3 left = new Vector3(-1, 0, 0);
        Vector3 right = new Vector3(1, 0, 0);
        Vector3 above = new Vector3(0, 1, 0);
        Vector3 below = new Vector3(0, -1, 0);

        return false;
    }
}
