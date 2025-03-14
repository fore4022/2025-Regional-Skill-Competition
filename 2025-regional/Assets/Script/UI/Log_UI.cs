using UnityEngine;
using UnityEngine.UI;

public class Log_UI : MonoBehaviour
{
    public Animator anime;
    public Text text;
    public void Set(string text)
    {
        this.text.text = text;
    }
    public void Update()
    {
        if(anime.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            gameObject.SetActive(false);
        }
    }
}