using UnityEngine;
using UnityEngine.UI;
public class RankItem : MonoBehaviour
{
    public int index = 0;
    public Text text1;
    public Text text2;
    private void Update()
    {
        Debug.Log(Managers.Game.rank.Count);
        text1.text = $"{Managers.Game.rank[index].name}";
        text1.text = $"{Managers.Game.rank[index].score:N0}";
    }
}