using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    public Text a;
    public Text b;
    public Text c;
    public void Awake()
    {
        Managers.Game.clear = gameObject;
        gameObject.SetActive(false);
    }
    public void Start()
    {
        Managers.Game.inter.SetActive(false);
        Managers.Game.totalCoin += Managers.Game.addCoin;
        Managers.Game.addCoin = 0;
        Managers.Game.totalSec += Managers.Game.sec;
        Managers.Game.sec = 0;
        StartCoroutine(Util.Typeing(a, $"Time - 00 : {(Managers.Game.sec / 60):D2} : {(int)(Managers.Game.sec % 60):D2}"));
        StartCoroutine(Util.Typeing(b, $"total Time - 00 : {(Managers.Game.totalSec / 60):D2} : {(int)(Managers.Game.totalSec % 60):D2}"));
        StartCoroutine(Util.Typeing(c, $"Add Gold + 0"));

    }
    public void Clear()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
}
