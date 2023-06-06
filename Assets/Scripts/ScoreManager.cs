using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Player _player;

    public GameObject ControlPanel;
    public GameObject MenulPanel;
    public GameObject GameOverPanel;
    public Text ScoreText;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    public void GameOver()
    {
        Time.timeScale = 0f;

        ControlPanel.SetActive(false);
        MenulPanel.SetActive(false);
        GameOverPanel.SetActive(true);

        ScoreText.text = "Убито врагов: " + _player.CountEnemy.ToString();
    }
}
