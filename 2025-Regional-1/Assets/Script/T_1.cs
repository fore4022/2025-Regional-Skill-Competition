using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class T_1 : MonoBehaviour, IPointerClickHandler
{
    public RectTransform rect;
    public B_1 b;
    public float tar = 0;

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public IEnumerator Change(Vector3 vec)
    {
        if(tar == 0)
        {
            rect.transform.position = vec;

            yield break;
        }

        Vector3 v = rect.transform.position;
        float to= 0;

        while(to != tar)
        {
            to += Time.deltaTime;

            if(to > tar)
            {
                to = tar;
            }

            rect.transform.position = Vector3.Lerp(v, vec, to / tar);

            yield return null;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        b.Click(this);
    }
}
