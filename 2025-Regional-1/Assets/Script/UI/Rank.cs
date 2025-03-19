
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Rank : MonoBehaviour
{
    public GameObject go;
    public GameObject ui;
    public List<GameObject> rank;

    public void OnEnable()
    {
        Managers.Game.rank.OrderByDescending(o => o.score);

        foreach(GameObject go in rank)
        {
            go.SetActive(false);
        }

        int i = 0; 

        foreach((string name, int score) a in Managers.Game.rank)
        {
            rank[i].SetActive(true);

            rank[i].transform.GetChild(1).GetComponent<Text>().text = a.name;
            rank[i].transform.GetChild(2).GetComponent<Text>().text = $"{a.score:N0}";

            i++;
        }
    }
    public void Update()
    {
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
                ui.SetActive(true);
                go.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ui.SetActive(false);
            }
        }
        else
        {
            go.SetActive(false);
            ui.SetActive(false);
        }
    }
    
}
