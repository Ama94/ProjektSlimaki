using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{


    private float explosionRadius = 4f;
    private float speed = 15f;
    public Rigidbody2D rb;
    private bool cos = false;
    private Collider2D[] hits;
    public AudioSource sound;
    //public ExplosionForce2D explosionForce;
    // Use this for initialization

    public void AddExplosionForce(Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
    {
        var dir = (body.transform.position - expPosition);
        float calc = 1 - (dir.magnitude / expRadius);
        if (calc <= 0)
        {
            calc = 0;
        }

        body.AddForce(dir.normalized * expForce * calc, ForceMode2D.Impulse);
    }

    void Start()
    {
        Destroy(this.gameObject, 2.0f);
        sound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Snail snail = collision.GetComponent<Snail>();
        if (snail != null)
        {
            snail.getHit(25);
        }
        flyAway(collision.GetComponent<Rigidbody2D>(), this.transform.position);
    }
    private void flyAway(Rigidbody2D rb, Vector3 deltaPos)
    {
        AddExplosionForce(rb, speed, deltaPos, explosionRadius);
    }



}
