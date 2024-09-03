using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseFish : MonoBehaviour
{
    public Health health;
    public int mau;
    public GameObject effect;
    private Transform player;
    

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public void Use()
    {
        health.HoiMau(mau);

        Instantiate(effect, player.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
