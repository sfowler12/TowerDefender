using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;
    private void OnEnable()
    {
        roundsText.text = PlayerStats.Rounds.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   //Restart Level
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        FindObjectOfType<AudioManager>().Stop();
        SceneManager.LoadScene(0);
    }
}
