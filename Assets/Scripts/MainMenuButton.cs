using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void MainMenu()
    {
        Debug.Log("MainMenu() called. Loading StartScreen.");
        SceneManager.LoadScene("StartScreen");
    }
}
