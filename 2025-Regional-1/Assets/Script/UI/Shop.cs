
using System.Collections;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject go;
    public GameObject ui;
    public Camera cam;

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
                StartCoroutine(SetSize());
                ui.SetActive(true);
                go.SetActive(false);
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine(SetSize());
                ui.SetActive(false);
            }
        }
        else
        {
            go.SetActive(false);
        }
    }
    public IEnumerator SetSize()
    {
        float cur = cam.fieldOfView;
        float target = 0;

        if(cur == 60)
        {
            Managers.Game.player.transform.GetChild(1).gameObject.SetActive(false);
            target = 30;
        }
        else
        {
            Managers.Game.player.transform.GetChild(1).gameObject.SetActive(true);
            target = 60;
        }

        float to = 0;
        float tar = 0.1f;

        while (to != tar)
        {
            to += Time.deltaTime;
            if (to > tar)
            {
                to = tar;
            }

            cam.fieldOfView = Mathf.Lerp(cur, target, to / tar);

            yield return null;
        }
    }
}
