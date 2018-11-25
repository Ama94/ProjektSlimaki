using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public Transform firePoint;
    public GameObject BulletShotgunPrefab;
    public AudioSource audio;
    private Snail snail;
    // Update is called once per frame

    private void Start()
    {
        snail = GetComponentInParent(typeof(Snail)) as Snail;
    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.X) && snail.isItThisSnailTurn())
        {
            Shoot();
        }
	}

    private void Shoot()
    {
        audio.Play();
        Instantiate(BulletShotgunPrefab,firePoint.position,firePoint.rotation);

    }
}
