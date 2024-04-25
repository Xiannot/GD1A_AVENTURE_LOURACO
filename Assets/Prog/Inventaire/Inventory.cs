using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public TextMeshProUGUI coinsCountText;

    public List<Item> content = new List<Item>();
    public int contentCurrentIndex = 0;
    public static Inventory instance;
    public Image itemUIImage;
    public Sprite emptyItemImage;







    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            ConsumeItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetNextItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GetPreviousItem();
        }
    }
    

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }


    private void Start()
    {
        UpdateInventoryUI();
    }


    public void ConsumeItem()
    {
        if(content.Count == 0)
        {
            return;
        }
        Item currentItem = content[contentCurrentIndex];

        if (currentItem.id == 1)
        {
            PlayerHealth.instance.HealPlayer(currentItem.hpGiven);
            content.Remove(currentItem);
            GetNextItem();
            UpdateInventoryUI();
        }

        if (currentItem.id == 2)
        {
            PlayerController.instance.sword = false;
            PlayerController.instance.arcbool = true;
            PlayerController.instance.crosshairbool = true;

        }

        if (currentItem.id == 3)
        {
            PlayerController.instance.arcbool = false;
            PlayerController.instance.sword = true;
            PlayerController.instance.crosshairbool = false;


        }


    }


    public void GetNextItem()
    {

            if (content.Count == 0)
        {
            return;
        }

        contentCurrentIndex++;
        if(contentCurrentIndex > content.Count - 1)
        {
            contentCurrentIndex = 0;
        }
        UpdateInventoryUI();
    }

    public void GetPreviousItem()
    {

        
        if(content.Count == 0)
        {
            return;
        }

        contentCurrentIndex--;
        if (contentCurrentIndex < 0)
        {
            contentCurrentIndex = content.Count - 1;
        }
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        if(content.Count > 0)
        {
            itemUIImage.sprite = content[contentCurrentIndex].image;
        }
        else
        {
            itemUIImage.sprite = emptyItemImage;
        }
        
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        UpdateTextUI();
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        UpdateTextUI();
    }

    public void UpdateTextUI()
    {
        coinsCountText.text = coinsCount.ToString();
    }
}
