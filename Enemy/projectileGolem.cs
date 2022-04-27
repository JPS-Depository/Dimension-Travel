using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileGolem : MonoBehaviour
{
    public float speed = 20f;
    private Vector2 target;
    // Start is called before the first frame update
    void Start()
    {
        target = Vector2.right;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            //insert collision here in the future
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //i don't know why it didn't detect player collision, but the collision is there
            DestroyProjectile();
        }
    }
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
