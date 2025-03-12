using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Inventory
{
    public Dictionary<string, int> inventory = new();

    public void Add(string id)
    {
        List<int> a = inventory.Values.ToList();

        a.RemoveAll(o => o == 0);

        if(inventory.ContainsKey(id))
        {
            inventory[id]++;

            return;
        }

        if(a.Count >= 6)
        {
            return;
        }
        else
        {
            inventory.Add(id, 1);
        }
    }
}