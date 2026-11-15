using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("Timer UI")]
    [SerializeField] private TMP_Text timerText;

    [Header("Win Screen UI")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TMP_Text finalTimeText;

    private float elapsedTime = 0f;

    private bool timerStarted = false;
    private bool gameFinished = false;

    void Start()
    {
        // Hide win screen at the beginning
        winPanel.SetActive(false);

        // Display initial timer
        timerText.text = "Time: 00:00.00";
    }

    void Update()
    {
        // Only count time after touching Start
        if (timerStarted && !gameFinished)
        {
            elapsedTime += Time.deltaTime;

            timerText.text = "Time: " + FormatTime(elapsedTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Start the timer
        if (other.CompareTag("Start") && !timerStarted)
        {
            timerStarted = true;

            Debug.Log("Timer Started!");
        }

        // Finish the level
        if (other.CompareTag("Finish") && timerStarted && !gameFinished)
        {
            FinishGame();
        }
    }

    private void FinishGame()
    {
        gameFinished = true;
        timerStarted = false;

        // Display final time
        string finalTime = FormatTime(elapsedTime);

        finalTimeText.text = "Your Time: " + finalTime;

        // Show win screen
        winPanel.SetActive(true);

        // Unlock cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0f;

        Debug.Log("You Win! Final Time: " + finalTime);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        int milliseconds = Mathf.FloorToInt((time * 1000f) % 1000f);

        return string.Format(
            "{0:00}:{1:00}.{2:000}",
            minutes,
            seconds,
            milliseconds
        );
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        Debug.Log("Game Quit");
    }
}
