using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    public float tocdodichuyen;
    public float tamngam;
    bool isFacingRight = false;
    float horizontalInput;
    public float tamban;
    public float cuongdo = 1f;
    public float banlantoi;
    public GameObject dan;
    public GameObject hopdan;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    private void Update()
    {
        FlipSprite();
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer < tamngam && distanceFromPlayer > tamban)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, tocdodichuyen * Time.deltaTime);
        }
        else if (distanceFromPlayer <= tamban && banlantoi < Time.time)
        {

            Instantiate(dan, hopdan.transform.position, Quaternion.identity);
            banlantoi = Time.time + cuongdo;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, tamngam);
        Gizmos.DrawWireSphere(transform.position, tamban);
    }

    void FlipSprite()
    {
        if (isFacingRight && horizontalInput < 0 || !isFacingRight && horizontalInput > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;

        }
    }

}
