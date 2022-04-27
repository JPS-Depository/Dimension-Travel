using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D1DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    void Start()
    {
        Debug.Log("Numpang Lewat");
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<D1DialogueManager>().StartDialogue(dialogue);
    }
}
