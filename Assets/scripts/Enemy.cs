using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int life = 100;

	public void TakeDamage(int amount)
    {
        life -= amount;
        if(life <= 0)
        {
            int rand = Random.Range(10, 60);
            PlayersManager.Instance.BroadcastGold(rand);
            Destroy(gameObject);
        }
    }
}
