using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] GameObject[] mainMenuUI;
    [SerializeField] GameObject storyScreenUI;

    public void PlayButton()
    {
        mainMenuUI[0].SetActive(false);
        mainMenuUI[1].SetActive(false);
        storyScreenUI.SetActive(true);
    }
}
