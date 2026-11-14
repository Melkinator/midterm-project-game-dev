using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [Header("Death Settings")]
    [SerializeField] private string gameOverSceneName = "GameOver";
    [SerializeField] private string hazardTag = "Hazard";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(hazardTag))
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(hazardTag))
        {
            Die();
        }
    }

    private void Die()
    {
        Time.timeScale = 1f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        SceneManager.LoadScene(gameOverSceneName);
    }
}