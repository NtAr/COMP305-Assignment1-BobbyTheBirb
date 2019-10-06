using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    //public GameController gameController;
    public Text startLabel;
    public Button startButton;
    //public Button restartButton;
    //public Text endLabel;

    // Start is called before the first frame update
    void Start()
    {
        //switch (SceneManager.GetActiveScene().name)
        //{
        //    case "start":
        //        gameController.defaultSoundClip = SoundClip.NONE;
        //        gameController.livesLabel.enabled = false;
        //        gameController.scoreLabel.enabled = false;
        //        restartButton.enabled = false;
        //        endLabel.enabled = false;
        //        Debug.Log("Start Scene loaded!");
        //        break;
        //    case "main":
        //        gameController.defaultSoundClip = SoundClip.ENGINE;

        //        gameController.livesLabel.enabled = true;
        //        gameController.scoreLabel.enabled = true;
        //        startLabel.enabled = false;
        //        startButton.enabled = false;
        //        restartButton.enabled = false;
        //        endLabel.enabled = false;
        //        Debug.Log("Main Scene loaded!");
        //        break;
        //    case "end":
        //        gameController.defaultSoundClip = SoundClip.NONE;
        //        gameController.livesLabel.enabled = false;
        //        gameController.scoreLabel.enabled = false;
        //        startLabel.enabled = false;
        //        startButton.enabled = false;
        //        restartButton.enabled = true;
        //        endLabel.enabled = true;
        //        Debug.Log("End Scene loaded!");
        //        break;

        //}
    }

    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("main");
    }

    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("main");
    }
}
