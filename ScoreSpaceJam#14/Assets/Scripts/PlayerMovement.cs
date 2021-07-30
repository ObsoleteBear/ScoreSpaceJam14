using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveHorizontal;
    public Rigidbody2D rb;

    public float horizontalAcceleration; // This is the value I am talking about!
    public float horizontalDampingStop = 0.5f;
    public float horizontalDampingTurn = 0.5f;
    public float horizontalDampingBasic = 0.5f;
    private float horizontalVelocity;

    private void AccelerationDamping(float damping)
    {
        horizontalVelocity *= Mathf.Pow(1f - damping, Time.deltaTime * 10);
       
    }

    public void Update()
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
        if (rb.velocity.x > 0)
            transform.Rotate(Vector3.forward * horizontalVelocity * -0.1f);
        else if (rb.velocity.x < 0)
            transform.Rotate(Vector3.back * horizontalVelocity * 0.1f);
    }
}
