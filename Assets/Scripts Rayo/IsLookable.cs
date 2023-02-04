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
    bool mouseOver;
    bool beingLooked;
    // Start is called before the first frame update
    void Start()
    {
        mouseOver = false;
        beingLooked = false;
    }
    private void OnMouseOver()
    {
        mouseOver = true;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
    }

    public bool isMouseOver()
    {
        return mouseOver;
    }

    public bool isBeingLooked()
    {
        return beingLooked;
    }
    public void setLooked(bool newLook)
    {
        beingLooked = newLook;
    }

}
