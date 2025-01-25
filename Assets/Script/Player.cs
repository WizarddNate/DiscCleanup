using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5.0f;
    int health = 3;
    Rigidbody2D rb;
    Vector2 velocity;
    float inputHorizontal; //used to flip sprite

    public GameObject gunPrefab;

    SpriteFlasher flasher;
    [SerializeField] public Color flashColor;
    //bool isFacingLeft = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        flasher = GetComponent<SpriteFlasher>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.linearVelocity = velocity.normalized * moveSpeed;

        //get horizontal movement input to be able to flip the character
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal > 0) //move right
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (inputHorizontal < 0) //move left
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void PickupGun(GameObject obj)
    {

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == null)
        {
            Debug.Log("SHDIH");
        }
        if (other.CompareTag("EnemyBullet") && !flasher.isFlashing || other.CompareTag("Enemy"))
        {
            
            health -= 1;
            StartCoroutine(flasher.Flash(1.5f, flashColor, 3f));
            Object.Destroy(other.gameObject);
        }

        if (health <= 0)
        {
            Debug.Log("DEAD");
        }
    }
    
}
