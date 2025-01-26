using UnityEngine;

public class Gun : MonoBehaviour
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
    BubbleBulletScript damage;
    public bool canFire = true;
    private float timer;
    public float timeBetweenShots;

    public AudioSource source;
    public AudioClip clip;
    public void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        isGunBeingHeld = false;
        damage = bulletPrefab.GetComponent<BubbleBulletScript>();
    }

    private void Update()
    {
        if (isGunBeingHeld == true)
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - transform.position;
            float rot2 = Mathf.Atan2(-rotation.x, rotation.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rot2 + 90);

            if(gameObject.tag == "Gun" && Input.GetMouseButtonDown(0))
            {
                Shoot(5f, .5f, 0f);
            }
            else if(gameObject.tag == "Shotgun" && Input.GetMouseButton(0)) 
            {
                Shoot(2.5f, .2f, .25f);
            }
        }
    }
    public void Activate()
    {
        isGunBeingHeld = true;
    }


    public void Shoot(float hurt, float size, float timelimit)
    {
        timer += Time.deltaTime;
        if (canFire)
        {
            source.PlayOneShot(clip);
            bulletPrefab.transform.localScale = new Vector3(size, size, size);
            damage.SetDamage(hurt);
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            canFire = false;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer > timelimit)
            {
                canFire = true;
                timer = 0f;
            }
        }
    }
}
