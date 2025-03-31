using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_2 : MonoBehaviour
{
    public List<RectTransform> rects;
    public T_2[][] tiles = new T_2[4][];
    public GameObject Tile;

    public void Start()
    {
        for(int i = 0; i <4; i++)
        {
            tiles[i] = new T_2[4];
        }

        Spawn();
        Spawn();
    }
    public void Spawn()
    {
        List<Vector2Int> aaa = new();

        for(int i = 0; i < 4; i ++)
        {
            for(int j = 0; j < 4;j++)
            {
                if (tiles[i][j] == null)
                {
                    aaa.Add(new(i, j));
                }
            }
        }

        int rand = Random.Range(0, aaa.Count);

        int x = aaa[rand].x;
        int y = aaa[rand].y;

        GameObject go = Instantiate(Tile, transform);
        T_2 a = go.GetComponent<T_2>();

        tiles[x][y] = a;

        a.x = x;
        a.y = y;
        a.b = this;

        tiles[x][y] = a;

        a.rect.transform.localPosition = rects[x + y *4].localPosition;
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

        if (x != 0 || y != 0)
        {
            StartCoroutine(Moving((int)x, (int)y));
        }
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            gameObject.SetActive(false);
        }
    }
    private IEnumerator Moving(int x, int y)
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
    }
}
