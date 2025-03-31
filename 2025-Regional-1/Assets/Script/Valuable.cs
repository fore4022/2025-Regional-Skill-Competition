
using UnityEngine;

public class Valuable : MonoBehaviour
{
    public GameObject effect;
    public GameObject particle;
    public bool trap = false;
    public GameObject explosion;

    public int hash;
    public int index;

    public void Start()
    {
        foreach(int i in Managers.Game.hash)
        {
            if(hash == i)
            {
                gameObject.SetActive(false);
            }
        }

        Managers.Game.val.Add(this);
    }
    public void Update()
    {
        if(Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) < 2f)
        {

            effect.SetActive(true);
            effect.transform.LookAt(Managers.Game.player.transform.position);

            if(Input.GetKeyDown(KeyCode.F))
            {
                if(trap)
                {
                    explosion.SetActive(true);
                    Managers.Game.player.health -= 15;
                }
                else
                {
                    int a = Random.Range(0, 12);

                    Managers.Game.inven.Add(a);

                    switch(a)
                    {
                        case 0:
                            Managers.Game.Log("±ÝÈ­ ÀÚ·ç È×µæ!");
                            break;

                        case 1:
                            Managers.Game.Log("¿¡¸Þ¶öµå È×µæ!");
                            break;

                        case 2:
                            Managers.Game.Log("È²±Ý Åõ±¸ È×µæ!");
                            break;

                        case 3:
                            Managers.Game.Log("°í´ë °¢¹Ý È×µæ!");
                            break;

                        case 4:
                            Managers.Game.Log("»ç¸·ÀÇ ¾àÁÖ È×µæ!");
                            break;
                    }
                }

                Managers.Game.hash.Add(hash);
                gameObject.SetActive(false);
            }
        }
        else
        {
            effect.SetActive(false);
        }
    }
}
