using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("StartGame() called. Loading _Scene_0.");
        SceneManager.LoadScene("_Scene_0");
    }
}
