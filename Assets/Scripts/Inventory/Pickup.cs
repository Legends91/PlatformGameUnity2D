using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int mau;
    public Health health;
    
    private Inventory inventory;
    private Transform player;
    public GameObject itemButton;
    public GameObject effect;
   
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            /*for(int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemButton, inventory.slots[i].transform, false); */
            
            health.HoiMau(mau);
            Instantiate(effect, player.position, Quaternion.identity);
            
            //Instantiate(sound, player.position, Quaternion.identity);
            Destroy(gameObject);
            Debug.LogWarning("Nhặt thành công") ;
                    



        }
    }

    // Update is called once per frame
  
}
