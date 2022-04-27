﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    void Start()
    {
        Debug.Log("Numpang Lewat");
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<EDialogueManager>().StartDialogue(dialogue);
    }
}
