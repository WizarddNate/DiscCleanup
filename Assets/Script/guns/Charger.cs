using UnityEngine;

public class Charger : MonoBehaviour
{
    // vars //

    //where the bullet spawns from
    public Transform shootingPoint;

    //bullet prefab
    public GameObject bulletPrefab;

    //speed that the gun rotates
    public float rotateSpeed = 1.0f;
    Vector2 velocity;

    //look for maincam tag
    Camera mainCam;

    //position of the mouse
    public Vector3 mousePos;

    //check if gun is being actively held
    private bool isGunBeingHeld;

    private bool canFire = true;
    float timer;
    public float timeBetweenShots;
    BubbleBulletScript damage;
    public AudioSource source;
    public AudioClip clip;
    float charge;
    public void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        isGunBeingHeld = false;
        damage = bulletPrefab.GetComponent<BubbleBulletScript>();

    }

    private void Update()
    {
        //gun stays glued to Bekky
        //gameObject.transform.position = new Vector3(10, 10, 0);

        if (isGunBeingHeld == true)
        {
            //moves gun
            velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            velocity.Normalize();

            //Camera + mouse movement
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - transform.position;
            float rot2 = Mathf.Atan2(-rotation.x, rotation.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot2 + 90);

            //spawn bullets
            while (Input.GetMouseButtonDown(0))
            {
                charge += 1f;
                
            }
            if (Input.GetMouseButtonUp(0))
            {
                source.PlayOneShot(clip);
                bulletPrefab.transform.localScale = new Vector3(.75f, .75f, .75f);
                damage.SetDamage(charge);
                Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            }
        }
    }
    public void Activate()
    {
        isGunBeingHeld = true;
    }
}
