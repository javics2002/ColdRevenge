using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator_;
    private int levelToLoad;
    public GameObject option;
    public GameObject menu;

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator_.SetTrigger("FadeOut");
        
    }

    public void OnFadeComplete()
    {
        if (levelToLoad >1)
            SceneManager.LoadScene(levelToLoad);
        else
        {
            if (levelToLoad == 0)
            {
                option.SetActive(false);
                menu.SetActive(true);

            }
            else if (levelToLoad == 1)
            {
                option.SetActive(true);
                menu.SetActive(false);
            }
        }
    }
}
