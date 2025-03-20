
using UnityEngine;

public class Monster_F : MonoBehaviour
{
    public float d = 0;

    public GameObject tar1;
    public GameObject tar2;
    public Animator anime;

    public bool a = true;

    public void Update()
    {
        if (d > 1)
        {
            Vector3 direction = (Managers.Game.player.transform.position - transform.position).normalized;

            transform.LookAt(Managers.Game.player.transform);
            transform.Rotate(0, 180, 0);

            transform.position -= direction * 3 * Time.deltaTime;
            return;
        }
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) < 5f && !Managers.Game.player.hidee)
        {
            Vector3 direction = (Managers.Game.player.transform.position - transform.position).normalized;

            transform.LookAt(Managers.Game.player.transform);

            transform.position += direction * 3 * Time.deltaTime;
            if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) < 1.4f)
                anime.Play("Attack");
            else
                anime.Play("Walk");
            return;
        }
        else
        {
            anime.Play("Walk");
        }

        if (!a)
        {
            Vector3 direction = (tar1.transform.position - transform.position).normalized;

            transform.LookAt(tar1.transform);

            transform.position += direction * 3 * Time.deltaTime;
            if (!(Vector3.Distance(tar1.transform.position, transform.position) > 0.1))
            {
                a = !a;
            }
        }
        if (a)
        {
            Vector3 direction = (tar2.transform.position - transform.position).normalized;

            transform.LookAt(tar2.transform);

            transform.position += direction * 3 * Time.deltaTime;
            if (!(Vector3.Distance(tar2.transform.position, transform.position) > 0.1))
            {
                a = !a;
            }
        }
    }
}
