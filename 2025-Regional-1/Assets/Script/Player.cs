using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject Log;

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
    public void Awake()
    {
        Managers.Game.player = this;
        Managers.Game.Log = Log;
    }
    public void Start()
    {
        
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

        chara.Move(transform.forward * speed * y*  Time.deltaTime);
        transform.Rotate(0, 180 * x * Time.deltaTime, 0);

        if (inGame)
        {
            air -= 0.75f * Time.deltaTime;
        }
    }

    public IEnumerator P1()
    {
        p1.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        
        p1.SetActive(true);
    }
    public IEnumerator P2()
    {
        p2.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        p2.SetActive(true);
    }
    public IEnumerator P3()
    {
        p3.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        p3.SetActive(true);
    }
    public IEnumerator P4()
    {
        p4.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        p4.SetActive(true);
    }
    public IEnumerator P5()
    {
        p5.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        p5.SetActive(true);
    }
    public IEnumerator P6()
    {
        p6.SetActive(true);

        yield return new WaitForSeconds(0.5f);

        p6.SetActive(true);
    }
}
