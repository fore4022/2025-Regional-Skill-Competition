using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Board_3 : MonoBehaviour
{
    public List<Sprite> sp;
    public List<Tile_3> tiles;
    public List<Image> imgs;
    public Tile_3 sel1;
    public Tile_3 sel2;

    public void Start()
    {
        StartCoroutine(Spawning());
    }
    public void Change()
    {
        Vector3 a = sel1.rect.localPosition;
        Vector3 b = sel2.rect.localPosition;

        sel1.rect.localPosition = b;
        sel2.rect.localPosition = a;
        StartCoroutine(sel1.SetSize());
        StartCoroutine(sel2.SetSize());

        sel1 = sel2 = null;
    }
    public IEnumerator Spawning()
    {
        int i = 0;

        foreach(Image img in imgs)
        {
            img.sprite = sp[i];
            tiles.Add(img.gameObject.GetComponent<Tile_3>());

            tiles[i].bo = this;
            i++;
        }

        float total = 0;
        float target = 0.5f;

        yield return new WaitForSeconds(1f);

        while(total != target)
        {
            total += Time.deltaTime;

            if(total> target)
            {
                total = target;
            }

            int rand = Random.Range(0, imgs.Count);

            imgs[rand].gameObject.transform.SetAsFirstSibling();

            yield return null;
        }
    }
}