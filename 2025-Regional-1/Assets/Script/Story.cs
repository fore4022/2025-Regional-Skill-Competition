
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
        StartCoroutine(Util.Typeing(t1, "���踦 ������\n Ž���ϴ� �� ���."));

        yield return new WaitForSeconds(2f);


        i2.SetActive(true);
        StartCoroutine(Util.Typeing(t2, "���ظ� �̾�� ��\n ��¦ ���µ�..."));

        yield return new WaitForSeconds(2f);


        i3.SetActive(true);
        StartCoroutine(Util.Typeing(t3, "�״� �߰ߵ��� ����\n �Ƕ�̵带 �߰��س´�!"));

        yield return new WaitForSeconds(2f);


        i4.SetActive(true);
        StartCoroutine(Util.Typeing(t4, "�״� ��û�� Ž����($?)����\n�Ƕ�̵带 �����ϱ�� �����Դ´�."));

        yield return new WaitForSeconds(2f);

        ui.SetActive(false);
    }
}
