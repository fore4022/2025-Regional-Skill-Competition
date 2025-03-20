using UnityEngine;

public class Valueable : MonoBehaviour
{
    public MeshRenderer render;
    public GameObject tra;
    public bool trap = false;
    public int good;
    public GameObject go;
    public GameObject particle;
    public int index;

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
                    particle.SetActive(false);

                    gameObject.GetComponent<MeshRenderer>().enabled = false;
                    Managers.Game.player.health -= 15;

                    render.enabled = false;

                    return;
                }

                if(Managers.Game.backSize > Managers.Game.inven.items.Count)
                {
                    Managers.Game.hash.Add(index);
                    Managers.Game.inven.Add(good);

                    gameObject.SetActive(false);
                    particle.SetActive(false);
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
