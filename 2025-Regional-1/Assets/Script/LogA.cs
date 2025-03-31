using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LogA : MonoBehaviour
{
    public Animator anime;
    public Text text;


    public void Start()
    {
        StartCoroutine(Wait());
    }
    public void Logging(string str)
    {
        StartCoroutine(TTT.Typeing(text, str));
    }
    public IEnumerator Wait()
    {
        yield return null;

        yield return new WaitUntil(() => anime.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f);

        yield return new WaitForSeconds(0.3f);

        gameObject.SetActive(false);
    }
}
