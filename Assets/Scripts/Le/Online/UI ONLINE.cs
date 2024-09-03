using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class UIONLINE : MonoBehaviour
{
    [SerializeField] private Button MayChu;
    [SerializeField] private Button MayKhach;

    private void Awake()
    {
        MayChu.onClick.AddListener(() =>
        {
            Debug.Log("Chu");
            NetworkManager.Singleton.StartHost();
            Hide();
        });
        MayKhach.onClick.AddListener(() => 
        {
            Debug.Log("Khach");
            NetworkManager.Singleton.StartClient();
            Hide() ;
    });
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
