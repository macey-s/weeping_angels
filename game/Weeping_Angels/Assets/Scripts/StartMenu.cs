using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject startUI;
    public GameObject timerUI;
    public GameTimer timer;
    public PlayerMovements playerMovement;

    public void StartGame()
    {
        startUI.SetActive(false);
        timerUI.SetActive(true);

        playerMovement.enabled = true;
        timer.StartTimer();
    }
}
