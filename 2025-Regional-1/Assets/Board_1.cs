using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_1 : MonoBehaviour
{
    public int count;
    public List<Tile_1> tiles;
    public RectTransform empty;
    public GameObject tile;

    public void OnEnable()
    {
        StartCoroutine(Spawning());
    }
    public void OnClick(Tile_1 ti)
    {
        if(Vector3.Distance(ti.rect.localPosition, empty.localPosition) == 260)
        {
            Vector3 v = empty.localPosition;
            empty.localPosition = ti.rect.localPosition;

            ti.StartCoroutine(ti.Moving(v));
        }
    }
    private IEnumerator Spawning()
    {
        for(int i = 0; i < count -1; i++)
        {
            GameObject go = Instantiate(tile,transform);
            Tile_1 t = go.GetComponent<Tile_1>();

            tiles.Add(t);
            t.Set(i);
            t.board = this;
        }

        float totalTIme = 0;
        float targetTime = 0.5f;

        while(totalTIme!= targetTime)
        {
            totalTIme += Time.deltaTime;
            
            if(totalTIme > targetTime)
            {
                totalTIme = targetTime;
            }

            int r = Random.Range(0, tiles.Count);

            OnClick(tiles[r]);

            r = Random.Range(0, tiles.Count);

            OnClick(tiles[r]);

            r = Random.Range(0, tiles.Count);

            OnClick(tiles[r]);

            yield return null;
        }

        foreach(Tile_1 tile in tiles)
        {
            tile.targetTime = 0.5f;
        }
    }
}
