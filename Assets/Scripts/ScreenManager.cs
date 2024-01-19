using System;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private GameObject menuScreen;
    [SerializeField] private Transform screensParent;
    [SerializeField] private ContentScreen screenPrefab;
    [SerializeField] private ContentData[] contentDatas;
    [SerializeField] private GameObject background;
    [SerializeField] private GameObject bluredBackground;

    private ContentScreen[] _screens;
    private int _currentScreen = 0;
    
    private async void Start()
    {
        InstantiateScreens();
        
        for (int i = 0; i < _screens.Length; ++i)
        {
            var screen = _screens[i];

            _currentScreen = i;
            screen.NextButton.onClick.AddListener(() => ShowScreen(_currentScreen + 1));
            screen.BackButton.onClick.AddListener(() => ShowScreen(_currentScreen - 1));
            screen.HomeButton.onClick.AddListener(ShowHomeScreen);
        }

        await Task.Delay(TimeSpan.FromSeconds(1f));

        loadingScreen.SetActive(false);
        menuScreen.SetActive(true);
    }

    public void ShowScreen(int screenNumber)
    {
        if (screenNumber < 0 || screenNumber >= _screens.Length)
        {
            ShowHomeScreen();
            return;
        }
        menuScreen.SetActive(false);
        background.SetActive(false);
        bluredBackground.SetActive(true);
        
        _screens[_currentScreen].gameObject.SetActive(false);
        _currentScreen = screenNumber;
        _screens[_currentScreen].gameObject.SetActive(true);
    }

    public void ShowHomeScreen()
    {
        _screens[_currentScreen].gameObject.SetActive(false);
        _currentScreen = 0;
        bluredBackground.SetActive(false);
        background.SetActive(true);
        menuScreen.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    private void InstantiateScreens()
    {
        _screens = new ContentScreen[contentDatas.Length];

        for (int i = 0; i < contentDatas.Length; ++i)
        {
            var contentData = contentDatas[i];

            _screens[i] = Instantiate(screenPrefab, screensParent);
            _screens[i].gameObject.SetActive(false);
            
            _screens[i].Name.text = contentData.Name;
            _screens[i].Image.sprite = contentData.Image;
            // _screens[i].Image.SetNativeSize();
            _screens[i].Text.text = contentData.Text;
        }

        var lastFooter = _screens[_screens.Length - 1].NextButton.GetComponentInChildren<TMP_Text>();
        lastFooter.text = "To Menu";
    }
}
