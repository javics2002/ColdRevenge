using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour,IPointerEnterHandler ,IPointerExitHandler
{

    Vector3 escala;
    public GameObject levelFade;
    public GameObject startButton;
    public GameObject optionButton;
    public GameObject exitButton;
    public GameObject backButton;
    bool canClick = true;

    void Start()
    {
        escala = Vector3.one * 1.08f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = escala;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }


    public void Options()
    {
        levelFade.GetComponent<LevelChanger>().FadeToLevel(1);
        backButton.GetComponent<Button>().enabled = true;
        DesactivaBotones();
    }

    public void Menu()
    {
        levelFade.GetComponent<LevelChanger>().FadeToLevel(0);
        backButton.GetComponent<Button>().enabled= false;
        ActivaBotones();
    }

    public void Level()
    {
        levelFade.GetComponent<LevelChanger>().FadeToLevel(2);
    }

    public void DesactivaBotones()
    {
        startButton.GetComponent<Button>().enabled = false;
        optionButton.GetComponent<Button>().enabled = false;
        exitButton.GetComponent<Button>().enabled = false;

    }

    public void ActivaBotones()
    {
        startButton.GetComponent<Button>().enabled = true;
        optionButton.GetComponent<Button>().enabled = true;
        exitButton.GetComponent<Button>().enabled = true;
    }
}
