
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject go;
    public GameObject open;
    public GameObject ui;
    public bool o = false;
    public bool c = false;

    public void Start()
    {
        ui.SetActive(false);
    }
    public void Update()
    {
        if(o)
        {
            if(!ui.activeSelf)
            {
                c = true;
            }
            else
            {

                return;
            }
        }

        if(c)
        {
            if(Vector3.Distance(open.transform.position, transform.position) < 0.1)
            {
                return;
            }

            Vector3 vec = (open.transform.position - transform.position).normalized;

            transform.position += vec;

            return;
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
