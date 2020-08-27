using UnityEngine;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject joystick;

    private bool theEventHasAlreadyCome;

    public void ShowPanel(bool isVictory = false)
    {
        if(theEventHasAlreadyCome)
        {
            return;
        }

        if(isVictory)
        {
            winPanel.SetActive(true);
        }
        else
        {
            losePanel.SetActive(true);
        }

        DisablePlayerMovement();
        theEventHasAlreadyCome = true;
        joystick.SetActive(false);
    }

    private void CloseGUI()
    {
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        if (player != null)
        {
            Destroy(player.gameObject);
        }

        joystick.SetActive(true);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        theEventHasAlreadyCome = false;
    }

    private void DisablePlayerMovement()
    {
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        player.enabled = false;
    }

    public void RestartLevel()
    {
        CloseGUI();
        GameSettings settings = FindObjectOfType<GameSettings>();
        settings.StartLevel(true);
    }

    public void LoadNextLevel()
    {
        CloseGUI();
        GameSettings settings = FindObjectOfType<GameSettings>();
        settings.StartLevel();
    }
}
