using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryTeller : MonoBehaviour
{

    public GameObject window;
    public TMP_Text dialogueText;
    public List<string> dialogues;
    public float tocdochu;
    public int sodong;
    public int sokytu;
    public bool batdau;
    public bool tieptuc;

    void Start()
    {
        StartCoroutine(Writing());
    }
    public void Awake()
    {
        ToggleWindow(false);
    }
    public void ToggleWindow(bool show)
    {
        window.SetActive(show);
    }


    public void StartDialogue()
    {

        if (batdau)
            return;
        batdau = true;
     //   ToggleWindow(true);
        GetDialogue(0);
        Debug.Log("Chat");
    }

    public void GetDialogue(int i)
    {
        sodong = i;
        sokytu = 0;
        dialogueText.text = string.Empty;
        StartCoroutine(Writing());
    }
    IEnumerator Writing()
    {
        string currentDialogue = dialogues[sodong];
        dialogueText.text += currentDialogue[sokytu];
        sokytu++;
        if (sokytu < currentDialogue.Length)
        {
            yield return new WaitForSeconds(tocdochu);
            StartCoroutine(Writing());
        }
        else
        {
            tieptuc = true;
            ToggleWindow(true);
        }
    }

    public void Chuyencanh1()
    {
            sodong++;
            if (sodong < dialogues.Count)
            {
                GetDialogue(sodong);
            }
        else
        {
            SceneManager.LoadScene(5);
        }
    }
    public void Chuyencanh2()
    {
        sodong++;
        if (sodong < dialogues.Count)
        {
            GetDialogue(sodong);
        }
        else
        {
            SceneManager.LoadScene(6);
        }
    }
    public void Chuyencanh3()
    {
        sodong++;
        if (sodong < dialogues.Count)
        {
            GetDialogue(sodong);
        }
        else
        {
            SceneManager.LoadScene(7);
        }
    }
    public void Chuyencanh4()
    {
        sodong++;
        if (sodong < dialogues.Count)
        {
            GetDialogue(sodong);
        }
        else
        {
            SceneManager.LoadScene(8);
        }
    }
    public void Chuyencanh5()
    {
        sodong++;
        if (sodong < dialogues.Count)
        {
            GetDialogue(sodong);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    
    public void Chuyencanh6()
    {
        sodong++;
        if (sodong < dialogues.Count)
        {
            GetDialogue(sodong);
        }
        else
        {
            SceneManager.LoadScene(14);
        }
    }
    public void ChuyencanhEnding()
    {
        sodong++;
        if (sodong < dialogues.Count)
        {
            GetDialogue(sodong);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}

