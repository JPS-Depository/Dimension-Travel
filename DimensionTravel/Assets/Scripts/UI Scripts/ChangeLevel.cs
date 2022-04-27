using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public Rigidbody2D car;

    private int level = 1;

    void ChangedLevel()
    {
        if (car.velocity.magnitude > 23)
        {
            Debug.Log("Change to level" + level);
        }
    }
}
