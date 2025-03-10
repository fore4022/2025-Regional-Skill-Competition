using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Tile_3 : MonoBehaviour, IPointerClickHandler
{
    public RectTransform rect;
    public Image img;
    public Board_3 board;
    public int index;
    public bool select = false;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
        img = GetComponent<Image>();
    }
    public void Set(int i)
    {
        index = i;
        img.sprite = board.imgs[i];
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        select = !select;
        StartCoroutine(SetScale());
    }
    public IEnumerator SetScale()
    {
        Vector3 target;

        if (select)
        {
            target = new(1.2f, 1.2f);
            board.selectTile.Add(this);
        }
        else
        {
            target = new(1f, 1f);
            board.selectTile.Remove(this);
        }

        Vector3 vec = rect.localScale;

        float totalTime = 0;
        float targetTime = 0.25f;

        while(totalTime != targetTime)
        {
            totalTime += Time.deltaTime;

            if(totalTime > targetTime)
            {
                totalTime = targetTime;
            }

            rect.localScale = Vector3.Lerp(vec, target, totalTime / targetTime);

            yield return null;
        }
    }
    public IEnumerator Moving(Vector3 target)
    {
        Vector3 vec = rect.localPosition;

        float totalTime = 0;
        float targetTime = 0.25f;

        yield return null;

        StartCoroutine(SetScale());

        while (totalTime != targetTime)
        {
            totalTime += Time.deltaTime;

            if (totalTime > targetTime)
            {
                totalTime = targetTime;
            }

            rect.localPosition = Vector3.Lerp(vec, target, totalTime / targetTime);

            yield return null;
        }
    }
}