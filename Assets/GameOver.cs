using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text roundsText;

    private void OnEnable()
    {
        roundsText.text = PlayersStats.Rounds.ToString();
    }

    public void Menu()
    {
        Debug.Log("Go menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
