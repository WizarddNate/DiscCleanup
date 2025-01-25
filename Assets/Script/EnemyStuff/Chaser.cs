using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject player;
    EnemyStats stats;
    float health;
    float speed;
    public GameObject deathEffect;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        stats = GetComponent<EnemyStats>();
        health = stats.stats["chaser"]["health"];
        speed = stats.stats["chaser"]["speed"];
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
            //Debug.Log("hit");
            health -= 5;
            Object.Destroy(other.gameObject);
        }
       if (health <= 0)
       {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Object.Destroy(gameObject);
       }
    }
}
