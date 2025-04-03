using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class B2 : MonoBehaviour
{
    public List<RectTransform> rects;
    public T2[][] tiles = new T2[4][];
    public GameObject tt;
    public int total;
    public Text text; 

    public void Start()
    {
        for(int i = 0; i < 4; i ++)
        {
            tiles[i] = new T2[4];
        }
        Spawn();
        Spawn();
    }
    public void Spawn()
    {
        List<Vector2Int> vvv = new();

        for(int i = 0; i < 4; i ++)
        {
            for(int j = 0; j < 4; j ++)
            {
                if (tiles[i][j] == null)
                {
                    vvv.Add(new(i, j));
                }
            }
        }

        int rand = Random.Range(0, vvv.Count);

        int x = vvv[rand].x;
        int y = vvv[rand].y;

        GameObject go = Instantiate(tt, transform);
        T2 t = go.GetComponent<T2>();

        tiles[x][y] = t;
        t.x = x;
        t.y = y;
        t.b = this;

        t.rect.localPosition = rects[x + y * 4].localPosition;
    }
    public void Update()
    {
        

        if(total <= 0)
        {
            gameObject.SetActive(false);
        }
        text.text = $"남은 점수 : {total}";

        float x = 0;
        float y = 0;

        if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            y = Input.GetAxisRaw("Vertical");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            x = Input.GetAxisRaw("Horizontal");
        }

        if(x != 0 || y != 0)
        {
            StartCoroutine(Set((int)x, (int)y));
        }

        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            gameObject.SetActive(false);
        }
    }
    private IEnumerator Set(int x, int y)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (tiles[i][j] != null)
                {
                    tiles[i][j].addable = true;
                }
            }
        }

        for(int o = 0; o < 4; o++)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (tiles[i][j] != null)
                    {
                        tiles[i][j].Move(x, y);
                    }
                }
            }

            yield return null;
        }

        Spawn();
        Spawn();
    }
}
