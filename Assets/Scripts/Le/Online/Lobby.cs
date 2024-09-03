using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Lobby : MonoBehaviour
{

    public static Lobby Instance {  get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);
    }
}
