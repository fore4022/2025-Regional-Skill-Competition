using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B1 : MonoBehaviour
{
    public List<T1> tiles;
    public RectTransform empty;
    public void Start()
    {
        StartCoroutine(Set());
    }
    public void Click(T1 t)
    {
        if(Vector3.Distance(empty.position, t.rect.position) == 270)
        {
            Vector3 v = empty.position;
            Vector3 vx = t.rect.position;

            empty.position = vx;

            StartCoroutine(t.Moving(v));
        }
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            gameObject.SetActive(false);
        }
    }
    private IEnumerator Set()
    {
        for(int i = 0; i < 8; i++)
        {
            tiles[i].b = this;
        }

        float t = 0;
        float tar = 0.5f;

        while(t !=  tar)
        {
            t += Time.deltaTime;

            if(t > tar)
            {
                t = tar;
            }

            Click(tiles[Random.Range(0, 8)]);
            Click(tiles[Random.Range(0, 8)]);
            Click(tiles[Random.Range(0, 8)]);

            yield return null;
        }

        for (int i = 0; i < 8; i++)
        {
            tiles[i].tar = 0.1f;
        }
    }
}
