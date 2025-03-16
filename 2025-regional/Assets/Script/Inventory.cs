using System.Collections.Generic;
public class Inventory
{
    public List<int> aaa = new();
    public void Add(int i)
    {
        if(aaa.Count >= Managers.Game.inventorySize)
        {
            return;
        }
        aaa.Add(i);
        Managers.Game.inven.UpdateInven();
    }
}