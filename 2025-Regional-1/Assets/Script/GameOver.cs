using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text a;
    public Text b;
    public Text c;
    public void Awake()
    {
        Managers.Game.fail = gameObject;
        gameObject.SetActive(false);
    }
    public void OnEnable()
    {
        Managers.Game.inter.SetActive(false);
        Managers.Game.addCoin = 0;
        Managers.Game.sec = 0;

        string ss = $"Time - 00 : {(int)(Managers.Game.sec / 60):D2} : {(int)(Managers.Game.sec % 60):D2}";

        StartCoroutine(Util.Typeing(a, ss));

        ss = $"total Time - 00 : {(int)(Managers.Game.totalSec / 60):D2} : {(int)(Managers.Game.totalSec % 60):D2}";

        StartCoroutine(Util.Typeing(b, ss));

        ss = $"Add Gold + 0";

        StartCoroutine(Util.Typeing(c, ss));
    }
    public void Over()
    {

        Time.timeScale = 1;
        SceneManager.LoadScene("Main");
    }
}
