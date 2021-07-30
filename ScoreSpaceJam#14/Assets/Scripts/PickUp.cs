using UnityEngine;
public class PickUp : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxholder;
    public float rayDist;
    void Start()
    {
        Debug.Log("This is a useless log");
    }
    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position,Vector2.right * transform.localScale, rayDist);

        if(grabCheck.collider != null && grabCheck.collider.tag == "Box") {
            if (Input.GetKey(KeyCode.G)) {
                grabCheck.collider.gameObject.transform.parent = boxholder;
                grabCheck.collider.gameObject.transform.parent.position = boxholder.position;
                grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;

            } else 
            {
               grabCheck.collider.gameObject.transform.parent = null;
               grabCheck.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            }
            

        }
    }
}


