using UnityEngine;
public class Monster : MonoBehaviour
{
    public GameObject targetA;
    public GameObject targetB;
    public Animator anime;
    public bool a = false;

    void Start()
    {
        anime = GetComponent<Animator>();
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) < 1.4f && !Managers.Game.player.hidee)
        {
            transform.LookAt(Managers.Game.player.gameObject.transform);

            if (!anime.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
            {
                anime.Play("Attack");
            }
        }
        else
        {
            anime.Play("Walk");

            if(a)
            {
                if(Vector3.Distance(targetA.transform.position, transform.position) < 0.1f)
                {
                    a = !a;
                }

                transform.position += (targetA.transform.position - transform.position).normalized * Time.deltaTime * 5;
                transform.LookAt(targetA.transform.position);
            }
            else
            {
                if (Vector3.Distance(targetB.transform.position, transform.position) < 0.1f)
                {
                    a = !a;
                }
                transform.position += (targetB.transform.position - transform.position).normalized * Time.deltaTime * 5;
                transform.LookAt(targetB.transform.position);
            }
        }
    }
}