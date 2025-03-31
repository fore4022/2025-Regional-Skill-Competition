using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject effect;
    public GameObject ui;
    public Text text;
    public Camera cam;

    public List<GameObject> oo;
    public int[] aaa = new int[] { 1000, 1500, 2000, 1500, 2000 };
    public bool[] bbb = new bool[] { true, true, true, true, true };

    public int index = 0 ;
    public void Update()
    {
        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) < 12f)
        {
            effect.SetActive(true);
        }
        else
        {
            if(ui.activeSelf)
            {

                effect.SetActive(false);
            }
            else
            {

                effect.SetActive(false);
            }
        }

        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) < 4f)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine(ZoomS());
                ui.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine(ZoomL());
                ui.SetActive(false);
            }
        }
    }

    public void Next(int i)
    {
        index += i;

        if(index == oo.Count)
        {
            index = 0;
        }
        else if(index == -1)
        {
            index = oo.Count - 1;
        }

        for(int j = 0; j < oo.Count; j++)
        {
            if(index == j)
            {
                oo[j].SetActive(true);
            }
            else
            {
                oo[j].SetActive(false);
            }
        }

        if (bbb[index])
        {
            text.text = $"{aaa[index]:N0} G";
        }
        else
        {
            text.text = "ÀåÂø";
        }
    }
    public void Purchase()
    {
        if(Managers.Game.totalCoin >= aaa[index])
        {
            if (bbb[index])
            {
                bbb[index] = false;
                Managers.Game.Log("±¸¸Å ¿Ï·á!");
            }
            else
            {
                Managers.Game.Log("ÀåÂø!");
            }
        }
        else
        {
            Managers.Game.Log("µ·ÀÌ ºÎÁ·ÇÕ´Ï´Ù.");
        }

        Next(0);
    }

    public IEnumerator ZoomS()
    {
        float to = 0;
        float tar = 0.5f;

        while (to != tar)
        {
            to += Time.deltaTime;

            if (to > tar)
            {
                to = tar;
            }

            cam.fieldOfView = Mathf.Lerp(60, 30, to / tar);

            yield return null;
        }
    }
    public IEnumerator ZoomL()
    {
        float to = 0;
        float tar = 0.5f;

        while (to != tar)
        {
            to += Time.deltaTime;

            if (to > tar)
            {
                to = tar;
            }

            cam.fieldOfView = Mathf.Lerp(30, 60, to / tar);

            yield return null;
        }
    }
}
