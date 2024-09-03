using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormDrop : MonoBehaviour
{

    public LayerMask waterLayer;
    private bool isWatered;
    public float groundCheckCircle;
    public Transform feetPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isWatered = Physics2D.OverlapCircle(feetPosition.position, groundCheckCircle, waterLayer);
        if (isWatered == true && Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(FallTimer());
        }
    }

    IEnumerator FallTimer()
    {
        GetComponent<CapsuleCollider2D>().enabled = false;
        yield return new WaitForSeconds(0.2f);
        GetComponent<CapsuleCollider2D>().enabled = true;
    }
}
