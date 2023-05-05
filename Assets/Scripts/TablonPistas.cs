using System.Collections.Generic;

using UnityEngine;

public class TablonPistas : MonoBehaviour
{
	public enum Pistas {
		FOTO_LAGO, AGUJA, HILO, LLAVES, HUECO, MARK, PERIODICO, VENENO, HILO1,
		CAFE, SONMIFERO, FOTO_EMPRESARIAL, CARTA, INFORME, PINCHAZO, TAYLOR, MINERVA,
		BANCARROTA, CITA, DENUNCIA, LIBROS, POMO, CAUSA_MUERTE, DORMIDO, METODO,
		RADIO, CARA, GRITO, MOMENTO, COARTADA_MINERVA, FRANK, FINAL, SUICIDIO,
		MUERTE, HILOS, METODO2, HILO_USADO, MOTIVO_MARK, HERMANO, PUERTA, PESCA,
		WILLIAM, FINAL2, LLAVES_USADAS, ROBO, METODO_TAYLOR, CUELLO, FINAL3,
		VISITA, CENA, NULL
	}

	public struct Familia {
		public Pistas pareja;
		public Pistas padre;
	}

	Dictionary<Pistas, List<Familia>> relacionPistas;

	[Header("Post-its")]
	public GameObject fotoLago;
	public GameObject aguja, hilo, llaves, hueco, mark, periodico, veneno, hilo1, cafe,
		somnifero, fotoEmpresarial, carta, informe, pinchazo, taylor, minerva, bancarrota, cita,
		denuncia, libros, pomo, causaMuerte, dormido, metodo, radio, cara, grito, momento,
		coartadaMinerva, frank, suicidio, muerte, hilos, metodo2, hiloUsado, motivoMark,
		hermano, puerta, pesca, william, final2, llavesUsadas, robo, metodoTaylor, cuello, final3,
		visita, cena, final;
	bool[] postItsVisible;

	private void Start() {
		// Set all post-its to not visible
		relacionPistas = new Dictionary<Pistas, List<Familia>>();
		postItsVisible = new bool[(int)Pistas.NULL];
		for (int i = 0; i < postItsVisible.Length; i++) {
			postItsVisible[i] = false;
			relacionPistas.Add((Pistas)(i), new List<Familia>());
		}

		aguja.SetActive(false);
		hilo.SetActive(false);
		llaves.SetActive(false);
		hueco.SetActive(false);
		mark.SetActive(false);
		periodico.SetActive(false); //Promesa de donacion
		veneno.SetActive(false);
		hilo1.SetActive(false);
		cafe.SetActive(false);
		somnifero.SetActive(false);
		fotoEmpresarial.SetActive(false);
		carta.SetActive(false);
		informe.SetActive(false);
		pinchazo.SetActive(false);
		taylor.SetActive(false);
		minerva.SetActive(false);
		bancarrota.SetActive(false);
		cita.SetActive(false);
		denuncia.SetActive(false);
		libros.SetActive(false);
		pomo.SetActive(false);
		causaMuerte.SetActive(false);
		dormido.SetActive(false);
		metodo.SetActive(false);
		radio.SetActive(false);
		cara.SetActive(false);
		grito.SetActive(false);
		momento.SetActive(false);
		coartadaMinerva.SetActive(false);
		frank.SetActive(false);
		suicidio.SetActive(false);
		muerte.SetActive(false);
		hilos.SetActive(false);
		metodo2.SetActive(false);
		hiloUsado.SetActive(false);
		motivoMark.SetActive(false);
		hermano.SetActive(false);
		puerta.SetActive(false);
		pesca.SetActive(false);
		william.SetActive(false);
		final2.SetActive(false);
		llavesUsadas.SetActive(false);
		robo.SetActive(false);
		metodoTaylor.SetActive(false);
		cuello.SetActive(false);
		final3.SetActive(false);
		visita.SetActive(false);
		cena.SetActive(false);
		final.SetActive(false);
		fotoLago.SetActive(false);

		relacionPistas[Pistas.CAFE].Add(new Familia { pareja = Pistas.SONMIFERO, padre = Pistas.DORMIDO });
		relacionPistas[Pistas.SONMIFERO].Add(new Familia { pareja = Pistas.CAFE, padre = Pistas.DORMIDO });

		relacionPistas[Pistas.HILO].Add(new Familia { pareja = Pistas.HILO1, padre = Pistas.HILOS });
		relacionPistas[Pistas.HILO1].Add(new Familia { pareja = Pistas.HILO, padre = Pistas.HILOS });

		relacionPistas[Pistas.HUECO].Add(new Familia { pareja = Pistas.LLAVES, padre = Pistas.HILO_USADO });
		relacionPistas[Pistas.LLAVES].Add(new Familia { pareja = Pistas.HUECO, padre = Pistas.HILO_USADO });

		relacionPistas[Pistas.LLAVES].Add(new Familia { pareja = Pistas.POMO, padre = Pistas.PUERTA });
		relacionPistas[Pistas.POMO].Add(new Familia { pareja = Pistas.LLAVES, padre = Pistas.PUERTA });

		relacionPistas[Pistas.HILO_USADO].Add(new Familia { pareja = Pistas.PUERTA, padre = Pistas.LLAVES_USADAS });
		relacionPistas[Pistas.PUERTA].Add(new Familia { pareja = Pistas.HILO_USADO, padre = Pistas.LLAVES_USADAS });

		relacionPistas[Pistas.HILO].Add(new Familia { pareja = Pistas.LLAVES_USADAS, padre = Pistas.METODO2 });
		relacionPistas[Pistas.LLAVES_USADAS].Add(new Familia { pareja = Pistas.HILO, padre = Pistas.METODO2 });

		relacionPistas[Pistas.MARK].Add(new Familia { pareja = Pistas.FOTO_LAGO, padre = Pistas.PESCA });
		relacionPistas[Pistas.FOTO_LAGO].Add(new Familia { pareja = Pistas.MARK, padre = Pistas.PESCA });

		relacionPistas[Pistas.WILLIAM].Add(new Familia { pareja = Pistas.PESCA, padre = Pistas.HERMANO });
		relacionPistas[Pistas.PESCA].Add(new Familia { pareja = Pistas.WILLIAM, padre = Pistas.HERMANO });

		relacionPistas[Pistas.HERMANO].Add(new Familia { pareja = Pistas.PERIODICO, padre = Pistas.MOTIVO_MARK });
		relacionPistas[Pistas.PERIODICO].Add(new Familia { pareja = Pistas.HERMANO, padre = Pistas.MOTIVO_MARK });

		relacionPistas[Pistas.METODO2].Add(new Familia { pareja = Pistas.MOTIVO_MARK, padre = Pistas.FINAL2 });
		relacionPistas[Pistas.MOTIVO_MARK].Add(new Familia { pareja = Pistas.METODO2, padre = Pistas.FINAL2 });

		relacionPistas[Pistas.FOTO_EMPRESARIAL].Add(new Familia { pareja = Pistas.MINERVA, padre = Pistas.FRANK });
		relacionPistas[Pistas.MINERVA].Add(new Familia { pareja = Pistas.FOTO_EMPRESARIAL, padre = Pistas.FRANK });

		relacionPistas[Pistas.PERIODICO].Add(new Familia { pareja = Pistas.FRANK, padre = Pistas.MUERTE });
		relacionPistas[Pistas.FRANK].Add(new Familia { pareja = Pistas.PERIODICO, padre = Pistas.MUERTE });

		relacionPistas[Pistas.MUERTE].Add(new Familia { pareja = Pistas.BANCARROTA, padre = Pistas.SUICIDIO });
		relacionPistas[Pistas.BANCARROTA].Add(new Familia { pareja = Pistas.MUERTE, padre = Pistas.SUICIDIO });

		relacionPistas[Pistas.AGUJA].Add(new Familia { pareja = Pistas.VENENO, padre = Pistas.CAUSA_MUERTE });
		relacionPistas[Pistas.VENENO].Add(new Familia { pareja = Pistas.AGUJA, padre = Pistas.CAUSA_MUERTE });

		relacionPistas[Pistas.PINCHAZO].Add(new Familia { pareja = Pistas.CAUSA_MUERTE, padre = Pistas.CUELLO });
		relacionPistas[Pistas.CAUSA_MUERTE].Add(new Familia { pareja = Pistas.PINCHAZO, padre = Pistas.CUELLO });

		relacionPistas[Pistas.CUELLO].Add(new Familia { pareja = Pistas.DORMIDO, padre = Pistas.METODO });
		relacionPistas[Pistas.DORMIDO].Add(new Familia { pareja = Pistas.CUELLO, padre = Pistas.METODO });

		relacionPistas[Pistas.LIBROS].Add(new Familia { pareja = Pistas.METODO, padre = Pistas.CARA });
		relacionPistas[Pistas.METODO].Add(new Familia { pareja = Pistas.LIBROS, padre = Pistas.CARA });

		relacionPistas[Pistas.METODO].Add(new Familia { pareja = Pistas.RADIO, padre = Pistas.GRITO });
		relacionPistas[Pistas.RADIO].Add(new Familia { pareja = Pistas.METODO, padre = Pistas.GRITO });

		relacionPistas[Pistas.CARA].Add(new Familia { pareja = Pistas.GRITO, padre = Pistas.MOMENTO });
		relacionPistas[Pistas.GRITO].Add(new Familia { pareja = Pistas.CARA, padre = Pistas.MOMENTO });

		relacionPistas[Pistas.MOMENTO].Add(new Familia { pareja = Pistas.INFORME, padre = Pistas.COARTADA_MINERVA });
		relacionPistas[Pistas.INFORME].Add(new Familia { pareja = Pistas.MOMENTO, padre = Pistas.COARTADA_MINERVA });

		relacionPistas[Pistas.COARTADA_MINERVA].Add(new Familia { pareja = Pistas.SUICIDIO, padre = Pistas.FINAL });
		relacionPistas[Pistas.SUICIDIO].Add(new Familia { pareja = Pistas.COARTADA_MINERVA, padre = Pistas.FINAL });

		relacionPistas[Pistas.CITA].Add(new Familia { pareja = Pistas.TAYLOR, padre = Pistas.VISITA });
		relacionPistas[Pistas.TAYLOR].Add(new Familia { pareja = Pistas.CITA, padre = Pistas.VISITA });

		relacionPistas[Pistas.TAYLOR].Add(new Familia { pareja = Pistas.DENUNCIA, padre = Pistas.ROBO });
		relacionPistas[Pistas.DENUNCIA].Add(new Familia { pareja = Pistas.TAYLOR, padre = Pistas.ROBO });

		relacionPistas[Pistas.VISITA].Add(new Familia { pareja = Pistas.ROBO, padre = Pistas.METODO_TAYLOR });
		relacionPistas[Pistas.ROBO].Add(new Familia { pareja = Pistas.VISITA, padre = Pistas.METODO_TAYLOR });

		relacionPistas[Pistas.METODO_TAYLOR].Add(new Familia { pareja = Pistas.CARTA, padre = Pistas.FINAL3 });
		relacionPistas[Pistas.CARTA].Add(new Familia { pareja = Pistas.METODO_TAYLOR, padre = Pistas.FINAL3 });

		relacionPistas[Pistas.CENA].Add(new Familia { pareja = Pistas.NULL, padre = Pistas.NULL });

		relacionPistas[Pistas.FINAL].Add(new Familia { pareja = Pistas.NULL, padre = Pistas.NULL });

		relacionPistas[Pistas.FINAL2].Add(new Familia { pareja = Pistas.NULL, padre = Pistas.NULL });

		relacionPistas[Pistas.FINAL3].Add(new Familia { pareja = Pistas.NULL, padre = Pistas.NULL });
	}

	public void CogeAguja() {
		aguja.SetActive(true);
		postItsVisible[(int)Pistas.AGUJA] = true;
		foreach(Familia familia in relacionPistas[Pistas.AGUJA])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeCausaMuerte();
			}
	}

	public void CogeHilo() {
		hilo.SetActive(true);
		postItsVisible[(int)Pistas.HILO] = true;
		foreach (Familia familia in relacionPistas[Pistas.HILO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				if (familia.pareja == Pistas.HILO1)
					CogeHilos();
				else
					CogeMetodo2();
			}
	}

	public void CogeLlaves() {
		llaves.SetActive(true);
		postItsVisible[(int)Pistas.LLAVES] = true;
		foreach (Familia familia in relacionPistas[Pistas.HILO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				if(familia.pareja == Pistas.POMO) 
					CogePuerta();
				else
					CogeHiloUsado();
			}
	}

	public void CogeHueco() {
		hueco.SetActive(true);
		postItsVisible[(int)Pistas.HUECO] = true;
		foreach (Familia familia in relacionPistas[Pistas.HUECO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeHiloUsado();
			}
	}

	public void CogeMark() {
		mark.SetActive(true);
		postItsVisible[(int)Pistas.MARK] = true;
		foreach (Familia familia in relacionPistas[Pistas.MARK])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogePesca();
			}
	}

	public void CogePeriodico() {
		periodico.SetActive(true);
		postItsVisible[(int)Pistas.PERIODICO] = true;
		foreach (Familia familia in relacionPistas[Pistas.PERIODICO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				if (familia.pareja == Pistas.HERMANO)
					CogeMotivoMark();
				else
					CogeMuerte();
			}
	}

	public void CogeVeneno() {
		veneno.SetActive(true);
		postItsVisible[(int)Pistas.VENENO] = true;
		foreach (Familia familia in relacionPistas[Pistas.VENENO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeCausaMuerte();
			}
	}

	public void CogeHilo1() {
		hilo1.SetActive(true);
		postItsVisible[(int)Pistas.HILO1] = true;
		foreach (Familia familia in relacionPistas[Pistas.HILO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeHilos();
			}
	}

	public void CogeCafe() {
		cafe.SetActive(true);
		postItsVisible[(int)Pistas.CAFE] = true;
		foreach (Familia familia in relacionPistas[Pistas.CAFE])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeDormido();
			}
	}

	public void CogeSomnifero() {
		somnifero.SetActive(true);
		postItsVisible[(int)Pistas.SONMIFERO] = true;
		foreach (Familia familia in relacionPistas[Pistas.SONMIFERO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeDormido();
			}
	}

	public void CogeFotoEmpresarial() {
		fotoEmpresarial.SetActive(true);
		postItsVisible[(int)Pistas.FOTO_EMPRESARIAL] = true;
		foreach (Familia familia in relacionPistas[Pistas.FOTO_EMPRESARIAL])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeFrank();
			}
	}

	public void CogeCarta() {
		carta.SetActive(true);
		postItsVisible[(int)Pistas.CARTA] = true;
		foreach (Familia familia in relacionPistas[Pistas.CARTA])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeMetodoTaylor();
			}
	}

	public void CogeInforme() {
		informe.SetActive(true);
		postItsVisible[(int)Pistas.INFORME] = true;
		foreach (Familia familia in relacionPistas[Pistas.INFORME])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeCoartadaMinerva();
			}
	}

	public void CogePinchazo() {
		pinchazo.SetActive(true);
		postItsVisible[(int)Pistas.PINCHAZO] = true;
		foreach (Familia familia in relacionPistas[Pistas.PINCHAZO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeCuello();
			}
	}

	public void CogeTaylor() {
		taylor.SetActive(true);
		postItsVisible[(int)Pistas.TAYLOR] = true;
		foreach (Familia familia in relacionPistas[Pistas.TAYLOR])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				if(familia.pareja == Pistas.CITA) 
					CogeVisita();
				else
					CogeRobo();
			}
	}

	public void CogeMinerva() {
		minerva.SetActive(true);
		postItsVisible[(int)Pistas.MINERVA] = true;
		foreach (Familia familia in relacionPistas[Pistas.MINERVA])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeFrank();
			}
	}

	public void CogeBancarrota() {
		bancarrota.SetActive(true);
		postItsVisible[(int)Pistas.BANCARROTA] = true;
		foreach (Familia familia in relacionPistas[Pistas.BANCARROTA])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeSuicidio();
			}
	}

	public void CogeCita() {
		cita.SetActive(true);
		postItsVisible[(int)Pistas.CITA] = true;
		foreach (Familia familia in relacionPistas[Pistas.CITA])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeVisita();
			}
	}

	public void CogeDenuncia() {
		denuncia.SetActive(true);
		postItsVisible[(int)Pistas.DENUNCIA] = true;
		foreach (Familia familia in relacionPistas[Pistas.DENUNCIA])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeRobo();
			}
	}

	public void CogeLibros() {
		libros.SetActive(true);
		postItsVisible[(int)Pistas.LIBROS] = true;
		foreach (Familia familia in relacionPistas[Pistas.LIBROS])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeCara();
			}
	}

	public void CogePomo() {
		pomo.SetActive(true);
		postItsVisible[(int)Pistas.POMO] = true;
		foreach (Familia familia in relacionPistas[Pistas.POMO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				 CogePuerta();
			}
	}

	public void CogeCausaMuerte() {
		causaMuerte.SetActive(true);
		postItsVisible[(int)Pistas.CAUSA_MUERTE] = true;
		foreach (Familia familia in relacionPistas[Pistas.CAUSA_MUERTE])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeCuello();
			}
	}

	public void CogeDormido() {
		dormido.SetActive(true);
		postItsVisible[(int)Pistas.DORMIDO] = true;
		foreach (Familia familia in relacionPistas[Pistas.DORMIDO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeMetodo();
			}
	}

	public void CogeMetodo() {
		metodo.SetActive(true);
		postItsVisible[(int)Pistas.METODO] = true;
		foreach (Familia familia in relacionPistas[Pistas.METODO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				if(familia.pareja == Pistas.LIBROS) 
					CogeCara();
				else
					CogeGrito();
			}
	}

	public void CogeRadio() {
		radio.SetActive(true);
		postItsVisible[(int)Pistas.RADIO] = true;
		foreach (Familia familia in relacionPistas[Pistas.RADIO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeGrito();
			}
	}

	public void CogeCara() {
		cara.SetActive(true);
		postItsVisible[(int)Pistas.LLAVES] = true;
		foreach (Familia familia in relacionPistas[Pistas.HILO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeMomento();
			}
	}

	public void CogeGrito() {
		grito.SetActive(true);
		postItsVisible[(int)Pistas.LLAVES] = true;
		foreach (Familia familia in relacionPistas[Pistas.HILO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeMomento();
			}
	}

	public void CogeMomento() {
		momento.SetActive(true);
		postItsVisible[(int)Pistas.MOMENTO] = true;
		foreach (Familia familia in relacionPistas[Pistas.MOMENTO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeCoartadaMinerva();
			}
	}

	public void CogeCoartadaMinerva() {
		coartadaMinerva.SetActive(true);
		postItsVisible[(int)Pistas.COARTADA_MINERVA] = true;
		foreach (Familia familia in relacionPistas[Pistas.COARTADA_MINERVA])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeFinal();
			}
	}

	public void CogeFrank() {
		frank.SetActive(true);
		postItsVisible[(int)Pistas.FRANK] = true;
		foreach (Familia familia in relacionPistas[Pistas.FRANK])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeMuerte();
			}
	}

	public void CogeSuicidio() {
		suicidio.SetActive(true);
		postItsVisible[(int)Pistas.SUICIDIO] = true;
		foreach (Familia familia in relacionPistas[Pistas.SUICIDIO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeFinal();
			}
	}

	public void CogeMuerte() {
		muerte.SetActive(true);
		postItsVisible[(int)Pistas.MUERTE] = true;
		foreach (Familia familia in relacionPistas[Pistas.MUERTE])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeSuicidio();
			}
	}

	public void CogeHilos() {
		hilos.SetActive(true);
		postItsVisible[(int)Pistas.HILOS] = true;
	}

	public void CogeMetodo2() {
		metodo2.SetActive(true);
		postItsVisible[(int)Pistas.METODO2] = true;
		foreach (Familia familia in relacionPistas[Pistas.METODO2])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeFinal2();
			}
	}

	public void CogeHiloUsado() {
		hiloUsado.SetActive(true);
		postItsVisible[(int)Pistas.HILO_USADO] = true;
		foreach (Familia familia in relacionPistas[Pistas.HILO_USADO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeLlavesUsadas();
			}
	}

	public void CogeMotivoMark() {
		motivoMark.SetActive(true);
		postItsVisible[(int)Pistas.MOTIVO_MARK] = true;
		foreach (Familia familia in relacionPistas[Pistas.MOTIVO_MARK])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeFinal2();
			}
	}

	public void CogeHermano() {
		hermano.SetActive(true);
		postItsVisible[(int)Pistas.HERMANO] = true;
		foreach (Familia familia in relacionPistas[Pistas.HERMANO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeMotivoMark();
			}
	}

	public void CogePuerta() {
		puerta.SetActive(true);
		postItsVisible[(int)Pistas.PUERTA] = true;
		foreach (Familia familia in relacionPistas[Pistas.PUERTA])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeLlavesUsadas();
			}
	}

	public void CogePesca() {
		pesca.SetActive(true);
		postItsVisible[(int)Pistas.PESCA] = true;
		foreach (Familia familia in relacionPistas[Pistas.PESCA])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeHermano();
			}
	}

	public void CogeWilliam() {
		william.SetActive(true);
		postItsVisible[(int)Pistas.WILLIAM] = true;
		foreach (Familia familia in relacionPistas[Pistas.WILLIAM])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeHermano();
			}
	}

	public void CogeFinal2() {
		final2.SetActive(true);
		postItsVisible[(int)Pistas.FINAL2] = true;
	}

	public void CogeLlavesUsadas() {
		llavesUsadas.SetActive(true);
		postItsVisible[(int)Pistas.LLAVES_USADAS] = true;
		foreach (Familia familia in relacionPistas[Pistas.LLAVES_USADAS])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeMetodo2();
			}
	}

	public void CogeRobo() {
		robo.SetActive(true);
		postItsVisible[(int)Pistas.ROBO] = true;
		foreach (Familia familia in relacionPistas[Pistas.ROBO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeMetodoTaylor();
			}
	}

	public void CogeMetodoTaylor() {
		metodoTaylor.SetActive(true);
		postItsVisible[(int)Pistas.METODO_TAYLOR] = true;
		foreach (Familia familia in relacionPistas[Pistas.METODO_TAYLOR])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeFinal3();
			}
	}

	public void CogeCuello() {
		cuello.SetActive(true);
		postItsVisible[(int)Pistas.CUELLO] = true;
		foreach (Familia familia in relacionPistas[Pistas.CUELLO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeMetodo();
			}
	}

	public void CogeFinal3() {
		final3.SetActive(true);
		postItsVisible[(int)Pistas.FINAL3] = true;
	}

	public void CogeVisita() {
		visita.SetActive(true);
		postItsVisible[(int)Pistas.VISITA] = true;
		foreach (Familia familia in relacionPistas[Pistas.VISITA])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogeMetodoTaylor();
			}
	}

	public void CogeCena() {
		cena.SetActive(true);
		postItsVisible[(int)Pistas.CENA] = true;
	}

	public void CogeFinal() {
		cena.SetActive(true);
		postItsVisible[(int)Pistas.FINAL] = true;
	}

	public void CogeFotoLago() {
		fotoLago.SetActive(true);
		postItsVisible[(int)Pistas.FOTO_LAGO] = true;
		foreach (Familia familia in relacionPistas[Pistas.FOTO_LAGO])
			if (postItsVisible[(int)familia.pareja]) {
				postItsVisible[(int)familia.padre] = true;
				CogePesca();
			}
	}
}
