using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using System.Security.Cryptography;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class HealthBoss2 : MonoBehaviour
{
    public Slider ThanhMau;
    public TextMeshProUGUI ThanhChu;
    public int LuongMauToiDa = 60;
    public int LuongMauHienTai = 60;
   
    public float WaitSec;
 

    void Start()
    {
        LuongMauHienTai = LuongMauToiDa;
    }

    void Update()
    {
        ThanhChu.text = LuongMauHienTai.ToString() + "/" + LuongMauToiDa.ToString();
        ThanhMau.value = LuongMauHienTai;
        ThanhMau.maxValue = LuongMauToiDa;
    }
    private void FixedUpdate()
    {
        if (WaitSec > 0)
        {
            WaitSec -= Time.fixedDeltaTime;
            
            LuongMauHienTai = (int)WaitSec;
            
            
        }
        else
        {
            SceneManager.LoadScene(16);
        }
    }

}