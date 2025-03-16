using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
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
            if(Managers.Game.inventory.aaa.Count < i + 1)
            {
                img.sprite = null;

                continue;
            }

            List<int> a = Managers.Game.inventory.aaa;

            switch(a[i])
            {
                case 0:
                    if(img.sprite != sprites[0])
                    {
                        img.sprite = sprites[0];
                        Managers.Game.Log("±ÝÈ­ ÀÚ·ç È×µæ!");
                    }
                    break;
                case 1:
                    if (img.sprite != sprites[1])
                    {
                        img.sprite = sprites[1];
                        Managers.Game.Log("º¸¹° »óÀÚ È×µæ!");
                    }
                    break;
                case 2:
                    if (img.sprite != sprites[2])
                    {
                        img.sprite = sprites[2];
                        Managers.Game.Log("Å©¸®½ºÅ» »óÀÚ È×µæ!");
                    }
                    break;
                case 3:
                    if (img.sprite != sprites[3])
                    {
                        img.sprite = sprites[3];
                        Managers.Game.Log("È²±Ý Åõ±¸ È×µæ!");
                    }
                    break;
                case 4:
                    if (img.sprite != sprites[4])
                    {
                        img.sprite = sprites[4];
                        Managers.Game.Log("È²±Ý ¹æÆÐ È×µæ!");
                    }
                    break;
                case 5:
                    if (img.sprite != sprites[5])
                    {
                        img.sprite = sprites[5];
                        Managers.Game.Log("È²±Ý ·¹±ë½º È×µæ!");
                    }
                    break;
                case 6://hp
                    if (img.sprite != sprites[6])
                    {

                        isItem = true;
                        img.sprite = sprites[6];
                        itemIndex = 6;
                        Managers.Game.Log("'Ã¼·Â È¸º¹' È×µæ!");
                    }
                    break;
                case 7://air
                    if (img.sprite != sprites[7])
                    {
                        itemIndex = 7;
                        isItem = true;
                        img.sprite = sprites[7];
                        Managers.Game.Log("'»ê¼Ò È¸º¹' È×µæ!");
                    }
                    break;
                case 8://treasure
                    if (img.sprite != sprites[8])
                    {
                        itemIndex = 8;
                        isItem = true;
                        img.sprite = sprites[7];
                        Managers.Game.Log("'º¸¹°°ú Çà¿î' È×µæ!");
                    }
                    break;
                case 9://speed s
                    if (img.sprite != sprites[9])
                    {
                        itemIndex = 9;
                        isItem = true;
                        img.sprite = sprites[7];
                        Managers.Game.Log("'¼º±ÞÇÔ' È×µæ!");
                    }
                    break;
                case 10://speed l
                    if (img.sprite != sprites[10])
                    {
                        itemIndex = 10;
                        isItem = true;
                        img.sprite = sprites[7];
                        Managers.Game.Log("'½Å¼ÓÇÔ' È×µæ!");
                    }
                    break;
                case 11://non enemy
                    if (img.sprite != sprites[11])
                    {
                        itemIndex = 11;
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