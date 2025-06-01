using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("Scripts/Managers/GameManager")]
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CursorVisiblity(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            CloseGame();
    }

    //----------------------------------------------------------------------------------------------------------------------
    // Cursor

    /// <summary>
    /// Call to hide or show the cursor
    /// </summary>
    public void CursorVisiblity(bool visibleState)
    {
        if (visibleState)
        {
            Time.timeScale = 0;
            ShowCursor();
        }
        else
        {
            Time.timeScale = 1;
            HideCursor();
        }
    }

    /// <summary>
    /// Hides and locks the cursor
    /// </summary>
    private void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    /// <summary>
    /// Shows and frees the cursor
    /// </summary>
    private void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }


    //----------------------------------------------------------------------------------------------------------------------
    // Player lost

    public void ResetArea()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //----------------------------------------------------------------------------------------------------------------------
    // Quit Game

    public void CloseGame()
    {
        QuitGame();
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
