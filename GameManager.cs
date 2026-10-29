using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Windows;
using System.Collections;
public class GameManager : MonoBehaviour


{
    public static GameManager Instance;   
    public enum State { Playing, Won, Lost }
    public State state = State.Playing;
    [SerializeField] StarterAssetsInputs input;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] int lives = 3;

    [SerializeField] int coinsToWin = 3;
    [SerializeField] TMP_Text livesText;
    [SerializeField] GameObject endPanel;
    [SerializeField] TMP_Text endText;
    [SerializeField] string titleScene = "Title";
    int coins;
  
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        ShowLives();
    }
    public void AddCoin()
    {
        coins++;
        Debug.Log("Coins:" + coins);
        if (coins >= coinsToWin) state = State.Won;
    }
    public void LoseLife()
    {
        if (state != State.Playing) return;
        lives--;
        ShowLives();
        if (lives <= 0) Lose();
    }
    void Win()
    {
        state = State.Won;
        ShowEnd("You win");
    }
    void Lose()
    {
        state = State.Lost;
        ShowEnd("You lose");
    }

        void ShowLives()
    {
        if (livesText != null) livesText.text = "Lives: " + lives;
    }
    void ShowEnd(string message)
    {
        if (endPanel == null) return;
        endPanel.SetActive(true);
        if (endText != null) endText.text = message;
        StopPlayer();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ToTitle()
    {
        SceneManager.LoadScene(titleScene);
    }
    void StopPlayer()
    {
        if (playerInput != null) playerInput.enabled = false;
        if (input != null)
        {
            input.move = Vector2.zero;
            input.look = Vector2.zero;
            input.cursorLocked = false;
        }
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
    }

    }