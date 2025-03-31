
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool chase = true;

    public GameObject par1;
    public GameObject par2;
    public GameObject par3;
    public GameObject par4;
    public GameObject par5;
    public GameObject par6;

    public Animator anime;
    public GameObject log;
    public CharacterController chara;
    public bool inGame = true;

    public float health = 100;
    public float air;

    public float speed = 6;

    public void Awake()
    {
        Managers.Game.player = GetComponent<Player>();
        Managers.Game.log = log;
        chara = GetComponent<CharacterController>();

    }
    public void Start()
    {

        air = Managers.Game.air -  8 * (Managers.Game.stagetIndex - 1);
    }
    public void Update()
    {
        float x = 0;
        float y = 0;

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            y = Input.GetAxisRaw("Vertical");
            anime.SetInteger("AnimationPar", 1);
        }
        else
        {
            anime.SetInteger("AnimationPar", 0);
        }

        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            x = Input.GetAxisRaw("Horizontal");
        }

        chara.Move(transform.forward * speed * Time.deltaTime * y);
        transform.Rotate(new Vector3(0, 120 * Time.deltaTime * x, 0));

        if(inGame)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if(Managers.Game.inven.Count >= 1)
                {
                    if (Managers.Game.inven[0] > 5)
                    {
                        Use(Managers.Game.inven[0]);
                        Managers.Game.inven.RemoveAt(0);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (Managers.Game.inven.Count >= 2)
                {
                    if (Managers.Game.inven[1] > 5)
                    {
                        Use(Managers.Game.inven[1]);
                        Managers.Game.inven.RemoveAt(1);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (Managers.Game.inven.Count >= 3)
                {
                    if (Managers.Game.inven[2] > 5)
                    {
                        Use(Managers.Game.inven[2]);
                        Managers.Game.inven.RemoveAt(2);
                    }
                }

            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (Managers.Game.inven.Count >= 4)
                {
                    if (Managers.Game.inven[3] > 5)
                    {
                        Use(Managers.Game.inven[3]);
                        Managers.Game.inven.RemoveAt(3);
                    }
                }

            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                if (Managers.Game.inven.Count >= 5)
                {
                    if (Managers.Game.inven[4] > 5)
                    {
                        Use(Managers.Game.inven[4]);
                        Managers.Game.inven.RemoveAt(4);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                if (Managers.Game.inven.Count >= 6)
                {
                    if (Managers.Game.inven[5] > 5)
                    {
                        Use(Managers.Game.inven[5]);
                        Managers.Game.inven.RemoveAt(5);
                    }
                }

            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {

                if (Managers.Game.inven.Count >= 7)
                {
                    if (Managers.Game.inven[6] > 5)
                    {
                        Use(Managers.Game.inven[6]);
                        Managers.Game.inven.RemoveAt(6);
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                if (Managers.Game.inven.Count >= 8)
                {
                    if (Managers.Game.inven[7] > 5)
                    {
                        Use(Managers.Game.inven[7]);
                        Managers.Game.inven.RemoveAt(7);
                    }
                }

            }
        }
    }
    public void Use(int i)
    {

        switch(i)
        {
            case 6:

                health = Mathf.Min(100, health + 10);
                StartCoroutine(P1());
                Managers.Game.Log("체력 회복!");
                break;
            case 7:

                air = Mathf.Min(Managers.Game.air, air + 8);
                StartCoroutine(P2());
                Managers.Game.Log("산소 보충!");
                break;
            case 8:

                air = Mathf.Min(Managers.Game.air, air + 8);
                StartCoroutine(P3());
                Managers.Game.Log("모험가의 행운!");
                break;
            case 9:

                int rand = Random.Range(0, Managers.Game.val.Count);

                Managers.Game.val[rand].particle.SetActive(true);
                StartCoroutine(P4());
                Managers.Game.Log("신속함 (소)!");
                break;
            case 10:

                StartCoroutine(P5());
                Managers.Game.Log("신속함 (대)!");
                break;
            case 11:

                StartCoroutine(P6());
                Managers.Game.Log("잠행!");
                break;
        }
    }

    private IEnumerator P1()
    {
        par1.SetActive(true);

        yield return new WaitForSeconds(1f);
        par1.SetActive(false);
    }
    private IEnumerator P2()
    {
        par2.SetActive(true);

        yield return new WaitForSeconds(1f);
        par2.SetActive(false);
    }
    private IEnumerator P3()
    {
        par3.SetActive(true);

        yield return new WaitForSeconds(1f);
        par3.SetActive(false);
    }
    private IEnumerator P4()
    {
        speed += 1;
        par4.SetActive(true);

        yield return new WaitForSeconds(2.5f);
        speed -= 1;
        par4.SetActive(false);
    }
    private IEnumerator P5()
    {
        speed += 2;
        par5.SetActive(true);

        yield return new WaitForSeconds(6f);
        speed -= 2;
        par5.SetActive(false);
    }
    private IEnumerator P6()
    {
        par6.SetActive(true);

        yield return new WaitForSeconds(1f);
        par6.SetActive(false);
    }
}
