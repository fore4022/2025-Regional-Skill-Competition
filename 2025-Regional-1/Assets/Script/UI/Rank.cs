
using UnityEngine;

public class Rank : MonoBehaviour
{
    public GameObject go;
    public GameObject ui;

    public void Update()
    {
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) < 8)
        {
            Vector3 vec = transform.position - Managers.Game.player.gameObject.transform.position;
            go.transform.rotation = Quaternion.LookRotation(vec);

            if (!ui.activeSelf)
            {
                go.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                ui.SetActive(true);
                go.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ui.SetActive(false);
            }
        }
        else
        {
            go.SetActive(false);
            ui.SetActive(false);
        }
    }
}
