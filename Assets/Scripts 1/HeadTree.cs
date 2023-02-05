using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTree : MonoBehaviour
{
    public enum nodos
    {
        FOTO_LAGO, AGUJA, HILO, LLAVES, HUECO, MARK, PERIODICO, VENENO, HILO1,
        CAFE, SONMIFERO, FOTO_EMPRESARIAL, CARTA, INFORME, PINCHAZO, TAYLOR, MINERVA,
        BANCARROTA, CITA, DENUNCIA, LIBROS, POMO, CAUSA_MUERTE, DORMIDO, METODO,
        RADIO, CARA, GRITO, MOMENTO, COARTADA_MINERVA, FRANK, FINAL, SUICIDIO,
        MUERTE, HILOS, METODO2, HILO_USADO, MOTIVO_MARK, HERMANO, PUERTA, PESCA,
        WILLIAM, FINAL2, LLAVES_USADAS, ROBO, METODO_TAYLOR, CUELLO, FINAL3,
        VISITA, CENA, NULL
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

        nodosD[nodos.HILO] = new familia { pareja = nodos.HILO1, padre = nodos.HILOS };
        nodosD[nodos.HILO1] = new familia { pareja = nodos.HILO, padre = nodos.HILOS };

        nodosD[nodos.HUECO] = new familia { pareja = nodos.LLAVES, padre = nodos.HILO_USADO };
        nodosD[nodos.LLAVES] = new familia { pareja = nodos.HUECO, padre = nodos.HILO_USADO };

        nodosD[nodos.LLAVES] = new familia { pareja = nodos.POMO, padre = nodos.PUERTA };
        nodosD[nodos.POMO] = new familia { pareja = nodos.LLAVES, padre = nodos.PUERTA };

        nodosD[nodos.HILO_USADO] = new familia { pareja = nodos.PUERTA, padre = nodos.LLAVES_USADAS };
        nodosD[nodos.PUERTA] = new familia { pareja = nodos.HILO_USADO, padre = nodos.LLAVES_USADAS };

        nodosD[nodos.HILO] = new familia { pareja = nodos.LLAVES_USADAS, padre = nodos.METODO2 };
        nodosD[nodos.LLAVES_USADAS] = new familia { pareja = nodos.HILO, padre = nodos.METODO2 };

        nodosD[nodos.MARK] = new familia { pareja = nodos.FOTO_LAGO, padre = nodos.PESCA };
        nodosD[nodos.FOTO_LAGO] = new familia { pareja = nodos.MARK, padre = nodos.PESCA };

        nodosD[nodos.WILLIAM] = new familia { pareja = nodos.PESCA, padre = nodos.HERMANO };
        nodosD[nodos.PESCA] = new familia { pareja = nodos.WILLIAM, padre = nodos.HERMANO };

        nodosD[nodos.HERMANO] = new familia { pareja = nodos.PERIODICO, padre = nodos.MOTIVO_MARK };
        nodosD[nodos.PERIODICO] = new familia { pareja = nodos.HERMANO, padre = nodos.MOTIVO_MARK };

        nodosD[nodos.METODO2] = new familia { pareja = nodos.MOTIVO_MARK, padre = nodos.FINAL2 };
        nodosD[nodos.MOTIVO_MARK] = new familia { pareja = nodos.METODO2, padre = nodos.FINAL2 };

        nodosD[nodos.FOTO_EMPRESARIAL] = new familia { pareja = nodos.MINERVA, padre = nodos.FRANK };
        nodosD[nodos.MINERVA] = new familia { pareja = nodos.FOTO_EMPRESARIAL, padre = nodos.FRANK };

        nodosD[nodos.PERIODICO] = new familia { pareja = nodos.FRANK, padre = nodos.MUERTE };
        nodosD[nodos.FRANK] = new familia { pareja = nodos.PERIODICO, padre = nodos.MUERTE };

        nodosD[nodos.MUERTE] = new familia { pareja = nodos.BANCARROTA, padre = nodos.SUICIDIO };
        nodosD[nodos.BANCARROTA] = new familia { pareja = nodos.MUERTE, padre = nodos.SUICIDIO };

        nodosD[nodos.AGUJA] = new familia { pareja = nodos.VENENO, padre = nodos.CAUSA_MUERTE };
        nodosD[nodos.VENENO] = new familia { pareja = nodos.AGUJA, padre = nodos.CAUSA_MUERTE };

        nodosD[nodos.PINCHAZO] = new familia { pareja = nodos.CAUSA_MUERTE, padre = nodos.CUELLO };
        nodosD[nodos.CAUSA_MUERTE] = new familia { pareja = nodos.PINCHAZO, padre = nodos.CUELLO };

        nodosD[nodos.CUELLO] = new familia { pareja = nodos.DORMIDO, padre = nodos.METODO };
        nodosD[nodos.DORMIDO] = new familia { pareja = nodos.CUELLO, padre = nodos.METODO };

        nodosD[nodos.LIBROS] = new familia { pareja = nodos.METODO, padre = nodos.CARA };
        nodosD[nodos.METODO] = new familia { pareja = nodos.LIBROS, padre = nodos.CARA };

        nodosD[nodos.METODO] = new familia { pareja = nodos.RADIO, padre = nodos.GRITO };
        nodosD[nodos.RADIO] = new familia { pareja = nodos.METODO, padre = nodos.GRITO };

        nodosD[nodos.CARA] = new familia { pareja = nodos.GRITO, padre = nodos.MOMENTO };
        nodosD[nodos.GRITO] = new familia { pareja = nodos.CARA, padre = nodos.MOMENTO };

        nodosD[nodos.MOMENTO] = new familia { pareja = nodos.INFORME, padre = nodos.COARTADA_MINERVA };
        nodosD[nodos.INFORME] = new familia { pareja = nodos.MOMENTO, padre = nodos.COARTADA_MINERVA };

        nodosD[nodos.COARTADA_MINERVA] = new familia { pareja = nodos.SUICIDIO, padre = nodos.FINAL };
        nodosD[nodos.SUICIDIO] = new familia { pareja = nodos.COARTADA_MINERVA, padre = nodos.FINAL };

        nodosD[nodos.CITA] = new familia { pareja = nodos.TAYLOR, padre = nodos.VISITA };
        nodosD[nodos.TAYLOR] = new familia { pareja = nodos.CITA, padre = nodos.VISITA };

        nodosD[nodos.TAYLOR] = new familia { pareja = nodos.DENUNCIA, padre = nodos.ROBO };
        nodosD[nodos.DENUNCIA] = new familia { pareja = nodos.TAYLOR, padre = nodos.ROBO };

        nodosD[nodos.VISITA] = new familia { pareja = nodos.ROBO, padre = nodos.METODO_TAYLOR };
        nodosD[nodos.ROBO] = new familia { pareja = nodos.VISITA, padre = nodos.METODO_TAYLOR };

        nodosD[nodos.METODO_TAYLOR] = new familia { pareja = nodos.CARTA, padre = nodos.FINAL3 };
        nodosD[nodos.CARTA] = new familia { pareja = nodos.METODO_TAYLOR, padre = nodos.FINAL3 };

        nodosD[nodos.CENA] = new familia { pareja = nodos.NULL, padre = nodos.NULL };

        nodosD[nodos.FINAL] = new familia { pareja = nodos.NULL, padre = nodos.NULL };

        nodosD[nodos.FINAL2] = new familia { pareja = nodos.NULL, padre = nodos.NULL };

        nodosD[nodos.FINAL3] = new familia { pareja = nodos.NULL, padre = nodos.NULL };


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
