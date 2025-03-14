using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }
    public void GameQuit()
    {
        Application.Quit();
    }
}
