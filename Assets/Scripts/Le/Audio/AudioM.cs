using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioM : MonoBehaviour
{
    public static AudioM Instance { get; private set; }
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicBackground;

    

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        musicBackground.Play();
    }
}
