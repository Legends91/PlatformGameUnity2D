using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quai : MonoBehaviour
{
    public int mau;
    public float tocdo;
    public float dazedTime;
    public float startDazedTime;

    private Animator anim;
    public GameObject trumau;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (dazedTime < 0)
        {
            tocdo = 5;
        }
        else
        {
            tocdo = 0;
            dazedTime -= Time.deltaTime;
        }
        if (mau <= 0)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * tocdo * Time.deltaTime);
    }

    public void NhanST(int satthuong)
    {
        Instantiate(trumau, transform.position, Quaternion.identity);
        mau -= satthuong;
        Debug.Log("Quai nhan sat thuong");

    }
}
