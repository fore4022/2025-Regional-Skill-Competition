using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterF : MonoBehaviour
{
    public Animator anime;
    public float health;
    public float speed;

    public bool aaa = false;
    public GameObject tar1;
    public GameObject tar2;

    public void Update()
    {
        if (health <= 0)
        {

            Vector3 distance = (transform.position - Managers.Game.player.gameObject.transform.position).normalized;

            transform.LookAt(Managers.Game.player.gameObject.transform);
            transform.Rotate(0, 180, 0);
            transform.position += distance * Time.deltaTime * speed * 2.4f;
            anime.Play("Walk");

            return;
        }
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) <= 2.5f && !Managers.Game.player.isTarget)
        {
            Vector3 distance = (Managers.Game.player.gameObject.transform.position - transform.position).normalized;

            transform.LookAt(Managers.Game.player.gameObject.transform);

            Managers.Game.player.health -= 5 * Time.deltaTime;

            anime.Play("Attack");

            return;
        }

        if (aaa)
        {
            Vector3 distance = (tar1.transform.position - transform.position).normalized;

            transform.LookAt(tar1.transform.position);
            transform.position += distance * Time.deltaTime * speed;
            if (Vector3.Distance(tar1.transform.position, transform.position) < 0.1f)
            {
                aaa = false;
            }
        }
        else
        {
            Vector3 distance = (tar2.transform.position - transform.position).normalized;

            transform.LookAt(tar2.transform.position);
            transform.position += distance * Time.deltaTime * speed;
            if (Vector3.Distance(tar2.transform.position, transform.position) < 0.1f)
            {
                aaa = true;
            }
        }

        anime.Play("Walk");
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("attack"))
        {
            health -= 1;
        }
    }
}
