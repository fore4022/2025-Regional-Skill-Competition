using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Result_UI : MonoBehaviour
{
    public Sprite green;
    public Sprite red;
    public Image img;
    public Text result;
    public Text score;
    public Text timer;
    public Text coin;
    public GameObject home;
    public Animator anime;

    public void Awake()
    {
        Managers.Game.result = transform.parent.parent.gameObject;

        transform.parent.parent.gameObject.SetActive(false);
    }
    public void Start()
    {
        if(Managers.Game.isClear)
        {
            img.sprite = green;
            StartCoroutine(Util.TypeEffecting(result, "Clear"));
        }
        else
        {
            img.sprite = red;
            StartCoroutine(Util.TypeEffecting(result, "Fail"));
        }

        timer.text = $"";
        coin.text = $"+ {Managers.Game.addCoin} G";

        Managers.Game.addCoin = 0;

        StartCoroutine(Showing());
    }
    public void GoMain()
    {
        SceneManager.LoadScene("Main");
    }
    private IEnumerator Showing()
    {
        yield return new WaitForSeconds(0.5f);

        anime.enabled = true;

        yield return new WaitUntil(() => anime.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);

        home.SetActive(true);
        StartCoroutine(Util.TypeEffecting(score, "score : 5,000"));
    }
}