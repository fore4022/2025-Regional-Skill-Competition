
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject go;
    public GameObject open;
    public GameObject doo;
    public GameObject ui;
    public bool o = false;

    public void Start()
    {
        ui.SetActive(false);
    }
    public void Update()
    {
        if(o && !ui.activeSelf)
        {
            doo.SetActive(true);
            gameObject.SetActive(false);
            Managers.Game.clearUI.SetActive(true);
            Managers.Game.clear = true;
        }

        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) < 2)
        {
            Vector3 vec = transform.position - Managers.Game.player.gameObject.transform.position;
            go.transform.rotation = Quaternion.LookRotation(vec);

            go.SetActive(true);

            if(Input.GetKeyDown(KeyCode.F))
            {
                ui.SetActive(true);
                o = true;
            }
        }
        else
        {
            go.SetActive(false);
        }
    }
}
