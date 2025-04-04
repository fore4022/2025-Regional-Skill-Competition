using UnityEngine;

public class Valuable : MonoBehaviour
{
    public GameObject effect;
    public bool trap = false;
    public GameObject trapp;
    public int index;
    public int hash;
    public GameObject par;

    public void Start()
    {
        foreach(int i in Managers.Game.hash)
        {
            if(i == hash)
            {
                gameObject.SetActive(false);
            }
        }

        if(!trap)
        {
            Managers.Game.vals.Add(this);
        }
    }
    public void Update()
    {
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 3)
        {
            effect.SetActive(true);

            Vector3 vec = transform.position - Managers.Game.player.gameObject.transform.position;

            effect.transform.rotation = Quaternion.LookRotation(vec);

            if (trap && Input.GetKeyDown(KeyCode.F))
            {
                Managers.Game.player.health -= 15;
                trapp.SetActive(true);
                Managers.Game.hash.Add(hash);

                gameObject.SetActive(false);
            }
            else if (Managers.Game.backSize > Managers.Game.inven.Count &&Input.GetKeyDown(KeyCode.F))
            {
                Managers.Game.inven.Add(index);
                Managers.Game.hash.Add(hash);

                switch(index)
                {
                    case 0:
                        Managers.Game.Send("Ȳ�� ���� �׵�!");
                        break;

                    case 1:
                        Managers.Game.Send("Ȳ�� �� �׵�!");
                        break;

                    case 2:
                        Managers.Game.Send("��� �׵�!");
                        break;

                    case 3:
                        Managers.Game.Send("������ Ȳ�� �� �׵�!");
                        break;

                    case 4:
                        Managers.Game.Send("��� ���� �׵�!");
                        break;

                    case 5:
                        Managers.Game.Send("���� ���� �׵�!");
                        break;
                }

                gameObject.SetActive(false);
            }
        }
        else
        {
            effect.SetActive(false);

        }
    }
}
