using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioM1 : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicBackground;

    public static AudioM1 instance;

    private void Awake()
    {
        if (AudioM.Instance != null)
        {
            Destroy(AudioM.Instance.gameObject);
        }

    }

    void Start()
    {
        musicBackground.Play();
    }
}


