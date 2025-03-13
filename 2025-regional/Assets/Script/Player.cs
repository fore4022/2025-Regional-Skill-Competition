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

    private void Awake()
    {
        Managers.Game.player = this;

        anime = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    private void Start()
    {
        air = Managers.Game.air - (Managers.Game.stageIndex - 1) * 10;
    }
    private void Update()
    {
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

        if (air < 10)
        {
            cam.transform.SetParent(camPos2.transform);
        }
        else
        {
            cam.transform.SetParent(camPos1.transform);
        }
    }
    public void GetDamage(float dmg)
    {
        health -= dmg;

        Debug.Log(health);
    }
    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("gas"))
        {
            GetDamage(20 * Time.deltaTime);
        }

        if (other.gameObject.CompareTag("enemy"))
        {
            GetDamage(7 * Time.deltaTime);
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
}