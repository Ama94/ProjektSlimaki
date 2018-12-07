using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    public Transform firePoint;
    public GameObject BulletShotgunPrefab;
    public GameObject rocketPrefab;
    public AudioSource audio;
    private Snail snail;
    public SpriteRenderer weaponSprite;
    public SpriteRenderer crosshairSprite;

    public Sprite rifle;
    public Sprite rocketLauncher;
   
    // Update is called once per frame

    private void Start()
    {
        snail = GetComponentInParent(typeof(Snail)) as Snail;
        weaponSprite.sprite = rifle;
        //rifle = Resources.Load("rifle", typeof(Sprite)) as Sprite;
        //rocketLauncher = Resources.Load("rocket_launcher", typeof(Sprite)) as Sprite;

    }
    void Update () {
        if (Input.GetKeyDown(KeyCode.X) && snail.isItThisSnailTurn() && TimerScript.afterShootingTurn == false)
        {
            Shoot();
            TimerScript.afterShootingTurn = true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad1) && snail.isItThisSnailTurn())
        {
            Debug.Log("1");
            weaponSprite.sprite = rifle;
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) && snail.isItThisSnailTurn())
        {
            Debug.Log("2");
            weaponSprite.sprite = rocketLauncher;
        }
    }

    private void Shoot()
    {
        audio.Play();
        if (weaponSprite.sprite == rifle)
        {
            Instantiate(BulletShotgunPrefab, firePoint.position, firePoint.rotation);
        }
        if(weaponSprite.sprite == rocketLauncher)
        {
            Instantiate(rocketPrefab,firePoint.position,firePoint.rotation);
        }

    }

    public void removeWeapon()
    {
       // spriteRenderer.sortingOrder = -1;
        weaponSprite.sprite = null;
        crosshairSprite.sprite = null;
    }

    public void hideWeapon()
    {
        weaponSprite.sortingOrder = -2;
        crosshairSprite.sortingOrder = -2;
    }

    public void showWeapon()
    {
        weaponSprite.sortingOrder = 1;
        crosshairSprite.sortingOrder = 1;
    }
}
