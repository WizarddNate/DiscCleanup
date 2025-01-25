using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pickup : MonoBehaviour
{
    //pick up gun
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player manager = collision.GetComponent<Player>();
        if (manager != null)
        {

            //make script on basic gun where the object is glued to bekky and isHeld == true
            //manager.pickupGun(gameObject);
            manager.PickupGun(gameObject);
            Destroy(gameObject);
        }
    }
}
