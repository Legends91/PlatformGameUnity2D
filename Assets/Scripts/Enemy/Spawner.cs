using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] quai;
    public float thoigianhoi;

    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    IEnumerator EnemySpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(thoigianhoi);
            HoiQuai();
        }
    }
    void HoiQuai()
    {
        int randomValue = Random.Range(0, quai.Length);
        int randomXpos = Random.Range(30, 45);
        Instantiate(quai[randomValue], new Vector2(randomXpos, transform.position.y), Quaternion.identity);
    }
}
