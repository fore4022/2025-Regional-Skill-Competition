using UnityEngine;

public class Valueable : MonoBehaviour
{
    public GameObject tra;
    public bool trap = false;
    public int good;
    public GameObject go;
    public GameObject particle;
    public int index;
    public bool aaa = false;

    public void Start()
    {
        foreach(int i in Managers.Game.hash)
        {
            if(i == index)
            {
                gameObject.SetActive(false);
            }
        }

        Managers.Game.val.Add(this);
    }
    public void Update()
    {
        if(aaa)
        {
            return;
        }

        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) < 2)
        {
            Vector3 vec = transform.position - Managers.Game.player.gameObject.transform.position;
            go.transform.rotation = Quaternion.LookRotation(vec);

            go.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                if(trap)
                {
                    tra.gameObject.SetActive(true);

                    Managers.Game.player.health -= 15;

                    return;
                }

                if(Managers.Game.backSize > Managers.Game.inven.items.Count)
                {
                    Managers.Game.hash.Add(index);
                    Managers.Game.inven.Add(good);

                    gameObject.SetActive(false);

                    Debug.Log("a");
                    aaa = true;
                }
                else
                {
                    Managers.Game.Log("∞°πÊ¿Ã ≤À √°Ω¿¥œ¥Ÿ.");
                }
            }
        }
        else
        {
            go.SetActive(false);
        }
    }
}
