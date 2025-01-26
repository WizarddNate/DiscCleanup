using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoEnd : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private VideoPlayer videoPlayer;

    //timer to keep it from instantly jumping
    private float wait = 5;

    void Awake()
    {
        // Get the VideoPlayer component from the GameObject with this script attached. 
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.Play();
    }

    private void Update()
    {
        if (wait > 0)
        {
            wait -= Time.deltaTime;
        }
        if (wait <= 0)
        {
            if (videoPlayer.isPlaying == false)
            {
                Debug.Log("YIPPIE!!!");
                //load scene main menu
                SceneManager.LoadSceneAsync("MainMenu");
            }
        }
    }
}
