using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text score;
    public Slider slider;

    public void SetScoreText(int score)
    {
        this.score.text = "Score: " + score;
    }
    public void SetHPSlider(int hp)
    {
        slider.value = hp;
    }
}
