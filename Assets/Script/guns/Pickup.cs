using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class Pickup : MonoBehaviour
{
    // vars //

    //make gun container a game object so it can be made into the parent object
    public GameObject parentContainer;

    //reference gun containter script
    public GunContainerScript gcs;

    //reference basic gun script
    public Gun gun;
    //box gun's collider
    public BoxCollider2D collider;

    //check if a gun is already being held
    private static bool gunEquipped; 

    private void Start()
    {
        gcs = FindFirstObjectByType<GunContainerScript>();
        parentContainer = gcs.gameObject;

        if (!gunEquipped)
        {
            //BasicGun.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (gunEquipped == true)
            {
                DestroyOldGun();
            }
            //disable box collider
            collider.enabled = false;
            PickUp();
            //Debug.Log("pick up!");
        }
    }

    private void PickUp()
    {
        //become child of gun container variable
        gameObject.transform.SetParent(parentContainer.transform);
        gameObject.transform.localPosition = new Vector3(0, 0, -2);

        //gun isBeingHeld = true 
        if (gameObject.CompareTag("Gun") || gameObject.CompareTag("Shotgun"))
        {
            gun.Activate();
        }
        

        //equipped = true
        gunEquipped = true;
    }

    private void DestroyOldGun()
    {
        //equipped = false
        gunEquipped = false;

        //call function in gun container to destroy all children
        gcs.DestroyAllChildren(); //how to call this without needing the variable, or hardcoding the game object in question in?


        //Debug.Log("Old Gun Destroyed");
    }
}
