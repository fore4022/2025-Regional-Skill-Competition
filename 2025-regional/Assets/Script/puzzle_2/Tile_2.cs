using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Tile_2 : MonoBehaviour
{
    public Board_2 board;
    public RectTransform rect;
    public Text text;
    public int x;
    public int y;
    public int number = 2;
    [HideInInspector]
    public bool addable = true;

    public void Update()
    {
        text.text = $"{number}";
    }
    public bool OnMove(int x, int y)
    {
        x += this.x;
        y += this.y;

        if(x > 3 || x < 0 || y > 3 || y < 0)
        {
            return false;
        }

        if(board.tiles[x][y] == null)
        {
            board.tiles[this.x][this.y] = null;

            this.x = x;
            this.y = y;

            board.tiles[this.x][this.y] = this;

            StartCoroutine(Moving(board.nodes[x + y * 4].localPosition));

            return true;
        }
        else
        {
            if(board.tiles[x][y].addable && board.tiles[x][y].number == number && addable)
            {
                board.tiles[x][y].Add();

                board.tiles[this.x][this.y] = null;
                Destroy(gameObject);

                return true;
            }
        }

        return false;
    }
    public void Add()
    {
        number *= 2;
        addable = false;

        board.score += number;
    }
    private IEnumerator Moving(Vector3 target)
    {
        Vector3 vec = rect.localPosition;
        float targetTime = 0.05f;
        float totalTime = 0;

        while(totalTime != targetTime)
        {
            totalTime += Time.deltaTime;

            if(totalTime > targetTime)
            {
                totalTime = targetTime;
            }

            rect.localPosition = Vector3.Lerp(vec, target, totalTime / targetTime);

            yield return null;
        }
    }
}