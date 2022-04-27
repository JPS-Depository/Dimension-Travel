using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAI : MonoBehaviour
{
    private Transform _player;
    public float MoveSpeed = 5f;
    public float stoppingDistance=10f;
    public float retreatDistance=20f;
    public float AOE = 10f;
    private float shotInterval;
    private float startShot = 2;
    private Vector2 startPos;
    private Vector2 curPos;

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        shotInterval = startShot;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tracking();
    }

    void tracking()
    {
        //MoveSpeed = 5f;
        //if(Vector2.Distance(transform.position, _player.position) > stoppingDistance)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, _player.position, MoveSpeed * Time.deltaTime);
        //}
        //else if (Vector2.Distance(transform.position, _player.position) < stoppingDistance && Vector2.Distance(transform.position, _player.position) > retreatDistance)
        //{
        //    transform.position = this.transform.position;
        //}else if(Vector2.Distance(transform.position, _player.position) < retreatDistance)
        //{
        //    transform.position = Vector2.MoveTowards(transform.position, _player.position, - MoveSpeed * Time.deltaTime);
        //}

        if (Vector2.Distance(startPos, _player.position) < AOE)
        {
            if (Vector2.Distance(transform.position, _player.position) > stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, _player.position, MoveSpeed * Time.deltaTime);
                shot();
                curPos = transform.position;
            }
            else if (Vector2.Distance(transform.position, _player.position) < stoppingDistance && Vector2.Distance(transform.position, _player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
                shot();
                curPos = transform.position;
            }
            else if (Vector2.Distance(transform.position, _player.position) < retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, _player.position, -MoveSpeed * Time.deltaTime);
                shot();
                curPos = transform.position;
            }
        }
        else
        {
            //if(Vector2.Distance(transform.position, _player.position) >3)
            transform.position = Vector2.MoveTowards(curPos, startPos, MoveSpeed * Time.deltaTime);
            curPos = transform.position;
        }

    }
    
    void shot()
    {
        if(shotInterval<=0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            shotInterval = startShot;
        }
        else
        {
            shotInterval -= Time.deltaTime;
        }
    }

}
