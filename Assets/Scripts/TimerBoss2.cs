using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TImerBoss2 : MonoBehaviour
{
    public float WaitSec;
    private float WaitSecInt;
    public Text text;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        if(WaitSec > 0)
        {
            WaitSec -= Time.fixedDeltaTime;
            WaitSecInt = (int)WaitSec;
            text.text = WaitSecInt.ToString();
        }
        else
        {
            SceneManager.LoadScene(19);
        }
    }

   
}
