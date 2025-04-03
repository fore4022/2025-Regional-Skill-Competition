using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valuable : MonoBehaviour
{
    public GameObject effect;
    public bool trap = false;
    public GameObject trapp;
    public int index;

    public void Start()
    {
        foreach(int i in Managers.Game.hash)
        {
            if(i == index)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public void Update()
    {
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 10)
        {
            effect.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (trap)
                {

                }
                else
                {

                }

                Managers.Game.hash.Add(index);
            }
        }
        else
        {
            effect.SetActive(false);

        }
    }
}
