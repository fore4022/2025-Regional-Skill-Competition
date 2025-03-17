
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Tile_1 : MonoBehaviour, IPointerClickHandler
{
    public RectTransform rect;
    public Board_1 board; 
    public float targetTime = 0.0001f;
    public Text text;

    public void Awake()
    {
        rect = GetComponent<RectTransform>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        board.OnClick(this);
    }

    public void Set(int i)
    {
        text.text = $"{i + 1}";
    }
    public IEnumerator Moving(Vector3 tar)
    {
        Vector3 vec = rect.localPosition;
        float totalTIme = 0;

        while (totalTIme != targetTime)
        {
            totalTIme += Time.deltaTime;


            if (totalTIme > targetTime)
            {
                totalTIme = targetTime;
            }

            rect.localPosition = Vector3.Lerp(vec, tar, totalTIme / targetTime);

            yield return null;
        }
    }
}
