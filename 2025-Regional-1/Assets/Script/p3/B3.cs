using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3 : MonoBehaviour
{
    public List<Sprite> sp;
    public List<T3> t;

    public T3 sel1;
    public T3 sel2;

    public void Start()
    {
        StartCoroutine(Setting());
    }
    public void Change()
    {
        Vector3 ve1 = sel1.rec.localPosition;
        Vector3 ve2 = sel2.rec.localPosition;

        sel1.rec.localPosition = ve2;
        sel2.rec.localPosition = ve1;

        StartCoroutine(sel1.SetSize());
        StartCoroutine(sel2.SetSize());

        sel1 = null;
        sel2 = null;
    }
    private IEnumerator Setting()
    {
        int i = 0;
        foreach(Sprite s in sp)
        {
            t[i].img.sprite = s;
            t[i].b = this;
            i++;
        }

        yield return new WaitForSeconds(0.5f);

        float to = 0f;
        float tar = 0.5f;

        while(to != tar)
        {
            to += Time.deltaTime;

            if(to > tar)
            {
                to = tar;
            }

            int rand = Random.Range(0, t.Count);

            t[rand].transform.SetAsLastSibling();

            yield return null;
        }
    }
}
