using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Board_2 : MonoBehaviour
{
    public List<RectTransform> nodes = new();
    public Tile_2[][] tiles = new Tile_2[4][];
    public GameObject tile;
    public int score = 0;
    public int targetScore = 500;

    private void Awake()
    {
        for(int i = 0; i < 4; i++)
        {
            tiles[i] = new Tile_2[4];
        }
    }
    private void OnEnable()
    {
        Spawn();
        Spawn();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            transform.parent.gameObject.SetActive(false);
        }
        float x = 0;
        float y = 0;

        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            y = Input.GetAxisRaw("Vertical");
        }
        
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            x = Input.GetAxisRaw("Horizontal");
        }

        if((x != 0 && y == 0) || (x == 0 && y != 0))
        {
            StartCoroutine(Moving((int)x, (int)y));
        }

        if(score >= targetScore)
        {
            Debug.Log("Clear");
        }
    }
    private void Spawn()
    {
        List<Vector2Int> emptySpaces = new();

        for(int i = 0; i < tiles.Length; i++)
        {
            for(int j = 0; j < tiles[i].Length; j++)
            {
                if(tiles[i][j] == null)
                {
                    emptySpaces.Add(new Vector2Int(i, j));
                }
            }
        }

        if(emptySpaces.Count == 0)
        {
            return;
        }

        Vector2Int pos = emptySpaces[Random.Range(0, emptySpaces.Count)];
        GameObject go = Instantiate(this.tile, transform);
        Tile_2 tile = go.GetComponent<Tile_2>();

        tile.x = pos.x;
        tile.y = pos.y;
        tile.board = this;
        tile.rect.localPosition = nodes[pos.x + pos.y * 4].localPosition;

        tiles[pos.x][pos.y] = tile;
    }
    private IEnumerator Moving(int x, int y)
    {
        foreach (Tile_2[] tiles in tiles)
        {
            foreach (Tile_2 tile in tiles)
            {
                if(tile != null)
                {
                    tile.addable = true;
                }
            }
        }

        for (int i = 0; i < 4; i++)
        {
            foreach (Tile_2[] tiles in tiles)
            {
                foreach(Tile_2 tile in tiles)
                {
                    if(tile !=  null)
                    {
                        tile.OnMove(x, y);

                        yield return null;
                    }
                }
            }
        }

        Spawn();
    }
}