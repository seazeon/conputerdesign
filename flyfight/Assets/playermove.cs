using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public Rigidbody2D rb;
    private Animator ani;
    public float movespeed;
    public float jumpspeed;
    private float Movementcontroller;
    private bool walking;
    private bool jumping;
    public LayerMask ground;
    private bool isground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movementcontroller = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.D))
            rb.velocity = new Vector2(movespeed, rb.velocity.y);
        if (Input.GetKey(KeyCode.A))
            rb.velocity = new Vector2(-movespeed, rb.velocity.y);
        if (Input.GetKey(KeyCode.Space) && isground )
            rb.velocity = new Vector2(rb.velocity.x, jumpspeed);
        walking = Movementcontroller != 0 && rb.velocity.y != jumpspeed;
        ani.SetBool("walking",walking);
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector2(-0.1f, 0.1f);

        }
        if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector2(0.1f, 0.1f);
        }
        if (rb.velocity.y == jumpspeed)
        {
            jumping = true;
        }
        else 
        { 
            jumping= false;
        }
        ani.SetBool("jumping", jumping);
        isground = Physics2D.Raycast(transform.position,Vector2.down,0.4f,ground);
    }
}