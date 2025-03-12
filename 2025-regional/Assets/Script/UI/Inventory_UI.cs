using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class Inventory_UI : MonoBehaviour
{
    public List<Image> imgs = new();
    public List<Sprite> sprites;
    public GameObject go;

    public void Start()
    {
        for(int i = 0; i < Managers.Game.inventorySize; i++)
        {
            GameObject a = Instantiate(go, transform);
            Image img = a.transform.GetChild(0).GetComponent<Image>();

            img.sprite = null;
            imgs.Add(img);
        }
    }
    private void Update()
    {
        int i = 0;

        foreach(Image img in imgs)
        {
            if(Managers.Game.inventory.inventory.Count < i + 1)
            {
                break;
            }

            List<string> a = Managers.Game.inventory.inventory.Keys.ToList();

            switch(a[i])
            {
                case "a":
                    img.sprite = sprites[0];
                    break;
                case "b":
                    img.sprite = sprites[1];
                    break;
                case "c":
                    img.sprite = sprites[2];
                    break;
                case "d":
                    img.sprite = sprites[3];
                    break;
                case "e":
                    img.sprite = sprites[4];
                    break;
                case "f":
                    img.sprite = sprites[5];
                    break;
            }

            i++;
        }
    }
}