using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour {

    [System.Serializable]
    public struct inventoryLoot
    {
        public Loot theLoot;
        public int quantity;
    }

    [System.Serializable]
    public struct inventoryItem
    {
        public int id;
        public string name;
    }

    public List<inventoryLoot> loots;
    public inventoryItem[] items;
    private int indexItem = 0;
    
    void Start ()
    {
        Init();
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
        if (Input.GetKeyDown(KeyCode.E))
        {

        }
    }

    void Init()
    {
        loots = new List<inventoryLoot>();
        items = new inventoryItem[15];
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
        return i; 
    }

    public bool CanCraft(Item.need[] needs)
    {
        for (int i = 0; i < needs.Length; ++i)
        {
            
        }
        return true;
    }
}
