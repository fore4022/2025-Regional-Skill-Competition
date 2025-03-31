using System.Collections;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public GameObject gooo;
    public GameObject ui;
    public bool a = true;

    public void Update()
    {
        if(a)
        {
            if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) < 2f)
            {
                ui.SetActive(true);
            }
            else
            {
                ui.SetActive(false);
            }
        }
    }
    public void Quitt()
    {
        gooo.SetActive(true);
    }
    public void No()
    {
        StartCoroutine(aaa());
    }
    private IEnumerator aaa()
    {
        a = false;
        yield return new WaitForSeconds(2f);
        a = true;
    }
}
