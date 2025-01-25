using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5.0f;

    Rigidbody2D rb;
    Vector2 velocity;
    float inputHorizontal; //used to flip sprite

    public GameObject gunPrefab;

    //bool isFacingLeft = false;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            gameObject.transform.localScale = new Vector3(1, 2, 1);
        }
        if (inputHorizontal < 0) //move left
        {
            gameObject.transform.localScale = new Vector3(-1, 2, 1);
        }
    }

    public void PickupGun(GameObject obj)
    {

    }
}
