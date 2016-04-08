using UnityEngine;
using System.Collections;

public class Shotgun : MonoBehaviour {

    public GameObject bullet;
    private float reload = .1f;
    private float currentReload = 0.0f;

	void Start ()
    {
	
	}

	void Update ()
    {

        currentReload += Time.deltaTime;

        if (Input.GetKey(KeyCode.E) && currentReload >= reload && transform.parent.GetComponent<PlayerInput>().aShop == null)
        {
            GameObject go = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            if(transform.parent.GetComponent<PlayerMovement>().GetOrientation())
                go.GetComponent<Bullet>().Launch(transform.right);
            else
                go.GetComponent<Bullet>().Launch(-transform.right);
            currentReload = 0.0f;
        }
	}
}
