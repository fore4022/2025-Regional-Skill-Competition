using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_1 : MonoBehaviour
{
    public List<T_1> Gos;
    public RectTransform noene;

    public void Start()
    {
        StartCoroutine(Spaowning());
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            gameObject.SetActive(false);
        }
    }
    public void Click(T_1 t)
    {
        if(Vector3.Distance(t.rect.transform.position, noene.transform.position) == 270)
        {
            Vector3 v1 = noene.transform.position;
            Vector3 v2 = t.rect.transform.position;

            noene.transform.position = v2;

            StartCoroutine(t.Change(v1));
        }
    }
    public IEnumerator Spaowning()
    {
        foreach(T_1 t in Gos)
        {
            t.b = this;
            
        }

        float to= 0;
        float tar = 0.5f;

        while(to != tar)
        {
            to += Time.deltaTime;

            if(to > tar)
            {
                to = tar;
            }

            Click(Gos[Random.Range(0, Gos.Count - 1)]);
            Click(Gos[Random.Range(0, Gos.Count - 1)]);
            Click(Gos[Random.Range(0, Gos.Count - 1)]);

            yield return null;
        }


        foreach (T_1 t in Gos)
        {
            t.tar = 0.1f;
        }
    }
}
