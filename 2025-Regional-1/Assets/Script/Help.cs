using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Help : MonoBehaviour
{

    public GameObject effect;
    public GameObject ui;

    public void Update()
    {

        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 10)
        {
            if (!ui.activeSelf)
            {

                effect.SetActive(true);
            }
            else

            {
                effect.SetActive(false);

            }

            if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 5)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    ui.SetActive(true);
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ui.SetActive(false);
                }
            }
        }
        else
        {
            effect.SetActive(false);

        }
    }
}
