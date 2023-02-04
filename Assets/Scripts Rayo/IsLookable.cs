using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

#if UNITY_EDITOR
using UnityEditor;
using System.Net;
#endif

public class IsLookable : MonoBehaviour
{
    bool looked;
    // Start is called before the first frame update
    void Start()
    {
        looked = false;
    }
    private void OnMouseOver()
    {
        looked = true;
    }

    private void OnMouseExit()
    {
        looked = false;
    }

    public bool isBeingLooked()
    {
        return looked;
    }

}
