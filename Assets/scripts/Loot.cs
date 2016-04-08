using UnityEngine;
using System.Collections;

public class Loot : MonoBehaviour {

    public string lootName;
    public int lootId;

    public void Init(int theId, string theName)
    {
        lootId = theId;
        lootName = theName;
    }

    public int GetLootId()
    {
        return lootId;
    }

    public void SetLootId(int value)
    {
        lootId = value;
    }

    public string GetLootName()
    {
        return lootName;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (other.GetComponent<Inventory>())
            {
                other.GetComponent<Inventory>().AddLoot(this);
                Destroy(gameObject);
            }
        }
    }
}
