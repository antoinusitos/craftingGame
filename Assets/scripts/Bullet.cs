using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private Vector3 dir = Vector3.zero;
    private float speed = 10.0f;

    void Update()
    {
        if(dir != Vector3.zero)
        {
            transform.position += dir * Time.deltaTime * speed;
        }
    }

    public void Launch(Vector3 direction)
    {
        dir = direction;
    }
}
