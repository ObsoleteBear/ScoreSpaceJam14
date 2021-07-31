using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    SpriteRenderer spriteRenderer;
    bool isGrounded;

    [SerializeField] Transform groundCheck;
    
    
    void Start()
    {
       Debug.Log("CubeMovement go brrr"); 
       rb2d = GetComponent<Rigidbody2D>();
       spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void FixedUpdate() 
    {
        if(Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) 
        {
          isGrounded = true;

        
        }
        else 
        {
          isGrounded = false;
        }
        if(Input.GetKey("d")  ||  Input.GetKey("right")) 
        {
           rb2d.velocity = new Vector2(5, rb2d.velocity.y);
           spriteRenderer.flipX = false;
        }
        else if(Input.GetKey("a")  || Input.GetKey("left")) 
        {
          rb2d.velocity = new Vector2(-5, rb2d.velocity.y);
          spriteRenderer.flipX = true;
        }
        if(Input.GetKey("space") & isGrounded) 
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 5);
        }
    }
    
       
}