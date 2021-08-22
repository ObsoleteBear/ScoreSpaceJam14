using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveHorizontal;
    public Rigidbody2D rb;

    public float horizontalAcceleration; // This is the value I am talking about!
    public float horizontalDampingStop = 0.5f;
    public float horizontalDampingTurn = 0.5f;
    public float horizontalDampingBasic = 0.5f;
    public float horizontalVelocity;

    public int Onions;
    public int Carrots;
    public int Tomatoes;
    public int Potatoes;

    private void AccelerationDamping(float damping)
    {
        horizontalVelocity *= Mathf.Pow(1f - damping, Time.deltaTime * 10);
       
    }

    public void FixedUpdate()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");

        horizontalVelocity = rb.velocity.x;
        horizontalVelocity += moveHorizontal * horizontalAcceleration;

        if (Mathf.Abs(moveHorizontal) == 0)
            AccelerationDamping(horizontalDampingStop);
        else if (Mathf.Sign(moveHorizontal) != Mathf.Sign(horizontalVelocity))
            AccelerationDamping(horizontalDampingTurn);
        else
            AccelerationDamping(horizontalDampingBasic);

        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            rb.velocity = new Vector2(rb.velocity.x / 3, rb.velocity.y);
        }
    }

    public void Update()
    {
        if (rb.velocity.x > 0 && Input.GetAxisRaw("Horizontal") > 0)
            transform.Rotate(Vector3.forward * horizontalVelocity * -0.5f);
        else if (rb.velocity.x < 0 && Input.GetAxisRaw("Horizontal") < 0)
            transform.Rotate(Vector3.back * horizontalVelocity * 0.5f);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Food")
        {
            Debug.Log("collided with food");
            if (collision.gameObject.GetComponent<PickUp>().FoodType == "Onion")
            {
                Onions = Onions + 1; 
                gameObject.transform.localScale = gameObject.transform.localScale + new Vector3(0.5f, 0.5f, 0);
            } else if (collision.gameObject.GetComponent<PickUp>().FoodType == "Potato")
            {
                Potatoes = Potatoes + 1;
                gameObject.transform.localScale = gameObject.transform.localScale + new Vector3(0.5f, 0.5f, 0);
                horizontalAcceleration = horizontalAcceleration / 1.25f;
            } else if (collision.gameObject.GetComponent<PickUp>().FoodType == "Carrot")
            {
                Carrots = Carrots + 1;
                gameObject.transform.localScale = gameObject.transform.localScale + new Vector3(0.5f, 0.5f, 0);
                horizontalAcceleration = horizontalAcceleration * 1.25f;
            }  else if (collision.gameObject.GetComponent<PickUp>().FoodType == "Tomato")
            {
                Tomatoes = Tomatoes + 1;
                gameObject.transform.localScale = gameObject.transform.localScale + new Vector3(0.5f, 0.5f, 0);
            }
        }
    }
}
