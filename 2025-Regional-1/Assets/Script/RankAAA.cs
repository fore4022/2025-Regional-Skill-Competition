using UnityEngine;
using UnityEngine.UI;

public class RankAAA : MonoBehaviour
{
    public int index;
    public Text namee;
    public Text score;

    public void Start()
    {
        if(!(Managers.Game.rank.Count > index))
        {
            gameObject.SetActive(false);
        }
        else
        {


            namee.text = $"{Managers.Game.rank[index].name}";
            score.text = $"{Managers.Game.rank[index].score}";
        }
    }
}
