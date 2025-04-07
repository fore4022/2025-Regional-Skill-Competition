
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
            ti.text = $"00 : {Managers.Game.ranking[index].time / 60:D2} : {Managers.Game.ranking[index].time:D2}";
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
