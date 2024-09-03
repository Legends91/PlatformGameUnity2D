using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DanBoss2 : MonoBehaviour
{
    GameObject target;
    public float tocdo;
    Rigidbody2D bulletRB;
    public HealthManBoss2 health;
    public int satthuong;
    


    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * tocdo;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        

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
