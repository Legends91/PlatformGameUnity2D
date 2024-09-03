using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DanPro1 : MonoBehaviour
{
    GameObject target;
    public float tocdo;
    Transform player;
    public HealthManBoss1 health;
    public int satthuong;




    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, tocdo * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            health.NhanST(satthuong);

            Destroy(gameObject, 0);
        }
    }
}
