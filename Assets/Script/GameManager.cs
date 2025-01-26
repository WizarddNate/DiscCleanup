using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager instance;



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

        if (currentScene.name == "Level6")
        {
            SceneManager.LoadSceneAsync("WinScreen");
        }
        else
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
