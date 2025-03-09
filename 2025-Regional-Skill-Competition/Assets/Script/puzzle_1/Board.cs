using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Board : MonoBehaviour
{
    public List<Tile> tileList = new();
    public GameObject EmptyTile;
    public GameObject tile;
    public int count = 9;

    private void Awake()
    {
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        count--;
        EmptyTile = transform.GetChild(0).gameObject;
        StartCoroutine(TileSpawning());
    }
    private void Update()
    {
        int index = 0;

        foreach(Tile tile in tileList)
        {
            if(index != tile.index)
            {
                return;
            }

            index++;
        }

        PuzzleClear();
    }
    private void PuzzleClear()
    {
        Debug.Log("Clear");
    }
    public void OnClick(Tile tile)
    {
        if(Vector3.Distance(tile.GetComponent<RectTransform>().localPosition, EmptyTile.GetComponent<RectTransform>().localPosition) == 260)
        {
            Debug.Log(Vector3.Distance(tile.GetComponent<RectTransform>().localPosition, EmptyTile.GetComponent<RectTransform>().localPosition));
            Vector3 vec = EmptyTile.GetComponent<RectTransform>().localPosition;

            EmptyTile.GetComponent<RectTransform>().localPosition = tile.GetComponent<RectTransform>().localPosition;

            if(tile.targetTime == 0.01f)
            {
                tile.OnMove(vec);
            }
            else
            {
                StartCoroutine(tile.OnMoving(vec));
            }
        }
    }
    private IEnumerator TileSpawning()
    {
        for(int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(this.tile, transform);

            Tile tile = go.GetComponent<Tile>();

            tile.board = this;
            tile.index = i;
            tileList.Add(tile);
        }

        float totalTime = 0;
        float targetTime = 0.5f;

        EmptyTile.transform.SetAsLastSibling();

        while (totalTime != targetTime)
        {
            totalTime += Time.deltaTime;

            if (totalTime > targetTime)
            {
                totalTime = targetTime;
            }

            int index = Random.Range(0, count);

            OnClick(tileList[index]);

            index = Random.Range(0, count);

            OnClick(tileList[index]);

            index = Random.Range(0, count);

            OnClick(tileList[index]); 

            yield return null;
        }

        yield return new WaitForSeconds(0.02f);

        foreach(Tile tile in tileList)
        {
            tile.targetTime = 0.1f;
        }
    }
}