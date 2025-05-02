using TMPro;
using UnityEngine;

public class GameOverPanelController : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI RecordText;
    private GameController GameController;

    private void Start()
    {
        GameController = FindFirstObjectByType<GameController>();
        ScoreText.SetText(GameController.GetScore().ToString());

        int record = PlayerPrefs.GetInt("Record", 0);
        RecordText.SetText(record.ToString());
    }

    public void Restart()
    {
        GameController.RestartGame();
    }

    public void MainMenu()
    {
        GameController.MainMenu();
    }

}
