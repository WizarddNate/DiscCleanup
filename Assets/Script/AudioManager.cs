using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //GameObject oneshot

    public AudioSource songStart;
    public AudioSource songLoop;

    private float startLength;
    //1.52

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        songStart = GetComponent<AudioSource>();
        songLoop = GetComponent<AudioSource>();

        startLength = songStart.clip.length;
        Debug.Log("song length: " + startLength);

        songStart.Play(0);
    }

    private void Update()
    {
        if (startLength > 0)
        {
            startLength -= Time.deltaTime;
        }
        if (startLength <= 0)
        {
            songStart.Stop();
            songLoop.Play(0);
        }
    }
}

