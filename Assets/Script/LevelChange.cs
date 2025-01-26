using UnityEngine;

public class LevelChange : MonoBehaviour
{
    //enemy Manager script
    public EnemyManager enemyManager;

    private void Start()
    {
        enemyManager = FindAnyObjectByType<EnemyManager>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) ; //&& isLevelBeat == true
        {
            if (enemyManager.isLevelBeat == false)
            {
                return;
            }
            if (collision.CompareTag("PlayerBullet") || collision.CompareTag("EnemyBullet"))
            {
                return;
            }
            Debug.Log("Next Level!");
            //next level
            enemyManager.isLevelBeat = false;
            GameManager.instance.NextLevel();
        }
    }
}
