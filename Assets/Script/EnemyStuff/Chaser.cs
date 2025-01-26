using UnityEngine;

public class Enemy : MonoBehaviour
{

    private GameObject player;
    EnemyStats stats;
    float health;
    float speed;
    public GameObject deathEffect;
    SpriteFlasher flasher;
    EnemyManager enemyManager;
    void Start()
    {
        enemyManager = FindAnyObjectByType<EnemyManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        stats = GetComponent<EnemyStats>();
        health = stats.stats["chaser"]["health"];
        speed = stats.stats["chaser"]["speed"];
        flasher = GetComponent<SpriteFlasher>();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerBullet") && !flasher.isFlashing)
        {
            //Debug.Log("HIT");
            BubbleBulletScript bullet = other.gameObject.GetComponent<BubbleBulletScript>();
            float damage = bullet.damage;
            StartCoroutine(flasher.Flash(stats.invincibleTime, stats.flashColor, stats.numOfFlashes));
            health -= damage;
            //Debug.Log($"health {health} damage: {damage}");
            Object.Destroy(other.gameObject);
        }
        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            enemyManager.total -= 1;
            Object.Destroy(gameObject);
        }
    }
}
