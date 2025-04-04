
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject effect;
    public void Start()
    {
        transform.Rotate(0, Random.Range(0, 360), 0);
    }
    public void Update()
    {
        transform.Rotate(0, 120 * Time.deltaTime, 0);

        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 9)
        {
            effect.SetActive(true);

        }
        else
        {
            effect.SetActive(false);

        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            int aa = Random.Range(6, 12);

            Managers.Game.inven.Add(aa);

            switch(aa)
            {
                case 6:
                    Managers.Game.Send("'ü�� ȸ��' �׵�!");
                    break;

                case 7:
                    Managers.Game.Send("'��� ȸ��' �׵�!");
                    break;

                case 8:
                    Managers.Game.Send("'���谡�� ���' �׵�!");
                    break;

                case 9:
                    Managers.Game.Send("'�ż�(��)' �׵�!");
                    break;

                case 10:
                    Managers.Game.Send("'�ż�(��)' �׵�!");
                    break;

                case 11:
                    Managers.Game.Send("'���� ���� ���̵�' �׵�!");
                    break;
            }

            gameObject.SetActive(false);
        }
    }
}
