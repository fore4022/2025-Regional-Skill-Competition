using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    public Board board;
    public Text text;
    [HideInInspector]
    public int index = 0;
    [HideInInspector]
    public float targetTime = 0.01f;
    public void Update()
    {
        text.text = $"{index + 1}";
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        board.OnClick(this);
    }
    public void OnMove(Vector3 vec)
    {
        GetComponent<RectTransform>().localPosition = vec;
    }
    public IEnumerator OnMoving(Vector3 target)
    {
        Vector3 vec = GetComponent<RectTransform>().localPosition;
        float totalTime = 0.000001f;

        while (totalTime != targetTime)
        {
            totalTime += Time.deltaTime;

            if(totalTime > targetTime)
            {
                totalTime = targetTime;
            }

            GetComponent<RectTransform>().localPosition = Vector3.Lerp(vec, target, totalTime / targetTime);

            yield return null;
        }
    }
}