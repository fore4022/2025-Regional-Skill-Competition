using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_2 : MonoBehaviour
{
    public int[][] pos = new int[4][];
    public List<RectTransform> rects;
    public Tile_2[][] tiles = new Tile_2[4][];
    public GameObject tile;

    public void Awake()
    {
        for(int i = 0; i < 4; i++)
        {
            pos[i] = new int[4];
            tiles[i] = new Tile_2[4];
        }
    }
    public void Start()
    {
        Spawn();
        Spawn();
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

        int Rand = UnityEngine.Random.Range(0, vec.Count);

        Vector2Int a = vec[Rand];

        GameObject go = Instantiate(tile, transform);
        Tile_2 t = go.GetComponent<Tile_2>();

        t.board = this;
        t.x = a.x;
        t.y = a.y;

        t.rect.localPosition = rects[a.x + a.y * 4].localPosition;

        tiles[a.x][a.y] = t;
    }
    public void Update()
    {
        float x = 0;
        float y = 0;

        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            y =  Input.GetAxisRaw("Vertical");
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            x = Input.GetAxisRaw("Horizontal");
        }

        if(x != 0 || y != 0)
        {
            StartCoroutine(Moving((int)x, (int)y));
        }
    }

    private IEnumerator Moving(int x, int y)
    {
        for(int i = 0; i < 4; i ++)
        {
            for(int j = 0; j < 4; j ++)
            {
                if (tiles[i][j] != null)
                {

                    tiles[i][j].addable = true;
                }
            }
        }

        for(int o = 0; o < 8; o++)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (tiles[i][j] != null)
                        tiles[i][j].Move(x, y);
                }
            }

            yield return null;
        }

        Spawn();
    }
}
