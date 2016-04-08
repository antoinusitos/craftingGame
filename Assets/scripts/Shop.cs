using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Shop : MonoBehaviour {

    private bool open = false;

    [System.Serializable]
    public struct shopItem
    {
        public int cost;
        public GameObject item;
    }

    public shopItem[] items;
    private GameObject player;

    public GameObject panel;

    void Start()
    {
        panel.GetComponent<PanelShop>().theShop = gameObject;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {

        }
    }
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerInput>().aShop = gameObject;
            player = other.gameObject;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerInput>().aShop = null;
            player = null;
        }
    }

    public void OpenOrClose()
    {
        open = !open;
        if(open)
        {
            panel.SetActive(true);
        }
        else
        {
            panel.SetActive(false);
        }
    }

    public void Execute(int i)
    {
        if(player.GetComponent<Inventory>().GetGold() >= items[i].cost)
        {
            player.GetComponent<Inventory>().AddItem(items[i].item.GetComponent<Item>());
            player.GetComponent<Inventory>().RemoveGold(items[i].cost);
        }
    }
}
