using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    private Vector3 dir = Vector3.zero;
    private float speed = 10.0f;
    public int damage = 10;

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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Enemy>())
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
