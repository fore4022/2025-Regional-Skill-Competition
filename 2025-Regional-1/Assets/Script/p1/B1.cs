using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1 : MonoBehaviour
{
    public List<T1> tiles;
    public int cnt = 9;
    public GameObject tile;
    public RectTransform empty;
    public float duration = 0.001f;

    public void Start()
    {
        cnt--;
        StartCoroutine(Spawning());
    }
    public void OnClick(T1 t)
    {
        if (Vector3.Distance(t.rect.localPosition, empty.localPosition) == 270)
        {
            Vector3 vec = empty.localPosition;
            empty.localPosition = t.rect.localPosition;

            StartCoroutine(t.Moving(vec, duration));
        }
    }
    private IEnumerator Spawning()
    {
        for (int i = 0; i < cnt; i++)
        {
            GameObject go = Instantiate(tile, transform);
            T1 t = go.GetComponent<T1>();

            t.index = i + 1;
            t.b = this;

            tiles.Add(t);
        }

        float to = 0;
        float tar = 0.5f;


        yield return new WaitForSeconds(0.5f);

        while (to != tar)
        {
            to += Time.deltaTime;

            if (to > tar)
            {
                to = tar;
            }

            int i = Random.Range(0, tiles.Count);

            OnClick(tiles[i]);
            i = Random.Range(0, tiles.Count);

            OnClick(tiles[i]);
            i = Random.Range(0, tiles.Count);

            OnClick(tiles[i]);

            yield return null;
        }

        duration = 0.1f;
    }
}
