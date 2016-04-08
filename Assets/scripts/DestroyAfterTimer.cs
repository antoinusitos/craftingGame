using UnityEngine;
using System.Collections;

public class DestroyAfterTimer : MonoBehaviour {

    public float timer;

	void Start()
    {
        Destroy(gameObject, timer);
    }
}
