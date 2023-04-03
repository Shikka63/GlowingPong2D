using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public int playerScoreL;
    public int playerScoreR;
    public int maxScore = 2;
    public bool isPaused;
    public bool isFinish;

    public GameObject panelScore;
    public GameObject panelFinish;
    public GameObject panelControl;

    public TextMeshProUGUI txtPlayerScoreL;
    public TextMeshProUGUI txtPlayerScoreR;
    //public TMP_Text txtPlayerWin;
    public TextMeshProUGUI txtPlayerWin;
    public TextMeshProUGUI txtFinalScore;

    public static ScoreSystem instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);    
        }
    }

    private void Start()
    {
        isPaused = false;
        isFinish = false;
        playerScoreL = 0;
        playerScoreR = 0;
        
        //isi nilai integer PlayerScore ke dalam UI
        panelFinish.SetActive(false);
        panelScore.SetActive(true);
        isPaused = false;
        Pause();

        txtPlayerWin.GetComponent<TextMeshPro>();

        txtPlayerScoreL.text = playerScoreL.ToString();
        txtPlayerScoreR.text = playerScoreR.ToString();
        txtFinalScore.SetText(playerScoreL.ToString() + " : " + playerScoreR.ToString());
        panelControl.SetActive(true);
        Invoke("ControlPanelOut", 2);
        //Invoke(panelControl.SetActive(false), 2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && isFinish == false)
        {
            isPaused = !isPaused;
            Pause();
            if (isPaused)
            {
                Paused("Game Paused!");
            }
            else
            {
                Resume();
            }
        }
    }

    public void Score(string gawangID)
    {
        if (gawangID == "Kiri")
        {
            playerScoreR = playerScoreR + 1;
            txtPlayerScoreR.text = playerScoreR.ToString();
            ScoreCheck();
        } 
        else
        {
            playerScoreL = playerScoreL + 1;
            txtPlayerScoreL.text = playerScoreL.ToString();
            ScoreCheck();
        }
    }

    public void ScoreCheck()
    {
        if (playerScoreL == maxScore)
        {
            //debug.log("player l win");
            //this.gameObject.SendMessage("ChangeScene", "MainMenu");
            //txtPlayerWin.SetText("PLAYER L WIN");
            //panelFinish.SetActive(true);
            //panelScore.SetActive(false);
            //Debug.Log("Player L WIN");
            //this.gameObject.SendMessage("Finish", "PLAYER L WIN");
            txtPlayerWin.color = new Color32(255, 105, 105, 255);
            Finish("PLAYER L WIN");
        }
        else if (playerScoreR == maxScore)
        {
            //Debug.Log("Player R WIN");
            //this.gameObject.SendMessage("ChangeScene", "MainMenu");
            //this.gameObject.SendMessage("Finish", "PLAYER R WIN");
            txtPlayerWin.color = new Color32(80, 163, 255, 255);
            Finish("PLAYER R WIN");
            //txtPlayerWin.SetText("PLAYER R WIN");
            //panelFinish.SetActive(true);
            //panelScore.SetActive(false);
        }
    }

    public void Finish(string a)
    {
        txtPlayerWin.SetText(a);
        txtFinalScore.SetText(playerScoreL.ToString() + " : " + playerScoreR.ToString());
        panelFinish.SetActive(true);
        panelScore.SetActive(false);
        isFinish = true;
        isPaused = true;
        Pause();
        //isPaused = true;
    }

    public void Paused(string a)
    {
        txtPlayerWin.SetText(a);
        txtFinalScore.SetText(playerScoreL.ToString() + " : " + playerScoreR.ToString());
        panelFinish.SetActive(true);
        panelScore.SetActive(false);
        panelControl.SetActive(false);
        //Pause(0);
        //isPaused = true;
    }

    public void Resume()
    {
        panelFinish.SetActive(false);
        panelScore.SetActive(true);
        //Pause(1);
        //isPaused = false;
    }

    public void Pause()
    {
        //Time.timeScale = x;

        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ControlPanelOut()
    {
        panelControl.SetActive(false);
    }
}
