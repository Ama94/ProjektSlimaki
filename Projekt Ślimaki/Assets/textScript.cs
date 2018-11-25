using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textScript : MonoBehaviour {


    private Snail snail;
    // Use this for initialization
    static private int i = 1;

    private void Start()
    {
        snail = this.GetComponentInParent(typeof(Snail)) as Snail;
    }
    // Update is called once per frame
    void Update () {

        if(snail.getIsFacinLeft())
        {
            this.transform.Rotate(0f, 0f, 0f);
        }
        if(!snail.getIsFacinLeft())
        {
            this.transform.Rotate(0f, -180f, 0f);
        }
        
	}
}
