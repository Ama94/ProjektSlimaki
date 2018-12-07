using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textScript : MonoBehaviour {


    public Snail snail;
    // Use this for initialization
    static private int i = 1;
    private bool flipped=true;
    public TextMesh text;



    private void Start()
    {
        //snail = this.GetComponentInParent(typeof(Snail)) as Snail;
        
        //this.transform.Translate(new Vector3(4f, 3.9f));
    }
    // Update is called once per frame
    void Update () {
        text.text = snail.getSnailName() + "\n " + snail.getSnailHP();
        /*

                if(snail.getIsFacinLeft())
                {
                    //this.transform.eulerAngles = new Vector3(snail.transform.position.x, this.transform.position.y, snail.transform.eulerAngles.z);


                    if(flipped == true)
                    {
                        this.transform.position = snail.transform.position;
                        this.transform.Translate(new Vector3(0.0f, 0.9f));
                        this.transform.rotation = Quaternion.Euler(0, 0, 0);
                        //  this.transform.eulerAngles = new Vector3(snail.transform.position.x, this.transform.position.y, snail.transform.eulerAngles.z);
                        flipped = false;
                    }

                }

                if(!snail.getIsFacinLeft())
                {



                    //this.transform.eulerAngles = new Vector3(this.transform.position.x, this.transform.position.y, snail.transform.eulerAngles.z);
                    //this.transform.eulerAngles= new Vector3(this.transform.position.x, this.transform.position.y, 0);

                    if (flipped == false)
                    {
                        this.transform.Translate(new Vector3(1.3f, 0f));
                        this.transform.rotation = Quaternion.Euler(0, 0, 0);

                        flipped = true;
                    }



                }
                */
    }
}
