using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class T_2 : MonoBehaviour
{
    public RectTransform rect;
    public bool addable = false;
    public B_2 b;
    public Text text;

    public int x;
    public int y;
    public int index = 2;

    public void Move(int x, int y)
    {
        x += this.x;
        y += this.y;

        if(x > 3 || x < 0 || y > 3 || y < 0)
        {
            return;
        }

        if (b.tiles[x][y] == null)
        {
            b.tiles[this.x][this.y] = null;
            b.tiles[x][y] = this;

            StartCoroutine(Moving());
        }
        else if (b.tiles[x][y].index == index && b.tiles[x][y].addable)
        {
            b.tiles[this.x][this.y] = null;
            b.tiles[x][y] = this;
            b.tiles[x][y].Add();
            Destroy(gameObject);
        }
    }
    public void Update()
    {
        text.text = $"{index}";
    }
    public void Add()
    {
        index *= 2;
        addable = false;
    }
    private IEnumerator Moving()
    {
        Vector3 v = rect.transform.position;
        Vector3 vec = b.rects[x + y * 4].localPosition;
        float to = 0;
        float tar = 0.05f;

        while (to != tar)
        {
            to += Time.deltaTime;

            if (to > tar)
            {
                to = tar;
            }

            rect.transform.localPosition = Vector3.Lerp(v, vec, to / tar);

            yield return null;
        }
    }
}
