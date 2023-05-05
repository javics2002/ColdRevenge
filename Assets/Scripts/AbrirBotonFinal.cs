using UnityEngine;

public class AbrirBotonFinal : MonoBehaviour
{
    public GameObject abierta, cerrada;

    public void AbrirBoton() {
        abierta.SetActive(true);
        cerrada.SetActive(false);
    }
}
