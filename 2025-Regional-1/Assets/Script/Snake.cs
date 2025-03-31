using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public GameObject tar1;
    public GameObject tar2;

    public void Update()
    {
        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) < 6f)
        {
            transform.LookAt(Managers.Game.player.transform.position);
            transform.Rotate(new Vector3(0, 180, 0));

            
        }
        else
        {

        }
    }
}
