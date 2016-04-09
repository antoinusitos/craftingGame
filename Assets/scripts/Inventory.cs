using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    [System.Serializable]
    public struct inventoryLoot
    {
        public Loot theLoot;
        public int quantity;
        public Sprite theTexture;
    }

    [System.Serializable]
    public struct inventoryItem
    {
        public int id;
        public string name;
        public Sprite theTexture;
    }

    public List<inventoryLoot> loots;
    public inventoryItem[] items;
    private int indexItem = 0;
    private int gold = 20;
    public GameObject goldText;

    private bool open = false;
    public GameObject panel;

    private int craftState = 1;


    void Start ()
    {
        Init();
        RefreshUI();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < items.Length; ++i)
            {
                if(items[i].id != 0)
                {
                    Debug.Log("id:" + items[i].id);
                    Debug.Log("name:" + items[i].name);
                }
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("length: " + loots.Count);
            for (int j = 0; j < loots.Count; ++j)
            {
                Debug.Log("id:" + loots[j].theLoot.GetLootId());
                Debug.Log("name:" + loots[j].theLoot.GetLootName());
                Debug.Log("quantity:" + loots[j].quantity);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            open = !open;
            panel.SetActive(open);
            RefreshUIInventory();
        }
    }

    void RefreshUIInventory()
    {
        for (int i = 0; i < items.Length; ++i)
        {
            if (items[i].id > 0)
            {
                panel.transform.GetChild(i).GetComponent<Image>().sprite = items[i].theTexture;
            }
        }
        RefreshState();
    }

    void Init()
    {
        loots = new List<inventoryLoot>();
        items = new inventoryItem[15];
    }

    void RefreshState()
    {
        ColorBlock white = new ColorBlock();
        white.normalColor = new Color(255, 255, 255, 1);
        white.colorMultiplier = 1.0f;

        ColorBlock black = new ColorBlock();
        black.normalColor = new Color(255, 255, 255, 100);
        black.colorMultiplier = 1.0f;

        if (craftState == 1)
        {
            panel.transform.GetChild(15).GetComponent<Button>().colors = white;
            panel.transform.GetChild(16).GetComponent<Button>().colors = black;
        }
        else
        {
            panel.transform.GetChild(15).GetComponent<Button>().colors = black;
            panel.transform.GetChild(16).GetComponent<Button>().colors = white;
        }
    }

    public void CraftState(GameObject obj)
    {
        if(craftState == 1)
        {
            panel.transform.GetChild(15).GetComponent<Image>().sprite = obj.GetComponent<Image>().sprite;
            craftState ++;
        }
        else
        {
            panel.transform.GetChild(16).GetComponent<Image>().sprite = obj.GetComponent<Image>().sprite;
            craftState = 1;
        }
        RefreshState();
    }

	public void AddLoot(Loot theLoot)
    {
        Containing(theLoot);
    }

    public void Containing(Loot theLoot)
    {
        for (int i = 0; i < loots.Count; ++i)
        {
            if (loots[i].theLoot == theLoot)
            {
                inventoryLoot l = loots[i];
                l.quantity += 1;
                return;
            }
        }
        inventoryLoot l2 = new inventoryLoot();
        l2.quantity = 1;
        l2.theLoot = theLoot;
        loots.Add(l2);
    }

    public void AddItem(Item theItem)
    {
        if(indexItem < items.Length)
        {
            items[indexItem] = CopyItem(theItem);
            indexItem++;
        }
    }

    public bool CanPickUp()
    {
        if (indexItem < items.Length)
        {
            return true;
        }
        return false;
    }

    inventoryItem CopyItem(Item theItem)
    {
        inventoryItem i = new inventoryItem();
        i.name = theItem.GetItemName();
        i.id = theItem.GetItemId();
        i.theTexture = theItem.GetItemTexture();
        return i; 
    }

    public bool CanCraft(Item.need[] needs)
    {
        for (int i = 0; i < needs.Length; ++i)
        {
            
        }
        return true;
    }

    public int GetGold()
    {
        return gold;
    }

    public void AddGold(int amount)
    {
        gold += amount;
        RefreshUI();
    }

    public void RemoveGold(int amount)
    {
        gold -= amount;
        RefreshUI();
    }

    public void RefreshUI()
    {
        goldText.GetComponent<Text>().text = gold.ToString();
    }
}
