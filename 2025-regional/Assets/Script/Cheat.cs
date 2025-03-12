using UnityEngine;
using UnityEngine.SceneManagement;
public class Cheat : MonoBehaviour
{
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1))
        {
            Managers.Game.player.health = 100;
            Managers.Game.player.air = 100;
        }
        else if(Input.GetKeyDown(KeyCode.F2))
        {

        }
        else if(Input.GetKeyDown(KeyCode.F3))
        {
            SceneManager.LoadScene($"InGame_{Managers.Game.stageIndex}");
        }
        else if (Input.GetKeyDown(KeyCode.F4))
        {
            if(Managers.Game.stageIndex != 5)
            {
                Managers.Game.stageIndex++;
            }

            SceneManager.LoadScene($"InGame_{Managers.Game.stageIndex}");
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            if(Time.timeScale == 0)
            {
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }
}