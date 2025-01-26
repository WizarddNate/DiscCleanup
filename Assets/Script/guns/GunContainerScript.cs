using UnityEngine;

public class GunContainerScript : MonoBehaviour
{
    public Transform Player;

    public GameObject gunContainer;

    private GameObject gun;



    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gun")) ;
        {
            //possibly unneeded code
        }
    }

    void Update()
    {
        //Make ObjectA's position match objectB
         gameObject.transform.position = Player.position;

        
    }
    public void DestroyAllChildren()
    {
        Debug.Log("Destroy children function successfully called!");

        Object.Destroy(gunContainer.transform.GetChild(0).gameObject);
        //SwapGun();

    }


    //what is this doing? 
    public void SwapGun()
    {
        GameObject newGun = GameObject.FindWithTag("Gun");
        Object.Instantiate(newGun, gunContainer.transform.position, gunContainer.transform.rotation);
        newGun.transform.SetParent(gunContainer.transform);
    }
}


