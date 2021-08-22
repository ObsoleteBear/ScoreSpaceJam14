using UnityEngine;
using UnityEngine.Assertions.Must;

public class PickUp : MonoBehaviour
{
    public GameObject Player;
    public Rigidbody2D rb;
    public Collider2D col;

    public bool Absorbed;
    public string FoodType;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {

    }

    public void FixedUpdate()
    {
        if (Absorbed == true)
        {
            col.enabled = false;
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, 0.2f);
            if (transform.position == Player.transform.position)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Absorbed = true;
        }
    }

}


