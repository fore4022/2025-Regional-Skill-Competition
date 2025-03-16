using System.Collections;
using UnityEngine;
public class Player : MonoBehaviour
{
    public GameObject cam;
    public GameObject camPos1;
    public GameObject camPos2;

    private Animator anime;
    private CharacterController controller;

    private Vector3 moveDirection = Vector3.zero;
    public float speed = 7f;
    public float turnSpeed = 300f;
    public float gravity = 20f;
    public float health = 100;
    public float air = 100;
    public bool hidee = false;
    public float totalTime = 0;

    public GameObject heal;
    public GameObject airO;
    public GameObject luck;
    public GameObject speedS;
    public GameObject speedL;
    public GameObject hide;

    private void Awake()
    {
        Managers.Game.player = this;
        Managers.Game.isloop = true;

        anime = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    private void Start()
    {
        air = Managers.Game.air - (Managers.Game.stageIndex - 1) * 10;
    }
    private void Update()
    {
        if(Managers.Game.isloop)
        {
            totalTime += Time.deltaTime; 
        }

        if(health <= 0)
        {
            Managers.Game.GameOver(false);
        }

        if(air <= 0)
        {
            Managers.Game.GameOver(false);
        }

        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            anime.SetInteger("AnimationPar", 1);
        }
        else
        {
            anime.SetInteger("AnimationPar", 0);
        }

        if(controller.isGrounded)
        {
            moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
        }

        float turn = 0;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            turn = Input.GetAxis("Horizontal");
        }

        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;

        if (air < 10 || health < 10)
        {
            cam.transform.SetParent(camPos2.transform);
        }
        else
        {
            cam.transform.SetParent(camPos1.transform);
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Managers.Game.inven.isItem)
            {
                Managers.Game.Log("아이템 사용");

                switch(Managers.Game.inven.itemIndex)
                {
                    case 6:
                        StartCoroutine(Heal());
                        health = Mathf.Min(100, health + 10);
                        break;
                    case 7:
                        StartCoroutine(Air());
                        air = Mathf.Min(Managers.Game.air, air + 25);
                        break;
                    case 8:
                        StartCoroutine(Luck());
                        int aa = Random.Range(0, Managers.Game.val.Count);
                        Managers.Game.val[aa].effect.SetActive(true);
                        break;
                    case 9:
                        StartCoroutine(SpeedS());
                        break;
                    case 10:
                        StartCoroutine(SpeedL());
                        break;
                    case 11:
                        hidee = true;

                        StartCoroutine(Hide());
                        break;
                }

                Managers.Game.inventory.aaa.Remove(Managers.Game.inven.itemIndex);
                Managers.Game.inven.UpdateInven();
            }
            else
            {
                Managers.Game.Log("아이템이 없습니다.");
            }
        }
    }
    public void GetDamage(float dmg)
    {
        health -= dmg;
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("gas"))
        {
            GetDamage(20 * Time.deltaTime);
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            if(!hidee)
            {

                GetDamage(7 * Time.deltaTime);
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("outside"))
        {
            Managers.Game.GameOver(true);
        }
        if (other.gameObject.CompareTag("arrow"))
        {
            GetDamage(7);
        }
    }
    private IEnumerator Heal()
    {
        heal.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        heal.SetActive(false);
    }
    private IEnumerator Air()
    {
        airO.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        airO.SetActive(false);
    }
    private IEnumerator Luck()
    {
        luck.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        luck.SetActive(false);
    }
    private IEnumerator Hide()
    {
        hide.SetActive(true);

        yield return new WaitForSeconds(0.5f);
        hide.SetActive(false);
    }
    private IEnumerator SpeedS()
    {
        speedS.SetActive(true);
        speed += 2;
        yield return new WaitForSeconds(5);
        speed -= 2;
        speedS.SetActive(false);
    }
    private IEnumerator SpeedL()
    {
        speedL.SetActive(true);
        speed += 3.5f;
        yield return new WaitForSeconds(8);
        speed -= 3.5f;
        speedL.SetActive(false);
    }
}