using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovemnt : MonoBehaviour
{
    private Rigidbody2D body;
    public float speed;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        Debug.Log("vroom vroom");
    }

    private void Update()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed ,body.velocity.y);

        //flip go brrr
        if (horizontalinput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalinput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);
    }


}
