using System.Collections.Generic;
using UnityEngine;
public class Help_UI : MonoBehaviour
{
    public List<GameObject> objs = new();
    public GameObject go;
    public int index = 0;

    public void Press()
    {
        objs[index].SetActive(true);
        index++;

        if(index == 3)
        {
            go.SetActive(true);
        }
    }
}