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
    GameObject player;

    float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stats = GetComponent<EnemyStats>();
        health = stats.stats["chaser"]["health"];
        speed = stats.stats["chaser"]["speed"];
        flasher = GetComponent<SpriteFlasher>();
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
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Object.Destroy(gameObject);
        }
    }
}
