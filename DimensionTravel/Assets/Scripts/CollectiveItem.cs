using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiveItem : MonoBehaviour
{
    public int nextLevel;
    public int numberItem;

    private ItemsStatus itemsStatus;

    private void Start()
    {
        itemsStatus = FindObjectOfType<ItemsStatus>();
    }

    private void Update()
    {
        if (itemsStatus.items1_1 && (numberItem == 1)) gameObject.SetActive(false);
        if (itemsStatus.items1_2 && (numberItem == 2)) gameObject.SetActive(false);
        if (itemsStatus.items2_1 && (numberItem == 3)) gameObject.SetActive(false);
        if (itemsStatus.items2_2 && (numberItem == 4)) gameObject.SetActive(false);
        if (itemsStatus.items3_1 && (numberItem == 5)) gameObject.SetActive(false);
        if (itemsStatus.items3_2 && (numberItem == 6)) gameObject.SetActive(false);
    }
}
