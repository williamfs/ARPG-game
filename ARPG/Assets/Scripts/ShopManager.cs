using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject shopingPanel;
    public string[] shopItems = new string[40];
    public Button[] itemButtons;
    public Image[] itemImages;
    public Item[] itemPrefabs;


    public Text descriptionText;

    public Item activeItem;

    private bool hasOpen;

    // Start is called before the first frame update
    void Start()
    {
        itemImages = new Image[itemButtons.Length];
        for (int i = 0; i < itemImages.Length; i++)
        {
            itemImages[i] = itemButtons[i].transform.GetChild(0).GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasOpen && Input.GetKeyDown(KeyCode.I))
        {
            OpenShoppingMenu();
        }
        else if (hasOpen && Input.GetKeyDown(KeyCode.I))
        {
            CloseShoppingMenu();
        }
    }

    private void OpenShoppingMenu()
    {
        hasOpen = true;
        shopingPanel.SetActive(true);
        SortItems();
        UpdateItemButton();
    }

    public void CloseShoppingMenu()
    {
        hasOpen = false;
        shopingPanel.SetActive(false);
    }

    private void UpdateItemButton()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            if (shopItems[i] != "")
            {
                for (int j = 0; j < itemPrefabs.Length; j++)
                {
                    if (shopItems[i] == itemPrefabs[j].itemName)
                    {
                        itemImages[i].color = new Color(1, 1, 1, 1);
                        itemImages[i].sprite = itemPrefabs[j].sprite;
                        itemButtons[i].GetComponentInChildren<Text>().text = itemPrefabs[j].number.ToString();
                    }
                }
            }
            else
            {
                itemImages[i].color = new Color(1, 1, 1, 0);
                itemButtons[i].GetComponentInChildren<Text>().text = "";
            }
        }
    }

    private void SortItems()
    {
        bool haveSpace = false;

        for (int i = 0; i < shopItems.Length - 1; i++)
        {

            if (shopItems[i] == "")
            {
                shopItems[i] = shopItems[i + 1];
                shopItems[i + 1] = "";
            }

            if (shopItems[i] == "")
            {
                haveSpace = true;
            }
            else
            {
                haveSpace = false;
            }

            while (haveSpace)
            {
                for (int j = i + 2; j < shopItems.Length; j++)
                {
                    if (shopItems[j] != "")
                    {
                        shopItems[i] = shopItems[j];
                        shopItems[j] = "";
                        haveSpace = false;
                        break;
                    }
                }
                haveSpace = false;
            }
        }

    }

    public void Pressed(int shopIndex)
    {
        if (shopItems[shopIndex] != "")
        {
            for (int j = 0; j < itemPrefabs.Length; j++)
            {
                if (itemPrefabs[j].itemName == shopItems[shopIndex])
                {
                    descriptionText.text = itemPrefabs[j].description;
                    activeItem = itemPrefabs[j];
                }
            }

        }

    }
}
