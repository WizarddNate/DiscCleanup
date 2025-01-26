using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //GameObject oneshot

    [Header("-------- Audio Clip --------")]
    public AudioClip goBekkyGoStart;
    public AudioClip goBekkyGoLoop;
    public AudioClip bubbleRifle;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        //hiiiii
    }
  
}

