using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {


    private float explosionRadius =500f;
    private float speed = 30f;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("BOOOOOOOOOOOOOOOOOOOOM");
        Rigidbody2D rb = collision.otherRigidbody;
        if(rb!=null && collision.gameObject.tag == "Snail")

        {
            Debug.Log("Explosion hits Snail");
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius, LayerMask.NameToLayer("snailsLayer"));

            foreach (Collider2D collider in hits)
            { 
                Debug.Log("Pracuje z colliderem");

                //snail.getHit(25);
                
                Vector3 deltaPos = rb.gameObject.transform.position - this.transform.position;
                Vector3 force = deltaPos.normalized * explosionRadius;
                wypierdolWKosmos(deltaPos,force,rb);
                
            }
        }
    }
     private void wypierdolWKosmos(Vector3 deltaPos, Vector3 force, Rigidbody2D rb)
    {
        rb.AddForce(Vector2.up * force * speed, ForceMode2D.Impulse);
    }

}
