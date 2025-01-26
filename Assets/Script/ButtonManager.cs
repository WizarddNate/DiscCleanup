using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    //Start the game
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(0);
    }

    //Guess what this does
    public void QuitGame()
    {
        Application.Quit();
    }
}
