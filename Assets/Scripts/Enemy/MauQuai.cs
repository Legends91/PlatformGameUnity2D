using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MauQuai : MonoBehaviour
{
   
    public int mautoida;
    public int mauhientai;

    void Start()
    {
        mauhientai = mautoida;
    }
     public void NhanST(int trumau)
    {
        
        mauhientai -= trumau;
        if (mauhientai <= 0)
        {
            Destroy(gameObject);
        }
    }

}
