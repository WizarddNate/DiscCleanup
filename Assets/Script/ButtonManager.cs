using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{

    //Start the game
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Level1");
    }

    //Guess what this does
    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void TrapButton()
    {
        SceneManager.LoadSceneAsync("IntroVideo");
    }
}
