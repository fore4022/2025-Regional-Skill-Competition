using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Store_UI : MonoBehaviour
{
    public GameObject go;
    public GameObject store;
    public Text set;
    public int index = 0;
    public bool open = false;
    public GameObject a1;
    public GameObject a2;
    public GameObject a3;
    public GameObject a4;
    public GameObject a5;

    private void Update()
    {
        if(open)
        {
            if(Input.GetKey(KeyCode.Escape))
            {
                open = false;
                store.SetActive(false);
                go.gameObject.SetActive(true);

                StartCoroutine(CameraMoving());
            }

            return;
        }

        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) <= 3)
        {
            go.gameObject.SetActive(true);

            Vector3 direction = transform.position - Managers.Game.player.cam.transform.position;
            go.transform.rotation = Quaternion.LookRotation(direction);

            if (Input.GetKeyDown(KeyCode.F))
            {
                open = true;
                store.SetActive(true);
                Next(0);
                go.gameObject.SetActive(false);

                StartCoroutine(CameraMoving());
            }
        }
        else
        {
            go.SetActive(false);
        }
    }
    public IEnumerator CameraMoving()
    {
        float targetSize;
        float currentSize = Camera.main.fieldOfView;

        if(currentSize == 30)
        {
            targetSize = 60;
        }
        else
        {
            targetSize = 30;
        }

        float totalTime = 0;
        float targetTime = 0.5f;

        while (totalTime != targetTime)
        {
            totalTime += Time.deltaTime;

            if (totalTime > targetTime)
            {
                totalTime = targetTime;
            }

            Camera.main.fieldOfView = Mathf.Lerp(currentSize, targetSize, totalTime/ targetTime);

            yield return null;
        }
    }
    public void Next(int sign)
    {
        index += sign;

        if(index == -1)
        {
            index = 4;
        }
        else if(index == 5)
        {
            index = 0;
        }

        switch(index)
        {
            case 0:
                if (Managers.Game.a1)
                {
                    set.text = "2,000 G";
                }
                else
                {
                    set.text = "ÀåÂø";
                }
                a1.SetActive(true);
                a2.SetActive(false);
                a3.SetActive(false);
                a4.SetActive(false);
                a5.SetActive(false);
                break;
            case 1:
                if (Managers.Game.a2)
                {
                    set.text = "3,000 G";
                }
                else
                {
                    set.text = "ÀåÂø";
                }
                a1.SetActive(false);
                a2.SetActive(true);
                a3.SetActive(false);
                a4.SetActive(false);
                a5.SetActive(false);
                break;
            case 2:
                if (Managers.Game.a3)
                {
                    set.text = "5,000 G";
                }
                else
                {
                    set.text = "ÀåÂø";
                }
                a1.SetActive(false);
                a2.SetActive(false);
                a3.SetActive(true);
                a4.SetActive(false);
                a5.SetActive(false);
                break;
            case 3:
                if (Managers.Game.a4)
                {
                    set.text = "3,000 G";
                }
                else
                {
                    set.text = "ÀåÂø";
                }
                a1.SetActive(false);
                a2.SetActive(false);
                a3.SetActive(false);
                a4.SetActive(true);
                a5.SetActive(false);
                break;
            case 4:
                if (Managers.Game.a5)
                {
                    set.text = "6,000 G";
                }
                else
                {
                    set.text = "ÀåÂø";
                }
                a1.SetActive(false);
                a2.SetActive(false);
                a3.SetActive(false);
                a4.SetActive(false);
                a5.SetActive(true);
                break;
        }
    }
    public void Set()
    {
        switch(index)
        {
            case 0:
                if(Managers.Game.a1)
                {
                    if(Managers.Game.totalCoin >= 2000)
                    {
                        Managers.Game.totalCoin -= 2000;
                        Managers.Game.a1 = false;
                        Next(0);
                    }
                }
                else
                {
                    Managers.Game.air = 115;
                }
                break;
            case 1:
                if (Managers.Game.a2)
                {
                    if (Managers.Game.totalCoin >= 3000)
                    {
                        Managers.Game.totalCoin -= 3000;
                        Managers.Game.a2 = false;
                        Next(0);
                    }
                }
                else
                {
                    Managers.Game.air = 125;
                }
                break;
            case 2:
                if (Managers.Game.a3)
                {
                    if (Managers.Game.totalCoin >= 5000)
                    {
                        Managers.Game.totalCoin -= 5000;
                        Managers.Game.a3 = false;
                        Next(0);
                    }
                }
                else
                {
                    Managers.Game.air = 150;
                }
                break;
            case 3:
                if (Managers.Game.a4)
                {
                    if (Managers.Game.totalCoin >= 3000)
                    {
                        Managers.Game.totalCoin -= 3000;
                        Managers.Game.a4 = false;
                        Next(0);
                    }
                }
                else
                {
                    Managers.Game.inventorySize = 6;
                }
                break;
            case 4:
                if (Managers.Game.a5)
                {
                    if (Managers.Game.totalCoin >= 5000)
                    {
                        Managers.Game.totalCoin -= 5000;
                        Managers.Game.a5 = false;
                        Next(0);
                    }
                }
                else
                {
                    Managers.Game.inventorySize = 8;
                }
                break;
        }
    }
}