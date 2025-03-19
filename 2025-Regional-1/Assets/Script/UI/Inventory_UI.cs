using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    public List<Sprite> sp;

    public GameObject slot;
    public List<Image> img;

    public void Start()
    {
        for(int i = 0; i < Managers.Game.backSize; i++)
        {
            GameObject go = Instantiate(slot, transform);

            img.Add(go.transform.GetChild(0).GetComponent<Image>());
        }
    }
    public void Update()
    {
        for(int i = 0; i < img.Count; i++)
        {
            if(i < Managers.Game.inven.items.Count)
            {
                img[i].sprite = sp[i];
            }
            else
            {
                img[i].sprite = null;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Use(Managers.Game.inven.Index(1));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Use(Managers.Game.inven.Index(2));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Use(Managers.Game.inven.Index(3));
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Use(Managers.Game.inven.Index(4));
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Use(Managers.Game.inven.Index(5));
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Use(Managers.Game.inven.Index(6));
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Use(Managers.Game.inven.Index(7));
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Use(Managers.Game.inven.Index(8));
        }
    }
    public void Use(int i)
    {
        if(i == -1 || i <= 5)
        {
            return;
        }

        switch(i)
        {
            case 6:
                Managers.Game.player.health = Mathf.Min(100, Managers.Game.player.health + 10);
                StartCoroutine(Active(Managers.Game.player.hide));
                break;
            case 7:
                Managers.Game.player.air = Mathf.Min(Managers.Game.air, Managers.Game.player.air + 20);
                StartCoroutine(Active(Managers.Game.player.hide));
                break;
            case 8:
                Managers.Game.val[Random.Range(0, Managers.Game.val.Count)].particle.SetActive(true);
                StartCoroutine(Active(Managers.Game.player.hide));
                break;
            case 9:
                StartCoroutine(SpeedS());
                break;
            case 10:
                StartCoroutine(SpeedL());
                break;
            case 11:
                Managers.Game.player.cap.enabled = false;
                StartCoroutine(Active(Managers.Game.player.hide));
                break;
        }
    }

    private IEnumerator SpeedS()
    {
        Managers.Game.player.speedS.SetActive(true);
        Managers.Game.player.speed += 2;
        yield return new WaitForSeconds(0.5f);
        Managers.Game.player.speedS.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        Managers.Game.player.speed -= 2;
    }
    private IEnumerator SpeedL()
    {
        Managers.Game.player.speedL.SetActive(true);
        Managers.Game.player.speed += 3.5f;
        yield return new WaitForSeconds(0.5f);
        Managers.Game.player.speedL.SetActive(false);
        yield return new WaitForSeconds(4.5f);
        Managers.Game.player.speed -= 3.5f;
    }
    private IEnumerator Active(GameObject g)
    {
        g.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        g.SetActive(false);
    }
}
