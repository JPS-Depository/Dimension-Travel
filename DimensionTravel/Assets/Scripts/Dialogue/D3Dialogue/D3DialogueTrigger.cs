using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class D3DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    void Start()
    {
        Debug.Log("Numpang Lewat");
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<D3DialogueManager>().StartDialogue(dialogue);
    }
}
