using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStomp : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Diem Yeu" )
        {
            
            collision.gameObject.GetComponent<MauQuai>().NhanST(1);
        }
        //Destroy(collision.gameObject);
    }
}
