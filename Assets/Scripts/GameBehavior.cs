using UnityEngine;
using UnityEngine.UI;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public Text timerText;
    public Text scoreText;
    public Text resultText;

    public float gameDuration = 30f; // hardcoded game duration

    private float timeRemaining;
    private int score = 0;
    private int targetsSpawned;
    private bool gameActive = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        // setup the userterface
        timeRemaining = gameDuration;
        score = 0;
        targetsSpawned = 0;
        resultText.text = "";
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining);
        scoreText.text = "Score: " + score;
    }

    void Update()
    {
        if (!gameActive) return;

        timeRemaining -= Time.deltaTime;
        timerText.text = "Time: " + Mathf.Ceil(timeRemaining);

        if (timeRemaining <= 0)
        {
            EndGame();
        }
    }

    // starts game when start button is activated
    public void StartGame()
    {
        if (!gameActive)
        {
            targetsSpawned = 0; //resets  targets spawned if game is played again
            gameActive = true;
            timeRemaining = gameDuration;
            score = 0;
            resultText.text = "";
            scoreText.text = "Score: " + score;
            timerText.text = "Time: " + Mathf.Ceil(timeRemaining);
        }
    }

    // called by targets when spawned; now counts all targets, even if game isn't active yet
    public void TargetSpawned()
    {
        targetsSpawned += 1;
    }

    // called when a target is hit
    public void TargetHit()
    {
        if (!gameActive) return;
        score++;
        scoreText.text = "Score: " + score;
    }

    void EndGame()
    {
        gameActive = false;
        Debug.Log("Target spawned. Total spawned: " + targetsSpawned);
        Debug.Log("Total hit: " + score);
        if (score > 0 && score == targetsSpawned)
        {
            resultText.text = "YOU WIN!";
        }
        else
        {
            resultText.text = "GAME OVER";
        }

        Debug.Log("Game ended. Score: " + score + " / Targets: " + targetsSpawned);
    }

    public bool IsGameActive()
    {
        return gameActive;
    }
}
