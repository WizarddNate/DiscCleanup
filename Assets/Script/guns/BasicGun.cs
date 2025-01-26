using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BasicGun : MonoBehaviour
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
    private float timer = 0;
    public float timeBetweenShots = .5f;
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
            
            if (!canFire)
            {
                timer += Time.deltaTime;
                if (timer > timeBetweenShots)
                {
                    canFire = true;
                    timer = 0f;
                }
            }

            //spawn bullets
            if (Input.GetMouseButtonDown(0))
            {
                if (canFire)
                {
                    bulletPrefab.transform.localScale = new Vector3(.5f, .5f, .5f);
                    damage.SetDamage(5f);
                    Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
                    canFire = false;
                }
            }
        }
    }

    //public void ReloadCam()
    //{
    //    Debug.Log("Scene has loaded");
    //    mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    //}


    public void Activate()
    {
        isGunBeingHeld = true;
    }

}

