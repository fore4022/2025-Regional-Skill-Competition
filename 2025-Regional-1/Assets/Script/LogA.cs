using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class LogA : MonoBehaviour
{
    public Text text;
    public Animator anime;

    public void Start()
    {
        StartCoroutine(ads());
    }
    public IEnumerator ads()
    {
        yield return null;

        yield return new WaitUntil(() => anime.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1);

        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
