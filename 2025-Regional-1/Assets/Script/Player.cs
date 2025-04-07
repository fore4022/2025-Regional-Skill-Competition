using System.Collections;
using UnityEngine;
public class Player : MonoBehaviour
{
    public CapsuleCollider col;

    public GameObject Log;

    public GameObject cam;
    public Transform t1;
    public Transform t2;

    public GameObject attack;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;

    public CharacterController chara;
    public Animator anime;

    public float speed = 6;
    public bool inGame = true;
    public float health;
    public float air;

    public Collider att;

    public void Awake()
    {
        Managers.Game.player = this;
        Managers.Game.Log = Log;
    }
    public void Start()
    {
        health = 100;
        air = Managers.Game.air;

        air -= 8 * (Managers.Game.stageIndex - 1);
    }
    public void Update()
    {
        float x = 0;
        float y = 0;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            y = Input.GetAxisRaw("Vertical");
            anime.SetInteger("AnimationPar", 1);
        }
        else
        {
            anime.SetInteger("AnimationPar", 0);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            x = Input.GetAxisRaw("Horizontal");
        }

        chara.Move(transform.forward * speed * (y - Managers.Game.inven.Count * 0.5f) *  Time.deltaTime);
        transform.Rotate(0, 180 * x * Time.deltaTime, 0);

        if (inGame)
        {

            if (health <= 10 || air <= 10)
            {
                cam.transform.SetParent(t2);
            }
            else
            {
                cam.transform.SetParent(t1);
            }


            Managers.Game.sec += Time.deltaTime;
            air -= 0.75f * Time.deltaTime;

            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                attack.SetActive(true);
                att.enabled = true;

                StartCoroutine(ack());
                StartCoroutine(attackCool());
            }

            if((air <= 0 || health <= 0) && Time.timeScale == 1)
            {
                Time.timeScale = 0;
                Managers.Game.GameOver(false);
            }
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("fire") || other.CompareTag("gas"))
        {
            health -= 9 * Time.deltaTime;
        }
    }
    public IEnumerator ack()
    {
        yield return new WaitForSeconds(0.4f);
        att.enabled = false;
    }
    public IEnumerator attackCool()
    {
        yield return new WaitForSeconds(1.2f);
        attack.SetActive(false);
    }
    public IEnumerator P1()
    {
        p1.SetActive(true);
        health = Mathf.Min(100, health + 10);

        yield return new WaitForSeconds(0.5f);
        
        p1.SetActive(false);
    }
    public IEnumerator P2()
    {
        p2.SetActive(true);
        air = Mathf.Min(Managers.Game.air, air + 18);

        yield return new WaitForSeconds(0.5f);

        p2.SetActive(false);
    }
    public IEnumerator P3()
    {
        p3.SetActive(true);
        Managers.Game.vals[Random.Range(0, Managers.Game.vals.Count)].par.SetActive(true);

        yield return new WaitForSeconds(1.5f);

        p3.SetActive(false);
    }
    public IEnumerator P4()
    {
        p4.SetActive(true);
        speed = 7;

        yield return new WaitForSeconds(2f);
        speed = 6;

        p4.SetActive(false);
    }
    public IEnumerator P5()
    {
        p5.SetActive(true);
        speed = 8.5f;

        yield return new WaitForSeconds(5.5f);
        speed = 6;

        p5.SetActive(false);
    }
    public IEnumerator P6()
    {
        p6.SetActive(true);
        col.enabled = false;

        yield return new WaitForSeconds(0.5f);

        p6.SetActive(false);
    }
}
