using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoSingleton<UIController>
{
    public GameObject panelScore;
    public GameObject gameArea;
    public GameObject pausePanel;
    public GameObject panelMenu;
    public GameObject bordersMenu;
    public GameObject gameBorders;
    public Button pauseButton;
    public Button continueButton;
    public Button endGameButton;
    public Button startGameButton;
    public Button yesButton;
    public Button noButton;

    protected override void Awake()
    {
        base.Awake();

        // Призначаємо методи на кнопки
        pauseButton.onClick.AddListener(OnPauseButtonClicked);
        continueButton.onClick.AddListener(OnContinueButtonClicked);
        endGameButton.onClick.AddListener(OnEndGameButtonClicked);
        startGameButton.onClick.AddListener(OnStartGameButtonClicked);
        yesButton.onClick.AddListener(OnYesButtonClicked);
        noButton.onClick.AddListener(OnNoButtonClicked);
    }

    public bool IsGameAreaActive()
    {
        return gameArea.activeSelf;
    }

    public bool IsPausePanelActive()
    {
        return pausePanel.activeSelf;
    }

    public void ShowPausePanel()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HidePausePanel()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ShowScorePanel()
    {
        panelScore.SetActive(true);
    }

    public void HideScorePanel()
    {
        panelScore.SetActive(false);
    }

    private void OnPauseButtonClicked()
    {
        ShowPausePanel();
    }

    private void OnContinueButtonClicked()
    {
        HidePausePanel();
    }

    private void OnEndGameButtonClicked()
    {
        PlayerSpawner.Instance.ResetGame();
        HidePausePanel();
        HideScorePanel();
        ShowMainMenu();
        gameArea.SetActive(false);
    }

    private void OnStartGameButtonClicked()
    {
        GameStart();
    }

    private void OnYesButtonClicked()
    {
        ShowScorePanel();
        gameArea.SetActive(true);
        bordersMenu.SetActive(false);
        gameBorders.SetActive(true);
        PlayerSpawner.Instance.SpawnStartCube();
        pauseButton.gameObject.SetActive(true);
        ScoreCounter.Instance.ResetScores();
    }

    private void OnNoButtonClicked()
    {
        ShowScorePanel();
        gameArea.SetActive(true);
        bordersMenu.SetActive(false);
        gameBorders.SetActive(false);
        PlayerSpawner.Instance.SpawnStartCube();
        pauseButton.gameObject.SetActive(true);
        ScoreCounter.Instance.ResetScores();
    }

    public void GameStart()
    {
        panelMenu.SetActive(false);
        bordersMenu.SetActive(true);
        //ShowScorePanel();
        //gameArea.SetActive(true);
    }

    public void ShowMainMenu()
    {
        panelMenu.SetActive(true);
        bordersMenu.SetActive(false);
        gameBorders.SetActive(false);
    }
}
