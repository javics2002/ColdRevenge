using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class LookAtObject : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> gameObjectsList = new List<GameObject>();

    GameObject focusGameObject;

    [SerializeField]
    TextMeshProUGUI uiText;

    [SerializeField]
    Volume blurEffect;

    [SerializeField]
    DialogueManager dialogueManager;

    [SerializeField]
    Transform destinyObjectTransform;

    [SerializeField]
    int focusSpeed;

    bool focusingObject = false;

    bool focusingNPC = false;

    Vector3 objectOrigPosition;
    Quaternion objectOrigRotation;

    void Start()
    {
        uiText.SetText("");
    }

    // Update is called once per frame
    void Update()
    {
        if (!focusingObject && !focusingNPC) {
            if(focusGameObject != null)
            {
                // quitamos zoom
                Vector3 newPosition = Vector3.Lerp(focusGameObject.transform.position, objectOrigPosition, Time.deltaTime * focusSpeed);
                Quaternion newRotation = Quaternion.Lerp(focusGameObject.transform.rotation, objectOrigRotation, Time.deltaTime * focusSpeed);

                if(Vector3.Distance(newPosition, objectOrigPosition) < 0.01)
                {
                    focusGameObject.transform.position = objectOrigPosition;
                    focusGameObject.transform.rotation = objectOrigRotation;

                    focusGameObject.GetComponent<Collider>().enabled = true;

                    focusGameObject.transform.SetPositionAndRotation(objectOrigPosition, objectOrigRotation);

                    focusGameObject = null;
                    objectOrigPosition = Vector3.zero;
                    objectOrigRotation = Quaternion.identity;

                }
                else
                    focusGameObject.transform.SetPositionAndRotation(newPosition, newRotation);
            }

            foreach (GameObject go in gameObjectsList)
            {
                if (go != null)
                {
                    IsLookable look = go.GetComponent<IsLookable>();
                    if (look != null && look.isMouseOver())
                    {
                        uiText.SetText(go.name);
                        if (Input.GetKeyDown(KeyCode.E)) // Distinguir si interactuas con NPC o con objeto
                        {
                            focusGameObject = go;

                            if (focusGameObject.CompareTag("NPC"))
                            {
                                focusingNPC = true;
                                NPCAnimationController npcAnim = focusGameObject.GetComponent<NPCAnimationController>();
                                npcAnim.startTalkingAnim();

                                ObjectInfo objectInfo = focusGameObject.GetComponent<ObjectInfo>();
                                if (objectInfo != null)
                                    objectInfo.TriggerObjectInfo();
                            }
                            else if (focusGameObject.CompareTag("Door"))
                            {
                                Animator doorAnimator = focusGameObject.GetComponent<Animator>();
                                doorAnimator.SetBool("openDoor", true);

                                Collider collider = focusGameObject.GetComponent<Collider>();
                                collider.enabled = false;

                                focusGameObject = null;
                            }
                            else
                            {
                                focusingObject = true;

                                look.setLooked(true);

                                objectOrigPosition = new Vector3(focusGameObject.transform.position.x, focusGameObject.transform.position.y, focusGameObject.transform.position.z);
                                objectOrigRotation = new Quaternion(focusGameObject.transform.rotation.x, focusGameObject.transform.rotation.y, focusGameObject.transform.rotation.z, focusGameObject.transform.rotation.w);

                                ObjectInfo objectInfo = focusGameObject.GetComponent<ObjectInfo>();
                                if (objectInfo != null)
                                    objectInfo.TriggerObjectInfo();
                            }

                           

                        }
                    }
                    else
                    {
                        uiText.SetText("");
                    }
                }
            }
        }
        else
        {
            if (focusingNPC)
            {
                // Desactivar movimiento
                FirstPersonController playerController = GetComponentInParent<FirstPersonController>();
                Rigidbody playerRigidbody = GetComponentInParent<Rigidbody>();

                if (playerController != null && playerRigidbody != null)
                {
                    playerController.DeativateCrosshair();

                    playerController.enabled = false;
                    playerRigidbody.velocity = Vector3.zero;
                }

                // Quitar Texto
                uiText.SetText("");

                // Quitar colision
                //focusGameObject.GetComponent<Collider>().enabled = false;


                // Quitar foco
                if (Input.GetKeyDown(KeyCode.E) && !dialogueManager.isDisplayingDialogue())
                {
                    // Quitamos Foco
                    focusingNPC = false;

                    // Activamos playercontroller
                    playerController.enabled = true;
                    playerController.ActivateCrosshair();

                    NPCAnimationController npcAnim = focusGameObject.GetComponent<NPCAnimationController>();
                    npcAnim.stopTalkingAnim();

                    // Null al objeto foco
                    focusGameObject = null;
                }
            }

            if (focusingObject)
            {
                // Blur camera
                blurEffect.enabled = true;

                // Desactivar movimiento
                FirstPersonController playerController = GetComponentInParent<FirstPersonController>();
                Rigidbody playerRigidbody = GetComponentInParent<Rigidbody>();

                if (playerController != null && playerRigidbody != null)
                {
                    playerController.DeativateCrosshair();

                    playerController.enabled = false;
                    playerRigidbody.velocity = Vector3.zero;
                }

                // Mostrar el cursor
                UnityEngine.Cursor.visible = true;
                UnityEngine.Cursor.lockState = CursorLockMode.None;

                // Quitar Texto
                uiText.SetText("");

                // Quitar colision
                focusGameObject.GetComponent<Collider>().enabled = false;

                // Zoom al objeto
                Vector3 newPosition = Vector3.Lerp(focusGameObject.transform.position, destinyObjectTransform.position, Time.deltaTime * focusSpeed);
                focusGameObject.transform.SetPositionAndRotation(newPosition, focusGameObject.transform.rotation);

                // Poder rotar el objeto

                // Quitar foco
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Quitamos Foco
                    focusingObject = false;
                    blurEffect.enabled = false;

                    // Desactivamos cursor
                    UnityEngine.Cursor.visible = false;
                    UnityEngine.Cursor.lockState = CursorLockMode.Locked;

                    focusGameObject.GetComponent<IsLookable>().setLooked(false);

                    // Activamos playercontroller
                    playerController.enabled = true;

                    playerController.ActivateCrosshair();
                }
            }
        }

       
    }
    public bool isFocusingObject()
    {
        return focusingObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IsLookable>() && !gameObjectsList.Contains(other.gameObject))
            gameObjectsList.Add(other.gameObject);
    }
    //private void OnTriggerStay(Collider other)
    //{
    //    gameObjectsList.Add(other.gameObject);
    //}
    private void OnTriggerExit(Collider other){
        if (other.GetComponent<IsLookable>())
        {
            gameObjectsList.Remove(other.gameObject);
            uiText.SetText("");
        }
            
       
    }
}
