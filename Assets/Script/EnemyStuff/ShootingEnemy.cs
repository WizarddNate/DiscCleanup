using UnityEngine;

public class ShootingEnemy : MonoBehaviour 
{
    float health;
    float speed;
    EnemyStats stats;
    SpriteFlasher flasher;


    public GameObject deathEffect;
    public float range = 10f;
    public GameObject bullet;
    public Transform bulletPos;
    public GameObject medkit;
    GameObject player;
    EnemyManager enemyManager;

    float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stats = GetComponent<EnemyStats>();
        flasher = GetComponent<SpriteFlasher>();
        enemyManager = FindAnyObjectByType<EnemyManager>();
        if (gameObject.name.Contains("Dog"))
        {
            health = stats.stats["Dog"]["health"];
            speed = stats.stats["Dog"]["speed"];
        }
        else if (gameObject.name.Contains("Bug"))
        {
            health = stats.stats["Bug"]["health"];
            speed = stats.stats["Bug"]["speed"];
        }
        else
        {
            health = stats.stats["default"]["health"];
            speed = stats.stats["default"]["health"];
        }
    }

    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if (distance < range)
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                Shoot();
            }
        }
    }
    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
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
