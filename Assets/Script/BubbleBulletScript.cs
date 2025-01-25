using UnityEngine;

public class BubbleBulletScript : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public float destoryTimer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * speed;
    }

    private void FixedUpdate()
    {
       if (destoryTimer > 0)
        {
            destoryTimer--;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }
}
