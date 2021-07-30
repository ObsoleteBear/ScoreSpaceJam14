using UnityEngine;
using UnityEngine.Assertions.Must;

public class PickUp : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxholder;
    public float rayDist;

    public GameObject Player;
    public Vector3 localpos;
    public float localrot;
    public bool connected = false;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        //if (connected == true)
        //{
        //    gameObject.transform.localPosition = localpos;
        //    //gameObject.transform.localRotation = localrot;
        //}
        //RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position,Vector2.right * transform.localScale, rayDist);

        //if(grabCheck.collider != null && grabCheck.collider.tag == "Box") {
        //    if (Input.GetKey(KeyCode.G)) {
        //        grabCheck.collider.gameObject.transform.parent = boxholder;
        //        grabCheck.collider.gameObject.transform.parent.position = boxholder.position;
        //        grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

        //    } else 
        //    {
        //       grabCheck.collider.gameObject.transform.parent = null;
        //       grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        //    }
            

        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && connected == false)
        {
            gameObject.transform.parent = Player.transform;
            localpos = gameObject.transform.localPosition;
            //localrot = gameObject.transform.localRotation.z;
            connected = true;
            gameObject.layer = 6;
        }
    }

}


