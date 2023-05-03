using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporting : MonoBehaviour
{
    public Transform poisicionDestino;
    void OnTriggerEnter(Collider other)
    {
        other.transform.position = poisicionDestino.position;
    }
}
