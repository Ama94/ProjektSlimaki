using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMovementScript : MonoBehaviour
{
    private Snail snail;
    public void Start()
    {
      snail = GetComponentInParent(typeof(Snail)) as Snail;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) && snail.isItThisSnailTurn())
        {
            transform.Rotate(0, 0, -1f);
        }
        if (Input.GetKey(KeyCode.DownArrow) && snail.isItThisSnailTurn())
        {
            transform.Rotate(0, 0, 1f);
        }
        if (transform.rotation == Quaternion.Euler(0f, 0f, -90f))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -89f);

            if (transform.rotation == Quaternion.Euler(0f, 0f, 90f))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 89f);
            }

            /*
            if (transform.rotation == Quaternion.Euler(0f,0,-90f))
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -89f);
            }

            if (transform.rotation == Quaternion.Euler(0f,0,90f) )
            {
                transform.rotation = Quaternion.Euler(0f, 0, 89f);
            }
            */

        }
    }
}

