using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Image> aaa = new();
    public GameObject slot;

    public List<Sprite> ccc;

    public void Start()
    {
        for(int i = 0; i < Managers.Game.packSize; i++)
        {
            GameObject go = Instantiate(slot, transform);
            aaa.Add(go.transform.GetChild(0).gameObject.GetComponent<Image>());
            go.GetComponentInChildren<Text>().text = $"{i + 1}";
        }
    }
    public void Update()
    {
        for(int i = 0; i < Managers.Game.packSize; i++)
        {
            if(i >= Managers.Game.inven.Count)
            {
                aaa[i].sprite = null;
            }
            else
            {
                aaa[i].sprite = ccc[Managers.Game.inven[i]];
            }
        }
    }
}
