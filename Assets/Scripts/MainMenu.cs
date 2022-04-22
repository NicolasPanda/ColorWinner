using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string Main;

    public void StartGame()
    {
        SceneManager.LoadScene(Main);
    }

    // quitter le jeu
    public void QuitGame()
    {
        Application.Quit();
    }
}
