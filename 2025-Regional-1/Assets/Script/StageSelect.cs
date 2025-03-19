using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    public int index;

    public GameObject go;
    public GameObject g;
    public void Start()
    {
        if(go != null)
        {
            if(Managers.Game.stage == 1)
            {
                go.SetActive(true);
                g.SetActive(false);
            }
            else
            {
                go.SetActive(false);
                g.SetActive(true);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(index == 0)
            {
                SceneManager.LoadScene("Main");
            }
            if (index == 1)
            {
                SceneManager.LoadScene($"InGame_{Managers.Game.stage}");
            }
            if (index == 2)
            {
                SceneManager.LoadScene($"InGame_{Managers.Game.stage + 1}");
            }
        }
    }
}
