using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour, IQuanliLuutru
{
    [SerializeField] private string id;
    [SerializeField] private AudioClip collectSound;
    [ContextMenu("Khởi tạo id ngẫu nhiên")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private SpriteRenderer visual;
    private ParticleSystem collectParticle;
    private AudioSource audioSource;
    private bool collected = false;

    private void Awake()
    {
        visual = this.GetComponentInChildren<SpriteRenderer>();
        collectParticle = this.GetComponentInChildren<ParticleSystem>();
        collectParticle.Stop();

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = collectSound;
    }

    public void LoadData(GameData data)
    {
        data.coinsCollected.TryGetValue(id, out collected);
        if (collected)
        {
            visual.gameObject.SetActive(false);
        }
    }

    public void SaveData(GameData data)
    {
        if (data.coinsCollected.ContainsKey(id))
        {
            data.coinsCollected.Remove(id);
        }
        data.coinsCollected.Add(id, collected);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!collected)
            {
                collectParticle.Play();
                CollectCoin();
            }
        }
    }

    private void CollectCoin()
    {
        collected = true;
        visual.gameObject.SetActive(false);
        GameEventsManager.instance.CoinCollected();
        audioSource.Play();
        Debug.Log("Coin sound played!");

    }

}
