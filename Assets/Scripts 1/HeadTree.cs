using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTree : MonoBehaviour
{
    public enum nodos
    {
        FOTO_LAGO, AGUJA, HILO, LLAVES, HUECO, MARK, PERIODICO, VENENO, HILO1,
        CAFE, SONMIFERO, FOTO_EMPRESARIAL, CARTA, INFORME, PINCHAZO, TYLOR, MINERVA,
        BANCARROTA, CITA, DENUNCIA, LIBROS, POMO, CAUSA_MUERTE, DORMIDO, METODO,
        RADIO, CARA, GRITO, MOMENTO, COARTADA_MINERVA, FRANK, FINAL, SUICIDIO,
        MUERTE, HILOS, METODO2, HILO_USADO, MOTIVO_MARK, HERMANO, PUERTA, PESCA,
        WILLIAM, FINAL2, LLAVES_USADAS, ROBO, METODO_TAYLOR, CUELLO, FINAL3,
        VISITA,
    }


    public struct familia
    {
        public nodos pareja;
        public nodos padre;
    }
    Dictionary<nodos, familia> nodosD;

    // Start is called before the first frame update
    void Start()
    {

        nodosD[nodos.HUECO] = new familia { pareja = nodos.LLAVES, padre = nodos.HILO_USADO };
        nodosD[nodos.LLAVES] = new familia { pareja = nodos.HUECO, padre = nodos.HILO_USADO };
        nodosD[nodos.LLAVES] = new familia { pareja = nodos.HUECO, padre = nodos.HILO_USADO };
        nodosD[nodos.LLAVES] = new familia { pareja = nodos.HUECO, padre = nodos.HILO_USADO };
        nodosD[nodos.LLAVES] = new familia { pareja = nodos.HUECO, padre = nodos.HILO_USADO };
        nodosD[nodos.LLAVES] = new familia { pareja = nodos.HUECO, padre = nodos.HILO_USADO };
        nodosD[nodos.LLAVES] = new familia { pareja = nodos.HUECO, padre = nodos.HILO_USADO };
        nodosD[nodos.LLAVES] = new familia { pareja = nodos.HUECO, padre = nodos.HILO_USADO };
        nodosD[nodos.LLAVES] = new familia { pareja = nodos.HUECO, padre = nodos.HILO_USADO };
        nodosD[nodos.LLAVES] = new familia { pareja = nodos.HUECO, padre = nodos.HILO_USADO };
        nodosD[nodos.LLAVES] = new familia { pareja = nodos.HUECO, padre = nodos.HILO_USADO };
        nodosD[nodos.LLAVES] = new familia { pareja = nodos.HUECO, padre = nodos.HILO_USADO };

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
