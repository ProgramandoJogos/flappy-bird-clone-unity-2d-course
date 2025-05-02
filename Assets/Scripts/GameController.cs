using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public GameObject GameplayPanel;
    public GameObject GameOverPanel;

    private PlayerController PlayerController;
    private PipeController PipeController;

    private int Score = 0;

    private void Start()
    {
        ScoreText.text = Score.ToString();
        PlayerController = FindFirstObjectByType<PlayerController>();
        PipeController = FindFirstObjectByType<PipeController>();
    }

    public void OnPlayerDie()
    {
        int record = PlayerPrefs.GetInt("Record", 0);

        if(Score > record)
        {
            PlayerPrefs.SetInt("Record", Score);
        }

        GameplayPanel.SetActive(false);
        GameOverPanel.SetActive(true);
        PipeController.enabled = false;
        PlayerController.enabled = false;
    }

    public int GetScore()
    {
        return Score;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void OnPlayerScore()
    {
        Score += 1;
        ScoreText.text = Score.ToString();
    }
}
