using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class T1 : MonoBehaviour, IPointerClickHandler
{
    public RectTransform rect;
    public B1 b;
    public float tar = 0f;

    public void OnPointerClick(PointerEventData eventData)
    {
        b.Click(this);
    }
    public IEnumerator Moving(Vector3 vaa)
    {
        Vector3 vec = rect.position;

        if(tar == 0)
        {
            rect.position = vaa;

            yield break;
        }

        float t = 0;

        while (t != tar)
        {
            t += Time.deltaTime;

            if (t > tar)
            {
                t = tar;
            }
            rect.position = Vector3.Lerp(vec, vaa, t / tar);

            yield return null;
        }
    }
}
