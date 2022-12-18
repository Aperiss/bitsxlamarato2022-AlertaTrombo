using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public StartMenuBehaviour startMenu;
    public GameObject winMenu;
    public GameObject looseMenu;

    public WinProgressBar winTracker;
    public ProgressBar looseTracker;
    public TypingManager typingTracker;
    public ClotManager clots;

    public int gameState = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        startMenu.gameObject.SetActive(true);
        winTracker.enabled = false;
        looseTracker.enabled = false;
        typingTracker.enabled = false;
        clots.enabled = false;
        winMenu.SetActive(false);
        looseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (gameState)
        {
            case 0:
                //Start Menu
                startMenu.gameObject.SetActive(true);
                winTracker.enabled = false;
                looseTracker.enabled = false;
                typingTracker.enabled = false;
                winMenu.SetActive(false);
                looseMenu.SetActive(false);
                clots.enabled = false;
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    gameState = 1;
                }
                return;
            case 1:
                //GettingReadyToType
                startMenu.gameObject.SetActive(false);
                typingTracker.enabled = true;
                winTracker.enabled = false;
                looseTracker.enabled = false;
                clots.enabled = true;
                winMenu.SetActive(false);
                looseMenu.SetActive(false);
                if (typingTracker.startProgress)
                {
                    gameState = 2;
                }
                return;
            case 2:
                //Main Gameplay Loop
                startMenu.gameObject.SetActive(false);
                typingTracker.enabled = true;
                winTracker.enabled = true;
                looseTracker.enabled = true;
                clots.enabled = true;
                winMenu.SetActive(false);
                looseMenu.SetActive(false);
                if (winTracker.progress >= 1.0f)
                {
                    gameState = 3;
                    return;
                }
                if (looseTracker.progress >= 1.0f)
                {
                    gameState = 4;
                    return;
                }
                return;
            case 3:
                //Win Screen
                startMenu.gameObject.SetActive(false);
                typingTracker.enabled = false;
                winTracker.enabled = false;
                looseTracker.enabled = false;
                clots.enabled = false;
                winMenu.SetActive(true);
                looseMenu.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    gameState = 0;
                }
                return;
            case 4:
                //Loose Screen
                startMenu.gameObject.SetActive(false);
                typingTracker.enabled = false;
                winTracker.enabled = false;
                looseTracker.enabled = false;
                clots.enabled = false;
                winMenu.SetActive(false);
                looseMenu.SetActive(true);
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    gameState = 0;
                }
                return;
            default:
                return;
        }
    }
}
