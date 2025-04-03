
using UnityEngine;
using UnityEngine.UI;

public class RankA : MonoBehaviour
{
    public Text naame;
    public Text ti;
    public int index;
    public void Start()
    {
        if(index + 1 <= Managers.Game.ranking.Count)
        {
            naame.text = $"{Managers.Game.ranking[index].name}";
            ti.text = $"{Managers.Game.ranking[index].time}";
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
