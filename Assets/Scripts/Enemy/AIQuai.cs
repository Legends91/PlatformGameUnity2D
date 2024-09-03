using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIQuai : MonoBehaviour
{
    public Transform[] diemtuantra;
    public float tocdodichuyen;
    public float tocdothaydoi;
    float tocdobandau;
    public int dich;

    public Transform targetTransform;
    
    public bool Phathien;

    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        tocdobandau = tocdodichuyen;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Phathien = true;
            
            //  tocdodichuyen = tocdothaydoi;
            tocdodichuyen = tocdothaydoi;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Phathien = false;
            tocdodichuyen = tocdobandau;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (dich == 0 )
        {
            transform.position = Vector2.MoveTowards(transform.position, diemtuantra[0].position, tocdodichuyen * Time.deltaTime);
            if (Vector2.Distance(transform.position, diemtuantra[0].position) < .2f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                dich = 1;
            }
        }
        if (dich == 1 )
        {
            transform.position = Vector2.MoveTowards(transform.position, diemtuantra[1].position, tocdodichuyen * Time.deltaTime);
            if (Vector2.Distance(transform.position, diemtuantra[1].position) < .2f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                dich = 0;
            }
        }
        //}
    }
}