using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class klksfd : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) {
            rb.AddForce(new Vector2 (300f, 0f) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A)) {
            rb.AddForce(new Vector2 (-300f, 0f) * Time.deltaTime);
        }
    }
}
