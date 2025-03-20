
using System.Collections.Generic;
public class Inventory 
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
