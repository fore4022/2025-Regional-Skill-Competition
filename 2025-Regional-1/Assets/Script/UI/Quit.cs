using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public int index = 0;
    public GameObject go;

    public void Update()
    {
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) < 2)
        {
            go.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                index++;

                if(index == 2)
                {
                    Application.Quit();
                }
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
            }
        }
    }
}
