using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Tile_2 : MonoBehaviour
{
    public Text text;
    public RectTransform rect;
    public Board_2 board;

    public bool addable = true;

    public int x;
    public int y;
    public int val = 2;

    public void Update()
    {
        text.text = $"{val}";
    }
    public void Move(int x, int y)
    {
        x += this.x;
        y += this.y;

        if(x > 3 || x < 0)
        {
            return;
        }
        if(y > 3 || y < 0)
        {
            return;
        }

        if (board.tiles[x][y] == null)
        {
            board.tiles[x][y] = this;

            board.tiles[this.x][this.y] = null;

            this.x = x;
            this.y = y;

            StartCoroutine(Moveing());
        }
        else if (board.tiles[x][y].addable && board.tiles[x][y].val == val)
        {
            GameObject go = board.tiles[x][y].gameObject;
            board.tiles[x][y] = null;


            Destroy(go);

            Add();
        }
        
    }
    public void Add()
    {
        val *= 2;
        addable = false;
    }
    public IEnumerator Moveing()
    {
        Vector3 tar = board.rects[x + y * 4].localPosition;
        Vector3 vec = rect.localPosition;

        float targetTime = 0.05f;
        float totalTime = 0;

        while(targetTime != totalTime)
        {
            totalTime += Time.deltaTime;

            if(totalTime > targetTime)
            {
                totalTime = targetTime;
            }

            rect.localPosition = Vector3.Lerp(vec, tar, totalTime / targetTime);

            yield return null;
        }
    }
}
