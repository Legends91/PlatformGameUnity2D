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



public class Health : MonoBehaviour
{
    [SerializeField] private Flash flashEffect;
    [SerializeField] private AudioSource pickupSFX, hurtSFX;
    public Slider ThanhMau;
    public TextMeshProUGUI ThanhChu;
    public int So;
    public int Dem;
    public int LuongMauToiDa = 100;
    public int LuongMauHienTai = 100;
    public int CDEffect;

    void Start()
    {
        LuongMauHienTai = LuongMauToiDa;
    }
    /*
    private void OnMouseDown()
    {
        LuongMauHienTai -= 5;
        Debug.Log("Tru 5 mau!");
        if (LuongMauHienTai < 1)
        {

            Destroy(gameObject);

        }
    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {


    }
    /*private void OnTriggerEnter2D(Collider2D collision)
    {

        
    }
    */

    public void NhanST(int satthuong)
    {

        hurtSFX.Play();
        LuongMauHienTai -= satthuong;
        flashEffect.Flash1();
        if (LuongMauHienTai <= 0)
        {
            
            // Destroy(gameObject);
            SceneManager.LoadSceneAsync("GameOver");
        }
    }

    public void HoiMau(int mau)
    {
        pickupSFX.Play();



        if (LuongMauHienTai < 100)
        {

            LuongMauHienTai += mau;
        }
        else
        {
            LuongMauHienTai += 0;
        }


    }
    void Update()
    {
        ThanhChu.text = LuongMauHienTai.ToString() + "/" + LuongMauToiDa.ToString();
        ThanhMau.value = LuongMauHienTai;
        ThanhMau.maxValue = LuongMauToiDa;
        if (LuongMauHienTai > 100)
        {
            LuongMauHienTai = 100;
        }
        if (LuongMauHienTai < 0)
        {
            LuongMauHienTai = 0;
        }



    }


}