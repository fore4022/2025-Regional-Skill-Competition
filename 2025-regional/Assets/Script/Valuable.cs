using UnityEngine;
public class Valuable : MonoBehaviour
{
    public GameObject go;
    public string id;

    public int index;
    private void Awake()
    {
        foreach (int i in Managers.Game.hash)
        {
            if (index == i)
            {
                gameObject.SetActive(false);
            }
        }

        Managers.Game.val.Add(this);
    }
    private void Update()
    {
        if(Vector3.Distance(transform.position, Managers.Game.player.gameObject.transform.position) <= 2)
        {
            go.gameObject.SetActive(true);

            Vector3 direction = transform.position - Managers.Game.player.cam.transform.position;
            go.transform.rotation = Quaternion.LookRotation(direction);

            if(Input.GetKeyDown(KeyCode.F))
            {
                if(Managers.Game.inventory.inventory.Count < Managers.Game.inventorySize)
                {
                    Managers.Game.inventory.Add(id);
                    Managers.Game.hash.Add(index);
                    //if(Managers.Game.inven.isItem)
                    //{
                    //    Managers.Game.hash.Add(index);
                    //}
                    //else
                    //{
                    //    Managers.Game.hash.Add(Random.Range(0, 12));
                    //}

                    Managers.Game.val.Remove(this);
                    gameObject.SetActive(false);
                }
                else
                {
                    Managers.Game.Log("°¡¹æÀÌ °¡µæ Ã¡½À´Ï´Ù.");
                }
            }
        }
        else
        {
            go.gameObject.SetActive(false);
        }
    }
}