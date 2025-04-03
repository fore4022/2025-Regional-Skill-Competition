using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class T2 : MonoBehaviour
{
    public RectTransform rect;
    public Text text;
    public B2 b;

    public bool addable = false;
    public int x;
    public int y;
    public int index = 2;

    public void Update()
    {
        text.text = $"{index}";
    }
    public void Move(int x, int y)
    {
        x += this.x;
        y += this.y;

        if(x > 3 || x < 0 || y > 3 || y <0)
        {
            return;
        }
        if (b.tiles[x][y] == null)
        {
            b.tiles[x][y] = this;
            b.tiles[this.x][this.y] = null;

            this.x = x;
            this.y = y;

            StartCoroutine(Moving());
        }
        else if(b.tiles[x][y].addable  && b.tiles[x][y].index == index)
        {
            b.tiles[x][y].Add();
            b.tiles[this.x][this.y] = null;
            Destroy(gameObject);

        }
    }
    public IEnumerator Moving()
    {
        Vector3 vec = rect.localPosition;
        Vector3 vvv = b.rects[x + y * 4].localPosition;
        float t = 0;
        float tar = 0.1f;

        while (t != tar)
        {
            t += Time.deltaTime;

            if (t > tar)
            {
                t = tar;
            }

            rect.localPosition = Vector3.Lerp(vec, vvv, t / tar);

            yield return null;
        }
    }
    public void Add()
    {
        index *= 2;
        addable = false;
        b.total -= index;
    }
}
