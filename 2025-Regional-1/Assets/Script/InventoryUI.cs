using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<Sprite> sps;
    public List<Image> imgs;

    public void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            imgs[i].gameObject.SetActive(true);
        }
    }
    public void Update()
    {
        for(int i = 0; i < Managers.Game.backSize; i++)
        {
            if(Managers.Game.inven.Count <= i)
            {
                imgs[i].sprite = null;
            }
            else
            {
                imgs[i].sprite = sps[Managers.Game.inven[i]];
            }

        }
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Managers.Game.inven.Count >= 1)
            {
                Use(0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Managers.Game.inven.Count >= 2)
            {
                Use(1);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (Managers.Game.inven.Count >= 3)
            {
                Use(2);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            if (Managers.Game.inven.Count >= 4)
            {
                Use(3);
            }

        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            if (Managers.Game.inven.Count >= 5)
            {
                Use(4);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            if (Managers.Game.inven.Count >= 6)
            {
                Use(5);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            if (Managers.Game.inven.Count >= 7)
            {
                Use(6);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            if (Managers.Game.inven.Count >= 8)
            {
                Use(7);
            }
        }
    }

    public void Use(int index)
    {

        switch (Managers.Game.inven[index])
        {
            case 6:
                StartCoroutine(Managers.Game.player.P1());
                break;
            case 7:
                StartCoroutine(Managers.Game.player.P2());
                break;
            case 8:
                StartCoroutine(Managers.Game.player.P3());
                break;
            case 9:
                StartCoroutine(Managers.Game.player.P4());
                break;
            case 10:
                StartCoroutine(Managers.Game.player.P5());

                break;
            case 11:
                StartCoroutine(Managers.Game.player.P6());

                break;
        }

        Managers.Game.inven.RemoveAt(index);
    }
}
