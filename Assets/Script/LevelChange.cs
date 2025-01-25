using UnityEngine;

public class LevelChange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("PlayerBullet")) ;
        {
            Debug.Log("Bullet!");
            //Destroy(gameObject);
        }
        if (collision.CompareTag("Player")) ;
        {
            Debug.Log("Next Level!");
            //next level
            GameManager.instance.NextLevel();
        }
    }
}
