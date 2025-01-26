using System;
using UnityEngine;

public class DestroyLeftovers : MonoBehaviour
{
    //camera
    public mainCamera mc;
    public GameObject mcObject;

    //gun container
    public GunContainerScript gcs;
    public GameObject gcsObject;

    //player
    public Player ps;
    public GameObject psObject;

    //theme song
    public AudioManager ams;
    public GameObject amsObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //get game objects
        mc = FindFirstObjectByType<mainCamera>();
        mcObject = gcs.gameObject;

        gcs = FindFirstObjectByType<GunContainerScript>();
        gcsObject = gcs.gameObject;

        ps = FindFirstObjectByType<Player>();
        psObject = ps.gameObject;

        ams = FindFirstObjectByType<AudioManager>();
        amsObject = ams.gameObject;

        //destroy them
        Destroy(mcObject);
        Destroy(gcsObject);
        Destroy(psObject);
        Destroy(amsObject);
    }

}
