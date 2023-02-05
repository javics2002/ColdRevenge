using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleScale : MonoBehaviour
{
    bool aumenta=true;
    bool decrementa = false;

    private void Update()
    {
        if (transform.localScale.x >= 1.04)
        {
            aumenta = false;
            decrementa = true;
        }
        else if (transform.localScale.z <= 1)
        {
            aumenta = true;
            decrementa = false;
        }

        if(aumenta)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * 2f, Time.deltaTime * 0.01f);
        }
        else if(decrementa)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, -transform.localScale/1.5f, Time.deltaTime * 0.01f);
        }
    }
}
