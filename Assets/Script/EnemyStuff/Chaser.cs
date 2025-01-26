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
    public GameObject medkit;
    void Start()
    {
        enemyManager = FindAnyObjectByType<EnemyManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        stats = GetComponent<EnemyStats>();
        flasher = GetComponent<SpriteFlasher>();
        if (gameObject.name.Contains("Bird"))
        {
            health = stats.stats["Bird"]["health"];
            speed = stats.stats["Bird"]["speed"];
        }
        else if (gameObject.name.Contains("Worm"))
        {
            health = stats.stats["Worm"]["health"];
            speed = stats.stats["Worm"]["speed"];
        }
        else
        {
            health = stats.stats["Default"]["health"];
            speed = stats.stats["Default"]["health"];
        }

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
            Debug.Log($"health {health} damage: {damage}");
            Object.Destroy(other.gameObject);
        }
        if (health <= 0)
        {
            int RNG = Random.Range(1, 21);
            if (RNG >= 15)
            {
                Instantiate(medkit, transform.position, Quaternion.identity);
            }
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            enemyManager.total -= 1;
            Object.Destroy(gameObject);
        }
    }
}
