using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOrbit : MonoBehaviour
{
    [SerializeField]
    private Vector2 sensitivity;

    [SerializeField] 
    private LookAtObject lookAtObject;

    IsLookable isLookable;

    // Start is called before the first frame update
    void Start()
    {
        isLookable = GetComponent<IsLookable>();
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && lookAtObject.isFocusingObject() && isLookable.isBeingLooked())
        {
            transform.Rotate((Input.GetAxis("Mouse Y") * sensitivity.y * 100 * Time.deltaTime), (Input.GetAxis("Mouse X") * -sensitivity.x * 100 * Time.deltaTime), 0, Space.World);
        }
    }
}