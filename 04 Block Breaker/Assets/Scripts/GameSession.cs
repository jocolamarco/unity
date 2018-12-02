using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour {

    //parameters
    [Range(0.5f, 3f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 4;
    [SerializeField] int currentPlayerScore = 0;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] bool isAutoPlayEnabled;
    [SerializeField] bool lastLevel = false;

    //cached references

    private void Awake()
    {
        CheckGameSession();
    }

    private void CheckGameSession()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            resetGame();
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        textMesh.text = currentPlayerScore.ToString();
        //gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
        Time.timeScale = gameSpeed;
    }

    public void updateCurrentUserScore()
    {
        currentPlayerScore += pointsPerBlockDestroyed;
        textMesh.text = currentPlayerScore.ToString();
    }

    public void resetGame()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public bool IsLastLevel()
    {
        return lastLevel;
    }
}
