
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStage : MonoBehaviour
{
    public GameObject go;
    public void Update()
    {
        if (Vector3.Distance(Managers.Game.player.gameObject.transform.position, transform.position) < 8)
        {
            go.SetActive(true);

            Vector3 vec = transform.position - Managers.Game.player.gameObject.transform.position;
            go.transform.rotation = Quaternion.LookRotation(vec);

            if(Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("StageSelect");
            }    
        }
        else
        {
            go.SetActive(false);
        }
    }
}
