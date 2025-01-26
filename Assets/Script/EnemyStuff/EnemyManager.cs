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
    public int total;
    


    ////make list of children
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.tag == "Enemy")
            {
                enemiesList.Add(child.gameObject);
                //Debug.Log("Enemy counted");
            }
        }
        total = enemiesList.Count;
    }

    private void Update()
    {
        Debug.Log($"there are {total} enemies.");
        //Debug.Log($"count: {enemiesList.Count}");
        if (total <= 0)
        {
            //when list is empty, levelBeat = true
            isLevelBeat = true;
        }
    }
    
    

}
