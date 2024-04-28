using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class PickUpItem : MonoBehaviour
{
    private Text interactUI;
    private bool isInRange;

    public Item item;

    public int playerId = 0;
    private Player player;



    void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isInRange)
        {
            TakeItem();
            Inventory.instance.ConsumeItem();


        }

        if (player.GetButtonDown("Loot") && isInRange)
        {
            TakeItem();
            Inventory.instance.ConsumeItem();
            PlayerController.instance.useController =true;


        }
    }

    void TakeItem()
    {
        Inventory.instance.content.Add(item);
        Inventory.instance.UpdateInventoryUI();
      
        
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            isInRange = false;
        }
    }
}