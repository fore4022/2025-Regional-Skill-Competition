using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    public static Managers Instance;

    public GameManagers game = new();
    public static Managers Manager { get { Init(); return Instance; } }

    public static GameManagers Game { get { return Manager.game;} }

    public static void Init()
    {
        GameObject go = GameObject.Find("Managers");

        if(go == null)
        {
            go = new GameObject{ name = "Managers" };

            Instance = go.AddComponent<Managers>();

            DontDestroyOnLoad(go);
        }

    }
}
