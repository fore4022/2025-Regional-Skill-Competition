
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject go;
    public GameObject ui;
    public Camera cam;
    public Text text;
    public Text ttt;
    public Text coin;
    public List<GameObject> objs;
    public int price;
    public int index =0;

    public void OnEnable()
    {
        if(Managers.Game.it.Count == 0)
        {
            Managers.Game.it.Add(false);
            Managers.Game.it.Add(false);
            Managers.Game.it.Add(false);
            Managers.Game.it.Add(false);
            Managers.Game.it.Add(false);
        }
        Next(0);
    }
    public void Update()
    {
        coin.text = $"{Managers.Game.totalCoin:N0} G";

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
                Next(0);
                ui.SetActive(true);
                go.SetActive(false);
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine(SetSize());
                ui.SetActive(false);

                foreach(GameObject go in objs)
                {
                    go.SetActive(false);
                }
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
    public void Next(int sign)
    {
        objs[index].SetActive(false);

        index += sign;

        if(index < 0)
        {
            index = objs.Count - 1;
        }
        else if(index == objs.Count)
        {
            index = 0;
        }

        objs[index].SetActive(true);


        switch(index)
        {
            case 0:
                text.text = "Oxygen 1lv";
                price = 2000;

                break;
            case 1:
                text.text = "Oxygen 2lv";
                price = 3000;
                break;
            case 2:
                text.text = "Oxygen 3lv";
                price = 5000;
                break;
            case 3:
                text.text = "backpack s";
                price = 2500;
                break;
            case 4:
                text.text = "backpack l";
                price = 5000;
                break;
        }

        if (Managers.Game.it[index])
        {
            ttt.text = "장착";
        }
        else
        {
            ttt.text = $"{price:N0} G";
        }
    }
    public void Purchase()
    {
        if (Managers.Game.it[index])
        {
            switch (index)
            {
                case 0:
                    Managers.Game.air = 110;
                    break;
                case 1:
                    Managers.Game.air = 125;
                    break;
                case 2:
                    Managers.Game.air = 150;
                    break;
                case 3:
                    Managers.Game.backSize = 6;
                    break;
                case 4:
                    Managers.Game.backSize = 8;
                    break;
            }
            Managers.Game.Log("장착되었습니다.");
        }    
        else
        {

            if (Managers.Game.totalCoin >= price)
            {
                Managers.Game.totalCoin -= price;
                Managers.Game.Log("구매 성공!");
            }
            else
            {
                Managers.Game.Log("돈이 부족합니다.");
            }
        }

    }
}
