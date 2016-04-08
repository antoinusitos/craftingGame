using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayersManager : MonoBehaviour {

    public List<GameObject> players;

    private static PlayersManager instance;

    public static PlayersManager Instance
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        players = new List<GameObject>();
        GameObject[] go = GameObject.FindGameObjectsWithTag("Player");
        for(int i= 0; i < go.Length; ++i)
        {
            players.Add(go[i]);
        }
    }

    public void BroadcastGold(int amount)
    {
        foreach(GameObject g in players)
        {
            g.GetComponent<Inventory>().AddGold(amount);
        }
    }

}
