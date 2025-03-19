using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<int> items = new();

    public void Add(int index)
    {
        if(items.Count > Managers.Game.backSize)
        {
            return;
        }

        items.Add(index);
    }
    public int Index(int i)
    {
        if(i  < items.Count)
        {
            return items[i];
        }
        else
        {
            return -1;
        }
    }
}
