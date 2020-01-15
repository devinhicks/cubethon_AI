using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    public void ComepleteLevel ()
    {
        completeLevelUI.SetActive(true);
    }

    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", restartDelay); // Restart after specfied delay
        }
    }

    void Restart ()
    {
        // if player does not end game, restart the current scene/level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
