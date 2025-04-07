
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    public GameObject effect;
    public GameObject ui;

    public GameObject i1;
    public GameObject i2;
    public GameObject i3;
    public GameObject i4;

    public Text t1;
    public Text t2;
    public Text t3;
    public Text t4;

    public void Update()
    {
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 3)
        {
            effect.SetActive(true);

            if(Input.GetKeyDown(KeyCode.F))
            {
                ui.SetActive(true);
                StartCoroutine(Showing());
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                ui.SetActive(false);
            }
        }
        else
        {
            effect.SetActive(false);

        }
    }

    public IEnumerator Showing()
    {
        i1.SetActive(true);
        StartCoroutine(Util.Typeing(t1, "세계를 떠돌며\n 탐험하는 한 사람."));

        yield return new WaitForSeconds(2f);


        i2.SetActive(true);
        StartCoroutine(Util.Typeing(t2, "항해를 이어가던 날\n 깜짝 놀라는데..."));

        yield return new WaitForSeconds(2f);


        i3.SetActive(true);
        StartCoroutine(Util.Typeing(t3, "그는 발견되지 않은\n 피라미드를 발견해냈다!"));

        yield return new WaitForSeconds(2f);


        i4.SetActive(true);
        StartCoroutine(Util.Typeing(t4, "그는 엄청난 탐구욕($?)으로\n피라미드를 조사하기로 마음먹는다."));

        yield return new WaitForSeconds(2f);

        ui.SetActive(false);
    }
}
