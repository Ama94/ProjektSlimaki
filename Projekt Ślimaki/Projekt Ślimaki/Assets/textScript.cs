using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textScript : MonoBehaviour {


    public SnailMovement snail;
    // Use this for initialization
    static private int i = 1;
	
	// Update is called once per frame
	void Update () {
        transform.position.Set(i++,i++, 0f);
        Debug.Log("X = " + snail.transform.position.x + "Y = " + snail.transform.position.y);
        
	}
}
