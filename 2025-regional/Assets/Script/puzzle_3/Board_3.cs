using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Board_3 : MonoBehaviour
{
    public List<Sprite> imgs = new();
    public List<Tile_3> tileList = new();
    public List<Tile_3> selectTile = new();
    public GameObject tile;

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            transform.parent.gameObject.SetActive(false);
        }
        if (selectTile.Count == 2)
        {
            Vector3 vec1 = selectTile[1].rect.localPosition;
            Vector3 vec2 = selectTile[0].rect.localPosition;

            selectTile[0].select = false;
            selectTile[1].select = false;

            StartCoroutine(selectTile[0].Moving(vec1));
            StartCoroutine(selectTile[1].Moving(vec2));
        }
    }
    private IEnumerator Spawn()
    {
        for (int i = 0; i < 9; i++)
        {
            GameObject go = Instantiate(this.tile, transform);

            Tile_3 tile = go.transform.GetComponent<Tile_3>();
            tileList.Add(tile);

            tile.board = this;
            tile.Set(i);
        }

        float totalTime = 0;
        float targetTime = 0.5f;

        yield return new WaitForSeconds(1);

        while (totalTime != targetTime)
        {
            totalTime += Time.deltaTime;

            if (totalTime > targetTime)
            {
                totalTime = targetTime;
            }

            int index = Random.Range(0, 9);

            tileList[index].transform.SetAsLastSibling();

            yield return null;
        }
    }
}