using System;
using System.Threading.Tasks;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private Content[] screens;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject bluredBackground;

    private int currentScreen = 0;
    
    private async void Start()
    {
        for (int i = 0; i < screens.Length; ++i)
        {
            var screen = screens[i];

            currentScreen = i;
            screen.NextButton.onClick.AddListener(() => ShowScreen(currentScreen + 1));
            screen.BackButton.onClick.AddListener(() => ShowScreen(currentScreen - 1));
            screen.HomeButton.onClick.AddListener(ShowHomeScreen);
        }
        
        await Task.Delay(TimeSpan.FromSeconds(1f));
        
        loadingScreen.SetActive(false);
        menuScreen.SetActive(true);
    }

    public void ShowScreen(int screenNumber)
    {
        if (screenNumber < 0 || screenNumber >= screens.Length)
        {
            ShowHomeScreen();
            return;
        }
        menuScreen.SetActive(false);
        background.SetActive(false);
        bluredBackground.SetActive(true);
        
        screens[currentScreen].gameObject.SetActive(false);
        currentScreen = screenNumber;
        screens[currentScreen].gameObject.SetActive(true);
    }

    public void ShowHomeScreen()
    {
        screens[currentScreen].gameObject.SetActive(false);
        currentScreen = 0;
        bluredBackground.SetActive(false);
        background.SetActive(true);
        menuScreen.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
