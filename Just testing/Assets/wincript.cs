using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wincript : MonoBehaviour
{
  

void OnCollisionEnter2D(Collision2D collision)
{
if (collision.collider.tag == "Player")
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       Debug.Log("hahah bonk");
   }
}

}
