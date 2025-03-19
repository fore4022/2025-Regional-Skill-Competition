
using UnityEngine;
using UnityEngine.UI;

public class Status_UI : MonoBehaviour
{
    public Text gold;
    public Slider h;
    public Slider a;

    public int index = 0;

    public void Update()
    {
        if(index == 0)
        {
            gold.text = $"+ {Managers.Game.addCoin:N0}G";
        }
        else if (index == 1)
        {
            h.value = Managers.Game.player.health / 100;
        }
        else if (index == 2)
        {
            a.value = Managers.Game.player.air / Managers.Game.air;
        }
    }
}
