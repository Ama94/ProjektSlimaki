using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour {

    public GameObject flowController;

    public float speed;
    public float jumpPower;
    public bool isGrounded;
    public bool isFallig;
    public bool isJumping;
    private bool isFacingLeft;
    private Rigidbody2D rb2d;
    private float calculatedMoveSpeed;
    public Animator animator;
    private string snailName;
    public WeaponScript weaponScript;
    

    private int HP;
    private bool isStillAlive;
    private bool isItPlayerTurn;
    private bool isItThisSnailTurnNow;
    private Color color;
    


    public LayerMask groundLayers;
	// Use this for initialization
	void Start () {
        isFacingLeft = true;
        rb2d = GetComponent<Rigidbody2D>();
        HP = 100;
        isStillAlive = true;
        isItPlayerTurn = false;
        isItThisSnailTurnNow = false;
        snailName = "Snail";
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        
        
        detectFalling();
        if (isItPlayerTurn)
        {
            weaponScript.showWeapon();
            float horizontal = Input.GetAxis("Horizontal");
            Flip(horizontal);
            movementOfPlayer();
            animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal") * speed));
        }
        else
        {
            weaponScript.hideWeapon();
        }
        
    }

    private void Flip(float horizontal)
    {
        textScript text = this.GetComponentInChildren(typeof(textScript)) as textScript;
        if(horizontal < 0 && !isFacingLeft || horizontal >0 && isFacingLeft)
        {
            isFacingLeft = !isFacingLeft;
            this.transform.Rotate(0f, 180f,0f);
            text.transform.Rotate(0f, -180f, 0f);
            text.transform.Translate(new Vector3(-2f, 0f));
                }
    }

    private void setFalling(float y)
    {
        if (y < -0.1)
        {
            isFallig = true;
            animator.SetBool("isFalling", true);
        }
        else
        {
            isFallig = false;
            animator.SetBool("isFalling", false);
        }
    }

    private void movementOfPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJumping = true;
            animator.SetBool("isJumping", true);
        }


        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            calculatedMoveSpeed = Mathf.Lerp(rb2d.velocity.x, Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, Time.deltaTime * 10);
            rb2d.velocity = new Vector2(calculatedMoveSpeed, rb2d.velocity.y);

        }

        setFalling(rb2d.velocity.y);

        if (isFallig == true)
        {
            animator.SetBool("isJumping", false);
            isJumping = false;
        }
    }

    private void detectFalling()
    {
        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.9f, transform.position.y - 0.9f), groundLayers);
    }

    public void getHit(int damage)
    {
        HP -= damage;
        animator.SetTrigger("gotHit");
        if(HP<=0)
        {
            Death();
        }
       
    }
    

    public void setTurnOn()
    {
        isItPlayerTurn = true;
        isItThisSnailTurnNow = true;
    }

    public void setTurnOff()
    {
        isItPlayerTurn = false;
        isItThisSnailTurnNow = false;
        
    }

    public bool isItThisSnailTurn()
    {
        return isItPlayerTurn;
    
    }

    public bool isThisSnailAlive()
    {
        return isStillAlive;
    }

    public bool getIsFacinLeft()
    {
        return isFacingLeft;
    }

    public string getSnailName()
    {
        return snailName;
    }
    public int getSnailHP()
    {
        return HP;
    }
    public void Death()
    {
        animator.SetBool("isDead", true);
        isStillAlive = false;
        weaponScript.removeWeapon();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "LineOfWater")
        {
            this.Death();
        }
        if (collision.gameObject.tag == "WorldEdge")
        {
            this.Death();
        }

        if (collision.gameObject.name == "LineOfWater")
            {
            this.Death();
        }
    }
    public void setColor(Color color)
    {
        this.color = color;
    }
    public Color getColor()
    {
        return color;
    }
}
