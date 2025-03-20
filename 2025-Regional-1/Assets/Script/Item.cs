using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject tar;
    public GameObject go;
    private void Start()
    {
        transform.Rotate(0, Random.Range(0, 360), 0);
    }
    public void Update()
    {
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) < 10)
        {
            Vector3 vec = transform.position - Managers.Game.player.gameObject.transform.position;
            go.transform.rotation = Quaternion.LookRotation(vec);

            go.SetActive(true);
        }
        else
        {
            go.SetActive(false);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int i = Random.Range(6, 12);

            Managers.Game.inven.Add(Random.Range(6, 12));

            Debug.Log(i);
            Managers.Game.Log("¾ÆÀÌÅÛ È×µæ");

            Destroy(tar);
        }
    }
}
