using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class T3 : MonoBehaviour, IPointerClickHandler
{
    public Image img;
    public B3 b;
    public RectTransform rec;

    public bool a = true;

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(SetSize());
        if(b.sel1 == null)
        {
            b.sel1 = this;
        }
        else if(b.sel2 == null)
        {
            b.sel2 = this;
            b.Change();
        }
    }
    public IEnumerator SetSize()
    {
        float to = 0;
        float tar = 0.1f;
        float current = rec.localScale.x;
        float val = 0;
        if(a)
        {
            val = 1.1f;
            a = false;
        }
        else
        {
            val = 1;
            a = true;
        }

        while(to !=  tar)
        {
            to += Time.deltaTime;

            if(to > tar)
            {
                to = tar;
            }
            float a = Mathf.Lerp(current, val, to / tar);

            rec.localScale = new Vector3(a,a,a);

            yield return null;
        }
    }
}