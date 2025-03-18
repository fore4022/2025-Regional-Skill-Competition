
using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject go;
    public GameObject ui;

    public void Update()
    {
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) < 8)
        {
            Vector3 vec = transform.position - Managers.Game.player.gameObject.transform.position;
            go.transform.rotation = Quaternion.LookRotation(vec);

            go.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                ui.SetActive(true);
            }
        }
        else
        {
            go.SetActive(false);
        }
    }
}
