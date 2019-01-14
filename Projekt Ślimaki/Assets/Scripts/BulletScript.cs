using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float speed = 30f;
    public Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d.velocity = transform.right *-1 * speed;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Snail snail = collision.GetComponent<Snail>();
        if(snail!=null)
        {
            snail.getHit(100);
    
        }
            Destroy(gameObject);
    }
}
