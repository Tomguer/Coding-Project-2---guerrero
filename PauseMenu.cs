// PauseMenu.cs: on the Canvas. Esc or P pauses the game and shows the Pause Panel.
// Press it again to go on. Week 8, Pause.
// It stops the player through GameManager.Instance, so there's no GameManager to drag in.
// In a web browser, Esc lets go of the mouse first and may never reach the game. So P works too.

using UnityEngine;                    // Unity's tools: MonoBehaviour, Time and the rest.
using UnityEngine.InputSystem;        // Keyboard, for reading keys, lives here.

// The class name must match the file name. MonoBehaviour makes it a component.
public class PauseMenu : MonoBehaviour
{   // Start of the PauseMenu class.
    [SerializeField] GameObject pausePanel;   // Drag the Pause Panel in here. Start it off.
    bool paused;                              // Is the game paused right now? It starts false.

    // Unity runs Update every frame. It still runs when timeScale is 0.
    void Update()
    {   // Start of Update.
        // No keyboard? Stop here.
        if (Keyboard.current == null) return;
        // Was Esc pressed this frame?
        bool esc = Keyboard.current.escapeKey.wasPressedThisFrame;
        // Was P pressed this frame?
        bool p = Keyboard.current.pKey.wasPressedThisFrame;
        // Either one? || means or.
        if (esc || p)
        {   // Start of the key check.
            // Paused? Then go on. Not paused? Then pause.
            if (paused) Resume();
            else Pause();
        }   // End of the key check.
    }   // End of Update.

    // Stops the game and shows the panel.
    public void Pause()
    {   // Start of Pause.
        // Only while you're playing. Not on the win or lose panel.
        if (GameManager.Instance.state != GameManager.State.Playing) return;
        // Remember it's paused.
        paused = true;
        // Time stops: walking, physics, the Animator, anything that uses Time.deltaTime.
        Time.timeScale = 0f;
        // timeScale doesn't stop sound. This does.
        AudioListener.pause = true;
        // Show the panel.
        pausePanel.SetActive(true);
        // timeScale doesn't stop the mouse look either. Stop the player and free the mouse.
        GameManager.Instance.StopPlayer();
    }   // End of Pause.

    // The Resume button calls this. Public, so it shows in the button's On Click list.
    public void Resume()
    {   // Start of Resume.
        // Not paused anymore.
        paused = false;
        // Time runs again.
        Time.timeScale = 1f;
        // Sound plays again.
        AudioListener.pause = false;
        // Hide the panel.
        pausePanel.SetActive(false);
        // Give the player back and lock the mouse.
        GameManager.Instance.ResumePlayer();
    }   // End of Resume.

    // The Quit button calls this.
    public void Quit()
    {   // Start of Quit.
        // Normal speed and sound again, or the title starts frozen and silent.
        Time.timeScale = 1f;
        // Sound plays again.
        AudioListener.pause = false;
        // Back to the title. Application.Quit does nothing in the Editor,
        // and in a browser it only stops the game.
        GameManager.Instance.ToTitle();
    }   // End of Quit.
}   // End of the PauseMenu class.
