using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    private List<string> lvlsList = new List<string>();


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
           
    }

    public void NextLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        //if (currentScene.name == "Level6")
        //{
        //    SceneManager.LoadSceneAsync("WinScreen");
        //}
        //else
        //{
        //    SceneManager.LoadScenzeAsync(SceneManager.GetActiveScene().buildIndex + 1);
        //}


        //list of every level name (in string format)
        //need to find a way to add a ton of things to a list at once
        //lvlsList.Add("Level1", "Level2", "Level3", "Level4", "Level5");

        //randomly select one string in list
        //currently grabbing the index but not the string itself im pretty sure
        int randomIndex = Mathf.RoundToInt(Random.Range(0, lvlsList.Count -1));
        Debug.Log("List size: " + lvlsList.Count);
        Debug.Log("index selected: " + randomIndex);

        

        if (lvlsList.Count <= 0) //change to if level list index <= 0
        {
            //SceneManager.LoadSceneAsync();

            //remove that level from list
            lvlsList.RemoveAt(randomIndex);
        }
        else
        {
            SceneManager.LoadSceneAsync("WinScreen");
        }
    }

}
