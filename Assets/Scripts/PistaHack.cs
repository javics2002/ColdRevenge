using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PistaHack : MonoBehaviour
{
    [SerializeField]
    string tecla;
    [SerializeField]
	EventTrigger.TriggerEvent customCallback;

	private void Update() {
		if (Input.GetKeyDown(tecla)) 
			customCallback.Invoke(null);
	}
}
