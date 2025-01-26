using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class EnemyManager : MonoBehaviour
{

    //empty list for game objects
    List<GameObject> enemiesList = new List<GameObject>();

    //bool for if the enemies have been cleared or not
    public bool isLevelBeat = false;

    


    ////make list of children
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Enemy")
            {
                enemiesList.Add(child.gameObject);
                Debug.Log("Enemy counted");
            }
        }
    }

    private void Update()
    {
        
        Debug.Log($"count: {enemiesList.Count}");
        if (enemiesList.Count == 0)
        {
            //when list is empty, levelBeat = true
            isLevelBeat = true;
        }
    }
    

    

}
