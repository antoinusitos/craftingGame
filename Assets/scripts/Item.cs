using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public string itemName;
    public int itemId;

    [System.Serializable]
    public struct need
    {
        public int id;
        public int quantity;
    }

    public need[] needs;

    public void Init(int theId, string theName)
    {
        itemId = theId;
        itemName = theName;
    } 

    public int GetItemId()
    {
        return itemId;
    }

    public void SetItemId(int value)
    {
        itemId = value;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public void SetItemName(string value)
    {
        itemName = value;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (other.GetComponent<Inventory>() != null && other.GetComponent<Inventory>().CanPickUp())
            {
                other.GetComponent<Inventory>().AddItem(this);
                Destroy(gameObject);
            }
        }
    }
}
