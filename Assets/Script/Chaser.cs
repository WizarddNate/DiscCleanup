using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 10;
    public float speed = 5.0f;
    public GameObject player;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet"))
        {
            //Debug.Log("Hit");
            health -= 5;
            Object.Destroy(other.gameObject);
        }
        if (health <= 0)
        {
            //Debug.Log("death");
            Object.Destroy(gameObject);
        }
    }
}
