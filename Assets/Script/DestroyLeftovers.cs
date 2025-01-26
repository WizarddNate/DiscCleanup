using System;
using UnityEngine;

public class DestroyLeftovers : MonoBehaviour
{
    //camera
    public mainCamera mc;
    private GameObject mcObject;

    //gun container
    public GunContainerScript gcs;
    private GameObject gcsObject;

    //player
    public Player ps;
    private GameObject psObject;

    //theme song
    public AudioManager ams;
    private GameObject amsObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        //get game objects

        mc = FindFirstObjectByType<mainCamera>();
        mcObject = mc.gameObject;
        if (mc != null)
        {
            //destroy them.
            Destroy(mcObject);
        }
        
        gcs = FindFirstObjectByType<GunContainerScript>();
        gcsObject = gcs.gameObject;
        if (gcs != null)
        {
            Destroy(gcsObject);
        }

        ps = FindFirstObjectByType<Player>();
        psObject = ps.gameObject;
        if (ps != null)
        {
            Destroy(psObject);
        }

        ams = FindFirstObjectByType<AudioManager>();
        amsObject = ams.gameObject;
        if (ams != null)
        {
            Destroy(amsObject);
        } 
    }

}
