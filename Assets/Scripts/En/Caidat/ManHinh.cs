using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManHinh : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Dropdown ScreenModeDropDown;    
    private Dophangiai DPGs;
    void Start()
    {
        DPGs = FindObjectOfType<Dophangiai>();
        int val = PlayerPrefs.GetInt("ScreenMode");    
        ScreenModeDropDown.value = val;   
    }

    public void SetScreenMode(int index)   
    {
        PlayerPrefs.SetInt("ScreenMode", index);    
        if (index == 0)
        {
            Screen.SetResolution(DPGs.dophangiai.width, DPGs.dophangiai.height, true);

            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
        if (index == 1)
        {
            Screen.SetResolution(DPGs.dophangiai.width, DPGs.dophangiai.height, true);
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        if (index == 2)
        {
            Screen.SetResolution(DPGs.dophangiai.width, DPGs.dophangiai.height, false);
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }
}
