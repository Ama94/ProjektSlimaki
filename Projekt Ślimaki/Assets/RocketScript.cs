using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {

    public float speed = 3f;
    public Rigidbody2D rb2d;
    public GameObject explosion;
	// Use this for initialization
	void Start () {
        rb2d.velocity = transform.right * -1 * speed/2;
        
    }
	
	// Update is called once per frame
	void Update () {
        var dir = rb2d.velocity;
        var angle = Mathf.Atan2(-dir.y,- dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //transform.rotation = Quaternion.LookRotation(-rb2d.velocity);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 hit = new Vector3(this.rb2d.transform.position.x, this.rb2d.transform.position.y);
        Instantiate(explosion, hit, Quaternion.Euler(0f, 0f, 0f));
        Destroy(gameObject);
        
    }

    public void setSpeed()
    {

    }
}
