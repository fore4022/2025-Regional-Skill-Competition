using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject effect;
    public GameObject ui;
    public Camera cam;
    public SkinnedMeshRenderer ren;
    public List<int> aaa = new List<int>() { 1000, 1500, 2000, 1500, 2500 };

    public Text text;
    public Text price;

    public List<GameObject> item;
    public int index = 0;

    public void OnEnable()
    {
        Next(0);
    }
    public void Update()
    {
        text.text = $"{Managers.Game.totalCoin} G";

        if(Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 10)
        {
            if(!ui.activeSelf)
            {

                effect.SetActive(true);
            }
            else

            {
                effect.SetActive(false);

            }

            if(Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 3)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    ren.enabled = false;
                    ui.SetActive(true);
                    StartCoroutine(Camm(30));
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ren.enabled = true;
                    ui.SetActive(false);
                    StartCoroutine(Camm(60));
                }
            }
        }
        else
        {
            effect.SetActive(false);

        }
    }
    public void Next(int sign)
    {
        index += sign;

        if(index > 4)
        {
            index = 0;
        }
        else if(index < 0)
        {
            index = 4;
        }

        for(int i = 0; i < 5; i++)
        {
            if(i == index)
            {
                item[i].SetActive(true);
            }
            else
            {
                item[i].SetActive(false);
            }
        }

        if (!Managers.Game.bbb[index])
        {
            price.text = $"{aaa[index]:N0} G";

        }
        else
        {
            switch(index)
            {
                case 0:
                    Managers.Game.air = 110;
                    break;
                case 1:

                    Managers.Game.air = 120;
                    break;
                case 2:
                    Managers.Game.air = 135;

                    break;
                case 3:
                    Managers.Game.backSize = 6;

                    break;
                case 4:
                    Managers.Game.backSize = 8;

                    break;
            }

            price.text = "장착하기";
        }
    }
    public void Purchase()
    {
        if(Managers.Game.totalCoin >= aaa[index] || Input.GetKey(KeyCode.F2))
        {
            if(!Input.GetKey(KeyCode.F2))
            {
                Managers.Game.totalCoin -= aaa[index];
            }

            Managers.Game.Send("구매하였습니다.");

            Managers.Game.bbb[index] = true;
        }
        else
        {

            if (Managers.Game.bbb[index])
            {
                Managers.Game.Send("장착했습니다..");
            }
            else
            {
                Managers.Game.Send("골드가 부족합니다.");
            }
        }

        Next(0);
    }
    private IEnumerator Camm(float tarr)
    {
        float t = 0;
        float tar = 0.2f;

        float vec = cam.fieldOfView;

        while (t != tar)
        {
            t += Time.deltaTime;

            if (t > tar)
            {
                t = tar;
            }

            cam.fieldOfView = Mathf.Lerp(vec, tarr, t / tar);

            yield return null;
        }
    }
}
