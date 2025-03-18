using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class T1 : MonoBehaviour, IPointerClickHandler
{
    public RectTransform rect;
    public Text txt;
    public int index = 0;
    public B1 b;

    public void Update()
    {
        txt.text = $"{index}";
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        b.OnClick(this);
    }
    public IEnumerator Moving(Vector3 pos, float tar)
    {
        float t = 0;
        Vector3 vec = rect.localPosition;

        while(t != tar)
        {
            t += Time.deltaTime;

            if(t > tar)
            {
                t = tar;
            }

            rect.localPosition = Vector3.Lerp(vec, pos, t / tar);

            yield return null;
        }
    }
}
