
using UnityEngine;

public class OPPPP : MonoBehaviour
{
    public void Start()
    {
        if(Managers.Game.stageIndex != 1)
        {
            gameObject.SetActive(false);
        }
    }
    public void Ssstart()
    {
        gameObject.SetActive(false);
    }
    public void QQuit()
    {
        Application.Quit();
    }
}
