using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class Inventory_UI : MonoBehaviour
{
    public List<Image> imgs = new();
    public List<Sprite> sprites;
    public GameObject go;
    public bool isItem = false;
    public int itemIndex = 0;

    public void Start()
    {
        Managers.Game.inven = this;

        for(int i = 0; i < Managers.Game.inventorySize; i++)
        {
            GameObject a = Instantiate(go, transform);
            Image img = a.transform.GetChild(0).GetComponent<Image>();

            img.sprite = null;
            imgs.Add(img);
        }
        UpdateInven();
    }
    public void UpdateInven()
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
                    if(img.sprite != sprites[0])
                    {
                        img.sprite = sprites[0];
                        Managers.Game.Log("±ÝÈ­ ÀÚ·ç È×µæ!");
                    }
                    break;
                case "b":
                    if (img.sprite != sprites[1])
                    {
                        img.sprite = sprites[1];
                        Managers.Game.Log("º¸¹° »óÀÚ È×µæ!");
                    }
                    break;
                case "c":
                    if (img.sprite != sprites[2])
                    {
                        img.sprite = sprites[2];
                        Managers.Game.Log("Å©¸®½ºÅ» »óÀÚ È×µæ!");
                    }
                    break;
                case "d":
                    if (img.sprite != sprites[3])
                    {
                        img.sprite = sprites[3];
                        Managers.Game.Log("È²±Ý Åõ±¸ È×µæ!");
                    }
                    break;
                case "e":
                    if (img.sprite != sprites[4])
                    {
                        img.sprite = sprites[4];
                        Managers.Game.Log("È²±Ý ¹æÆÐ È×µæ!");
                    }
                    break;
                case "f":
                    if (img.sprite != sprites[5])
                    {
                        img.sprite = sprites[5];
                        Managers.Game.Log("È²±Ý ·¹±ë½º È×µæ!");
                    }
                    break;
                case "UI_Icon_Apple"://hp
                    if (img.sprite != sprites[6])
                    {
                        isItem = true;
                        img.sprite = sprites[6];
                        Managers.Game.Log("'Ã¼·Â È¸º¹' È×µæ!");
                    }
                    break;
                case "UI_Icon_Potion_3"://air
                    if (img.sprite != sprites[7])
                    {
                        isItem = true;
                        img.sprite = sprites[7];
                        Managers.Game.Log("'»ê¼Ò È¸º¹' È×µæ!");
                    }
                    break;
                case "UI_Icon_Clover_Leaf"://treasure
                    if (img.sprite != sprites[8])
                    {
                        isItem = true;
                        img.sprite = sprites[7];
                        Managers.Game.Log("'º¸¹°°ú Çà¿î' È×µæ!");
                    }
                    break;
                case "UI_Icon_Potion_2"://speed s
                    if (img.sprite != sprites[9])
                    {
                        isItem = true;
                        img.sprite = sprites[7];
                        Managers.Game.Log("'¼º±ÞÇÔ' È×µæ!");
                    }
                    break;
                case "UI_Icon_Potion_1"://speed l
                    if (img.sprite != sprites[10])
                    {
                        isItem = true;
                        img.sprite = sprites[7];
                        Managers.Game.Log("'½Å¼ÓÇÔ' È×µæ!");
                    }
                    break;
                case "UI_Icon_Journal"://non enemy
                    if (img.sprite != sprites[11])
                    {
                        isItem = true;
                        img.sprite = sprites[7];
                        Managers.Game.Log("'À§Àå Àü·«' È×µæ!");
                    }
                    break;
            }

            i++;
        }
    }
}