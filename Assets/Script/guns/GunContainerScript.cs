using UnityEngine;

public class GunContainerScript : MonoBehaviour
{
    public Transform Player;

    public GameObject gunContainer;

    void Update()
    {
        //Make ObjectA's position match objectB
         gameObject.transform.position = Player.position;
    }
    public void DestroyAllChildren()
    {
        Debug.Log("Destroy children function successfully called!");

        Object.Destroy(gunContainer.transform.GetChild(0).gameObject);
        //while (transform.childCount > 0)
        //{
        //    Debug.Log("script called!");
        //    DestroyImmediate(transform.GetChild(0).gameObject);
        //}

    }
}


