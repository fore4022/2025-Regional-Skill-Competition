using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{
    public GameObject go;
    public GameObject ui;

    public void Update()
    {
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) < 2)
        {
            go.SetActive(true);

            if(Input.GetKeyDown(KeyCode.F))
            {
                ui.SetActive(true);
            }
            if(Input.GetKeyDown(KeyCode.Space))
            {
                ui.SetActive(false);
            }
        }
    }
}
