using UnityEngine;

public class DeleteEffect : MonoBehaviour
{
    public float timer;



    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 3)
        {
            Object.Destroy(gameObject);
        }
    }
}
