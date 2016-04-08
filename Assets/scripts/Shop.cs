using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {

    private bool open = false;

    public GameObject[] items;
    private GameObject player;

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
            player = other.gameObject;
        }
    }
}
