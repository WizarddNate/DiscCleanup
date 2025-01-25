using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    Rigidbody2D rb;
    Vector2 velocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = velocity.normalized * moveSpeed;
    }
}
