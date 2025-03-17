using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile_3 : MonoBehaviour, IPointerClickHandler
{
    public RectTransform rect;
    public Board_3 bo;
    public float current = 1;
    public float targetA = 1.2f;
    public float targetB = 1;

    public void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(bo.sel1 == null)
        {
            bo.sel1 = this;
        }
        else if(bo.sel2 == null)
        {
            bo.sel2 = this;

            bo.Change();
        }

        StartCoroutine(SetSize());
    }
    public IEnumerator SetSize()
    {
        float to = 0;
        float tar = 0.1f;

        if(current != targetA)
        {
            while(to != tar)
            {
                to += Time.deltaTime;

                if(to > tar)
                {
                    to = tar;
                }

                float a = Mathf.Lerp(current, targetA, to / tar);
                rect.localScale = new Vector3(a,a,a);
            }
            current = targetA;
        }
        else if(current != targetB)
        {
            while (to != tar)
            {
                to += Time.deltaTime;

                if (to > tar)
                {
                    to = tar;
                }

                float a = Mathf.Lerp(current, targetB, to / tar);
                rect.localScale = new Vector3(a, a, a);
            }
            current = targetB;
        }

        yield return null;
    }
}
