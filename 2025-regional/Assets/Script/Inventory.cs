using System.Collections.Generic;
using System.Linq;
public class Inventory
{
    public Dictionary<string, int> inventory = new();

    public void Add(string id)
    {
        List<int> a = inventory.Values.ToList();

        if(a.Count >= 6)
        {
            return;
        }

        inventory.Add(id, 1);
        Managers.Game.inven.UpdateInven();
    }
}