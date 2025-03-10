using UnityEngine;
public class Valuable : MonoBehaviour
{
    public GameObject go;

    private void Update()
    {
        if(Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) <= 2)
        {
            go.gameObject.SetActive(true);

            Vector3 direction = transform.position - Managers.Game.player.cam.transform.position;
            go.transform.rotation = Quaternion.LookRotation(direction);

            if(Input.GetKeyDown(KeyCode.F))
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            go.gameObject.SetActive(false);
        }
    }
}