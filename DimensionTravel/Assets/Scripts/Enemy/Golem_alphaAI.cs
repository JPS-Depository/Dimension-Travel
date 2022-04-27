using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_alphaAI : MonoBehaviour
{
    private float shotInterval;
    private float startShot = 2;
    private Vector2 startPos;

    public GameObject projectileGolem;
    public Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (Vector2.Distance(startPos, _player.position) < 5)
        {
            onewayprojectile();
        }
    }

    void onewayprojectile()
    {
        if (shotInterval <= 0)
        {
            Instantiate(projectileGolem, transform.position, Quaternion.identity);
            shotInterval = startShot;
        }
        else
        {
            shotInterval -= Time.deltaTime;
        }
    }
}
