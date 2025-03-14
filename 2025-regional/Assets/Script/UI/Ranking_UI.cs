using System.Collections.Generic;
using UnityEngine;
public class Ranking_UI : MonoBehaviour
{
    public GameObject go;
    public GameObject ui;
    public List<GameObject> objs;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ui.gameObject.SetActive(false);
        }

        if (ui.activeSelf)
        {
            go.SetActive(false);
            return;
        }

        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) <= 10)
        {
            go.gameObject.SetActive(true);

            Vector3 direction = transform.position - Managers.Game.player.cam.transform.position;
            go.transform.rotation = Quaternion.LookRotation(direction);

            if (Input.GetKeyDown(KeyCode.F))
            {
                ui.gameObject.SetActive(true);
            }
        }
        else
        {
            go.gameObject.SetActive(false);
        }

        if(ui.activeSelf)
        {
            for(int i = 0; i < Mathf.Min(3, Managers.Game.rank.Count); i++)
            {
                objs[i].SetActive(true);
            }
        }
    }
}