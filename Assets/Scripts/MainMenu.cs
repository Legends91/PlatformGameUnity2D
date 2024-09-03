using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Choi()
    {
        SceneManager.LoadScene(4);
    }


    // Update is called once per frame
    public void Caidat()
    {
    }
    public void Thoat()
    {
        Application.Quit();
        
    }
    public void Choilai()
    {
        SceneManager.LoadScene(1);
    }
    public void Menu()
    {
        SceneManager.LoadScene(3);
    }
    public void ChoilaiBoss1()
    {
        SceneManager.LoadScene(11);
    }
    public void ChoilaiBoss2()
    {
        SceneManager.LoadScene(15);
    }
    public void TaoPhong()
    {
        SceneManager.LoadScene(1);
    }
}
