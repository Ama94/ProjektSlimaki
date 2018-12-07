using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {

    public float speed = 5f;
    public Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d.velocity = transform.right * -1 * speed;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}
