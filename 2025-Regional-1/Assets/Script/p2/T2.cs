using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class T2 : MonoBehaviour
{
    public RectTransform rect;
    public Text text;
    public int index = 2;
    public B2 b;
    public int x;
    public int y;
    public bool addable = true;

    public void Update()
    {
        text.text = $"{index}";
    }
    public void Move(int x, int y)
    {
        x += this.x;
        y += this.y;

        if (x > 3 || x < 0 || y > 3 || y < 0)
        {
            return;
        }

        if (b.tiles[x][y] == null)
        {
            b.tiles[x][y] = this;
            b.tiles[this.x][this.y] = null;
            this.x = x;
            this.y = y;
            StartCoroutine(Move());
        }
        else if (b.tiles[x][y].addable && b.tiles[x][y].index == index)
        {
            b.tiles[x][y].Add();

            b.tiles[this.x][this.y] = null;

            Destroy(gameObject);
        }
    }
    public void Add()
    {
        index *= 2;

        addable = false;
    }
    public IEnumerator Move()
    {
        Vector3 vec = rect.localPosition;
        float to = 0;
        float tar = 0.05f;

        while(to != tar)
        {
            to += Time.deltaTime;
            if(to > tar)
            {
                to = tar;
            }

            rect.localPosition = Vector3.Lerp(vec, b.nodes[x + y * 4].localPosition, to / tar);
            yield return null;
        }
    }
}
