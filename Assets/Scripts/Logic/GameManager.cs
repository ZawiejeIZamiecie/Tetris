using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] figures;

    public Action<string, Vector2> OnInput;

    public Action<string, int> OnScore;

    public Action<string, Sprite> OnFigure;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
    }

    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(1));
    }

    public GameObject GetNextFigure()
    {
        return figures[UnityEngine.Random.Range(0, figures.Length)];
    }
}
