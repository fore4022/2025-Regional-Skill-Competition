using System.Collections;
using UnityEngine;
public class Quit_UI : MonoBehaviour
{
    public GameObject go;
    public bool a = false;

    private void Update()
    {
        if(a)
        {
            return;
        }

        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) <= 6)
        {
            go.gameObject.SetActive(true);
        }
        else
        {
            go.gameObject.SetActive(false);
        }
    }
    public void Yes()
    {
        Application.Quit();
    }
    public void No()
    {
        StartCoroutine(aaa());
    }

    private IEnumerator aaa()
    {
        a = true;
        go.SetActive(false);
        yield return new WaitForSeconds(2f);
        a = false;
    }
}