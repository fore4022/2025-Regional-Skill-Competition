using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B2 : MonoBehaviour
{
    public List<RectTransform> nodes;
    public T2[][] tiles = new T2[4][];
    public GameObject t;

    public void Start()
    {
        for(int i = 0; i < 4; i ++)
        {
            tiles[i] = new T2[4];
        }

        Spawn();
        Spawn();
    }
    public void Update()
    {
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
            StartCoroutine(moving((int)x, (int)y));
        }
    }
    public void Spawn()
    {
        List<Vector2Int> vec = new();

        for(int i = 0; i < 4; i ++)
        {
            for(int j = 0; j < 4; j++)
            {
                if (tiles[i][j] == null)
                {
                    vec.Add(new Vector2Int(i, j));
                }
            }
        }

        int rand = Random.Range(0, vec.Count);
        Vector2Int a = vec[rand];

        GameObject go = Instantiate(t, transform);
        T2 tt = go.GetComponent<T2>();

        tt.x = a.x;
        tt.y = a.y;
        tt.b = this;

        tt.rect.localPosition = nodes[a.x + a.y * 4].localPosition;

        tiles[a.x][a.y] = tt;
    }
    public IEnumerator moving(int x, int y)
    {
        for(int i = 0; i < 4; i ++)
        {
            for(int j = 0; j < 4; j++)
            {
                if (tiles[i][j] != null)
                    tiles[i][j].addable = true;
            }
        }

        for(int o = 0; o < 8; o ++)
        {
            for(int i = 0; i < 4; i ++)
            {
                for(int j = 0; j < 4; j ++)
                {
                    if (tiles[i][j] != null)
                    {
                        tiles[i][j].Move(x,y);
                    }
                }
            }
            yield return null;
        }

        Spawn();
    }
}
