using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailMovement : MonoBehaviour {


    public float speed;
    public float jumpPower;
    public bool isGrounded;
    public bool isFallig;
    public bool isJumping;
    private bool isFacingLeft;
    private Rigidbody2D rb2d;
    private float calculatedMoveSpeed;
    public Animator animator;

    public LayerMask groundLayers;
	// Use this for initialization
	void Start () {
        isFacingLeft = true;
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        float horizontal = Input.GetAxis("Horizontal");
        Flip(horizontal);

        isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f), new Vector2(transform.position.x + 0.9f, transform.position.y - 0.9f), groundLayers);

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

        if(isFallig == true)
        {
            animator.SetBool("isJumping", false);
            isJumping = false;
        }

        animator.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal") * speed));
    }

    private void Flip(float horizontal)
    {
        if(horizontal < 0 && !isFacingLeft || horizontal >0 && isFacingLeft)
        {
            isFacingLeft = !isFacingLeft;
            transform.Rotate(0f, 180f,0f);
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

    
}
