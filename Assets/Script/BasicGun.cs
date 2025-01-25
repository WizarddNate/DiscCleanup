using UnityEngine;
using UnityEngine.InputSystem;

public class BasicGun : MonoBehaviour
{
    //vars
    public Transform shootingPoint;
    public GameObject bulletPrefab;

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            //instantiate(instantiated game object, spawn point, rotation)
            Instantiate(bulletPrefab, shootingPoint.position, transform.rotation);
        }
    }
}

