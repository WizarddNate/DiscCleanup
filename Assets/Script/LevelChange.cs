using UnityEngine;

public class LevelChange : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) ;
        {
            if (collision.CompareTag("PlayerBullet"))
            {
                return;
            }
            Debug.Log("Next Level!");
            //next level
            GameManager.instance.NextLevel();
        }
    }
}
