using UnityEngine;
using UnityEngine.UI;

public class AIRS : MonoBehaviour
{
    public Slider h;
    void Update()
    {
        h.value = Managers.Game.player.air / Managers.Game.air;
    }
}
