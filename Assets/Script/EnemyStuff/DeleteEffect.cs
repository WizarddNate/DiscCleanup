using UnityEngine;

public class DeleteEffect : MonoBehaviour
{
    public float timer;



    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1.5f)
        {
            Object.Destroy(gameObject);
        }
    }
}
