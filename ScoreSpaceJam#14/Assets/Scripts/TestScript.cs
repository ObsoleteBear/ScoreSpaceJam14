using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
   private Rigidbody2D rb;
   private void Awake() {
       rb = GetComponent<Rigidbody2D>();
   }
   private void Update() {
       rb.AddForce(new Vector2 (3f, 0f) * Time.deltaTime);
   }


}
