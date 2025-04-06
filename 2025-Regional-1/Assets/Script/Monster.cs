
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Animator anime;
    public float health;
    public float speed;

    public bool aaa = false;
    public GameObject tar1;
    public GameObject tar2;

    public void Update()
    {
        if (health > 0)
        {
            Vector3 distance = transform.position - Managers.Game.player.gameObject.transform.position;

            transform.LookAt(Managers.Game.player.gameObject.transform);
            transform.Rotate(0, 180, 0);
            transform.position += distance * Time.deltaTime * speed * 1.4f;
            anime.Play("Walk");

            return;
        }
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 10)
        {
            Vector3 distance = transform.position - Managers.Game.player.gameObject.transform.position;

            transform.LookAt(Managers.Game.player.gameObject.transform);
            transform.position += distance * Time.deltaTime * speed;

            if(Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 2)
            {

                anime.Play("Attack");
            }

            return;
        }

        if (aaa)
        {
            Vector3 distance = transform.position - tar1.transform.position;

            transform.LookAt(Managers.Game.player.gameObject.transform);
            transform.position += distance * Time.deltaTime * speed;
            if (Vector3.Distance(tar1.transform.position, transform.position) < 0.1f)
            {
                aaa = false;
            }
        }
        else
        {
            Vector3 distance = transform.position - tar2.transform.position;

            transform.LookAt(Managers.Game.player.gameObject.transform);
            transform.position += distance * Time.deltaTime * speed;
            if (Vector3.Distance(tar2.transform.position, transform.position) < 0.1f)
            {
                aaa = true;
            }
        }
    }
}
