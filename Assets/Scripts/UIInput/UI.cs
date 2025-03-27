using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField]
    Text scoreValue;

    [SerializeField]
    Image blockIcon;

    [SerializeField]
    string playerName;

    void Awake()
    {
        GameManager.Instance.OnScore += UpdateScore;
        GameManager.Instance.OnFigure += UpdateFigure;
    }

    void OnDestroy()
    {
        GameManager.Instance.OnScore -= UpdateScore;
        GameManager.Instance.OnFigure -= UpdateFigure;
    }

    void UpdateScore(string playerName, int score)
    {
        if(this.playerName == playerName)
            scoreValue.text = score.ToString();
    }

    void UpdateFigure(string playerName, Sprite sprite)
    {
        if (this.playerName == playerName)
            blockIcon.sprite = sprite;
    }
}
