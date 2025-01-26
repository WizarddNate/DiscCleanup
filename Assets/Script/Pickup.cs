using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup : MonoBehaviour
{
    // vars //

    //make gun container a game object so it can be made into the parent object
    public GameObject parentContainer;

    //reference gun containter script
    public GunContainerScript gunContainter;

    //reference basic gun script
    public BasicGun basicGun;

    public MachineGun machineGun;
    //box gun's collider
    public BoxCollider2D collider;

    //check if a gun is already being held
    private static bool gunEquipped; 

    private void Start()
    {
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
            Debug.Log("pick up!");
        }
    }

    private void PickUp()
    {
        //become child of gun container
        gameObject.transform.SetParent(parentContainer.transform);
        gameObject.transform.localPosition = new Vector3(0, 0, -2);

        //gun isBeingHeld = true 
        if (gameObject.CompareTag("Gun"))
        {
            basicGun.Activate();
        }
        else if (gameObject.CompareTag("Shotgun"))
        {
            machineGun.Activate();
        }

        //equipped = true
        gunEquipped = true;
    }

    private void DestroyOldGun()
    {
        //call function in gun container to destroy all children
        gunContainter.DestroyAllChildren();

        //equipped = false
        gunEquipped = false;


        //Debug.Log("Old Gun Destroyed");
    }
}
