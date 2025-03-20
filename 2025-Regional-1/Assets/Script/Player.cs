
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool hidee = false;
    public GameObject heal;
    public GameObject aair;
    public GameObject luck;
    public GameObject speedS;
    public GameObject speedL;
    public GameObject hide;

    public GameObject particle;
    public float speed = 7;
    public float turnSpeed = 300;
    public bool inGame = true;
    public CharacterController controller;
    public Animator anime;
    public Transform de;
    public Transform ne;
    public GameObject log;

    public Transform cam1;
    public Transform cam2;

    public float health = 100;
    public float air;

    public CapsuleCollider cap;

    public float totalTime = 0;

    private void Awake()
    {
        cap = GetComponentInChildren<CapsuleCollider>();

        Managers.Game.player = this;
        Managers.Game.log = log;
        Managers.Game.GameStart();

        air = Managers.Game.air - Managers.Game.stage * 7.5f;
    }
    public void Update()
    {
        if(Managers.Game.clearUI != null)
        {
            if (!Managers.Game.clearUI.activeSelf)
            {
                totalTime += Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Mouse0))
            {

                particle.SetActive(true);
            }
            else
            {
                particle.SetActive(false);
            }
        }

        float y = 0;
        float x = 0;

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

        Vector3 direction = transform.forward * speed * Time.deltaTime * y;
        controller.Move(direction);
        transform.Rotate(0, x * turnSpeed * Time.deltaTime, 0);

        if(inGame)
        {

            air -= Time.deltaTime;

            if (health <= 10 || air <= 10)
            {
                Camera.main.transform.SetParent(cam2);
            }
            else
            {
                Camera.main.transform.SetParent(cam1);
            }
        }

    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Monster"))
        {
            health -= 8 * Time.deltaTime;
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Monster"))
        {
            if(other.gameObject.TryGetComponent<Monster>(out Monster mon))
            {
                if(particle.activeSelf)
                {
                    mon.d += Time.deltaTime;
                }

                health -= 8 * Time.deltaTime;
            }
            else if(other.gameObject.TryGetComponent<Monster_F>(out Monster_F monn))
            {
                if(particle.activeSelf)
                {
                    monn.d += Time.deltaTime;
                }

                health -= 8 * Time.deltaTime;
            }
        }
        if (other.CompareTag("fire"))
        {
            Managers.Game.player.health -= 10 * Time.deltaTime;
        }

        if (other.CompareTag("gas"))
        {
            Managers.Game.player.health -= 10 * Time.deltaTime;
        }
    }


}
