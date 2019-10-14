using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    private UIManager uIManager;
    public string sceneToLoad;
    private void Awake()
    {
        uIManager = FindObjectOfType<UIManager>();
    }
    public void AddScore()
    {
        score += 10;
        uIManager.SetScoreText(score);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
