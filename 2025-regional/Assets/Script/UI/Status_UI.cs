using UnityEngine;
using UnityEngine.UI;
public class Status_UI : MonoBehaviour
{
    public Slider hp;
    public Slider air;
    public Text text;

    public void Awake()
    {
        Managers.Game.status = gameObject;
    }
    public void Update()
    {
        hp.value = Managers.Game.player.health / 100;
        air.value = Managers.Game.player.air / Managers.Game.air;
        text.text = $"+ {Managers.Game.addCoin:N0} G";

        Managers.Game.player.air -= Time.deltaTime;

        if(Managers.Game.player.health <= 0 || Managers.Game.air <= 0)
        {
            Managers.Game.GameOver(false);
            gameObject.SetActive(false);
        }
    }
}