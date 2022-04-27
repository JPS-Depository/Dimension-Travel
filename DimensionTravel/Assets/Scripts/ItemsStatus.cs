using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsStatus : MonoBehaviour
{
    public bool items1_1;
    public bool items1_2;
    public bool items2_1;
    public bool items2_2;
    public bool items3_1;
    public bool items3_2;

    public int currentLevel = 1;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        
    }

    
}
