using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    int maxhearts = 3;
    Rigidbody2D rb;
    Vector2 velocity;
    float inputHorizontal; //used to flip sprite

    public GameObject gunPrefab;

    SpriteFlasher flasher;
    [SerializeField] public Color flashColor;
    Health health;
    //bool isFacingLeft = false;

    public Animator animator;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        health.health = maxhearts;
        flasher = GetComponent<SpriteFlasher>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = velocity.normalized * moveSpeed;

        //get horizontal movement input to be able to flip the character
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        //start walking animation once movement speed increases
        animator.SetFloat("Speed", Mathf.Abs(inputHorizontal));

        if (inputHorizontal > 0) //move right
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (inputHorizontal < 0) //move left
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet") && !flasher.isFlashing)
        {

            health.health -= 1;
            StartCoroutine(flasher.Flash(1.5f, flashColor, 3f));
            Object.Destroy(other.gameObject);
        }
        else if (other.CompareTag("Enemy") && !flasher.isFlashing)
        {
            health.health -= 1;
            StartCoroutine(flasher.Flash(1.5f, flashColor, 3f));
        }
        else if (other.CompareTag("Medkit"))
        {
            if (health.health == maxhearts)
            {
                Object.Destroy(other.gameObject);
            }
            else
            {
                health.health += 1;
                Object.Destroy(other.gameObject);
            }
        }
        if (health.health <= 0)
        {
            Debug.Log("DEAD");
        }
    }
    
}
