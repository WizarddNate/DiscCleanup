using UnityEngine;
using UnityEngine.InputSystem;

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

    Camera mainCam;

    //position of the mouse
    public Vector3 mousePos;

    //check if gun is being actively held
    private bool isGunBeingHeld;

    public void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        isGunBeingHeld = false;

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
            if (Input.GetMouseButtonDown(0))
            {
                //instantiate(instantiated game object, spawn point, rotation)
                Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
            }
        }
    }

    public void Activate()
    {
        isGunBeingHeld = true;
    }

}

