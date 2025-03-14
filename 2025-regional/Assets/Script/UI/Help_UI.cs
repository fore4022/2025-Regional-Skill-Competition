using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Help_UI : MonoBehaviour
{
    public GameObject go;
    public GameObject ui;
    public List<GameObject> imgs = new();

    private void Update()
    {
        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) <= 10)
        {
            go.gameObject.SetActive(true);

            Vector3 direction = transform.position - Managers.Game.player.cam.transform.position;
            go.transform.rotation = Quaternion.LookRotation(direction);

            if (Input.GetKeyDown(KeyCode.F))
            {
                ui.gameObject.SetActive(true);

                StartCoroutine(Showing());
            }
            else if(Input.GetKey(KeyCode.Escape))
            {
                ui.gameObject.SetActive(false);
            }
        }
        else
        {
            go.gameObject.SetActive(false);
        }
    }

    public IEnumerator Showing()
    {
        foreach(GameObject go in imgs)
        {
            go.SetActive(true);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));

        imgs[0].SetActive(false);
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));

        imgs[1].SetActive(false);
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));

        imgs[2].SetActive(false);
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));

        imgs[3].SetActive(false);
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Mouse0));

        ui.SetActive(false);
    }
}