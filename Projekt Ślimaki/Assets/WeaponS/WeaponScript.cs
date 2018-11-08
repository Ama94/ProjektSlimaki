using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public Transform firePoint;
    public GameObject BulletShotgunPrefab;

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }
	}

    private void Shoot()
    {
        Instantiate(BulletShotgunPrefab,firePoint.position,firePoint.rotation);

    }
}
