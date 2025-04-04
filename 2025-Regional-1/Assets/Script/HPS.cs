
using UnityEngine;
using UnityEngine.UI;

public class HPS : MonoBehaviour
{
    public Slider h;
    public void Start()
    {
        Managers.Game.inter = transform.parent.gameObject;
    }
    void Update()
    {
        h.value = Managers.Game.player.air / Managers.Game.air;
    }
}
