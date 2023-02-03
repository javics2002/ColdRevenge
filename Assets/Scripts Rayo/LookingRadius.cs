using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LookingRadius : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> gameObjectsList = new List<GameObject>();

    [SerializeField]
    TextMeshProUGUI uiText;


    void Start()
    {
        uiText.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject go in gameObjectsList)
        {
            if (go != null)
            {
                LookAtObject look = go.GetComponent<LookAtObject>();
                if (look != null && look.isBeingLooked())
                {
                    uiText.SetText(go.name);
                }
                else{
                    uiText.SetText("");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObjectsList.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other){
        gameObjectsList.Remove(other.gameObject);
    }
}
