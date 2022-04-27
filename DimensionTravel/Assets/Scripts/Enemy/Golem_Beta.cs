using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem_Beta : MonoBehaviour
{
    public float MoveSpeed = 5f;
    bool moveSwitch=true;
    public Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (moveSwitch)
        {
            movement1();
        }
        if(!moveSwitch)
        {
            movement2();
        }
        if(transform.position.x>=1f)
        {
            moveSwitch = false;
        }
        if (transform.position.x <= -1f)
        {
            moveSwitch = true;
        }

    }

    void movement1()
    {
        transform.Translate(MoveSpeed * Time.deltaTime,0,0);
    }
    void movement2()
    {
        transform.Translate(-MoveSpeed * Time.deltaTime, 0, 0);
    }
}
