using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chuyencanh : MonoBehaviour
{
    [SerializeField] Animator loadScence;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            loadScence.SetTrigger("End");
            SceneManager.LoadScene(9);
            loadScence.SetTrigger("Start");
        }

    }
}