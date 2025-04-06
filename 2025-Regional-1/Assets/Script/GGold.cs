using UnityEngine;
using UnityEngine.UI;

public class GGold : MonoBehaviour
{
    public Text text; 
    public void Update()
    {
        text.text = $"{Managers.Game.addCoin} G";
    }
}
