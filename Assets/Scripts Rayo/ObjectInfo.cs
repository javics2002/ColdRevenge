using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInfo : MonoBehaviour
{
    public Dialogue objectInfo;

    public void TriggerObjectInfo()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(objectInfo);
    }
}
