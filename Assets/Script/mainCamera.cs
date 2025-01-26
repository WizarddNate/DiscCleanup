using UnityEngine;

public class mainCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        Camera cam = Camera.main;
        DontDestroyOnLoad(cam);
    }
}
