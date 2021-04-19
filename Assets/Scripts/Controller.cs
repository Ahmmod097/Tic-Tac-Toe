using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controller : MonoBehaviour {

    public int whoTurn; //0 == x and 1 == 0
    public int turnCount; //counts the number of turn played
    public GameObject[] turnIcons; //displays whose turn it is
    public Sprite[] playIcons; //0 == x icon and 1 == O icon
    public Button[] tictactoeSpace; //playable space for our game
    public int[] markedSpaces; //which player pressed which button 
    public Text winnerText;
    public GameObject[] winningLine;
   /// public GameObject winningPanel;
    public GameObject playerXWin;
    public GameObject playerOWin;
    public int xPlayerScore;
    public int oPlayerScore;
    public Text xPlayerText;
    public Text oPlayerText;
    public Button xPlayerButton;
    public Button oPlayerButton;
    //public Text drawText;
    public AudioSource buttonClick;

    public GameObject drawText;

	// Use this for initialization
	void Start () {
        GameSetup();
	}
    void GameSetup()
    {
        whoTurn = 0;
        turnCount = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for (int i = 0; i < tictactoeSpace.Length; i++)
        {
            tictactoeSpace[i].interactable = true;
            tictactoeSpace[i].GetComponent<Image>().sprite = null;

        }
        for (int i = 0; i < markedSpaces.Length; i++)
        {
            markedSpaces[i] = -100;
        }
    }

    // Update is called once per frame
    void Update()
    {
		
	}

    public void TicTacToeButton(int whichNumber)
    {
        xPlayerButton.interactable = false;
        oPlayerButton.interactable = false;
        tictactoeSpace[whichNumber].image.sprite = playIcons[whoTurn];
        tictactoeSpace[whichNumber].interactable = false; //so that he cant press one button twice in a row
        markedSpaces[whichNumber] = whoTurn +1 ;
        turnCount++;
        if (turnCount > 4)
        {
            bool isWinner = winnerCheck();
            if (turnCount == 9 && isWinner == false)
            {
               CAT();
           }
        }

        if (whoTurn == 0)
        {
            whoTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
        else
        {
            whoTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }

    }
    bool winnerCheck()
    {
        int s1 = markedSpaces[0] + markedSpaces[1] + markedSpaces[2];
        int s2 = markedSpaces[3] + markedSpaces[4] + markedSpaces[5];
        int s3 = markedSpaces[6] + markedSpaces[7] + markedSpaces[8];
        int s4 = markedSpaces[0] + markedSpaces[3] + markedSpaces[6];
        int s5 = markedSpaces[1] + markedSpaces[4] + markedSpaces[7];
        int s6 = markedSpaces[2] + markedSpaces[5] + markedSpaces[8];
        int s7 = markedSpaces[0] + markedSpaces[4] + markedSpaces[8];
        int s8 = markedSpaces[2] + markedSpaces[4] + markedSpaces[6];
        var solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };
        for (int i = 0; i < solutions.Length; i++)
        {
            if (solutions[i] == 3 * (whoTurn + 1))
            {
                winnerDisplay(i);
                return true ;
            }
        }
        return false;
    }

    void winnerDisplay(int index)
    {
        ///winningPanel.gameObject.SetActive(true);
        if (whoTurn == 0)
        {
            xPlayerScore++;
            xPlayerText.text = xPlayerScore.ToString();
            //winnerText.text = "Player X Wins!";
            playerXWin.SetActive(true);
            
        }
        else
        {
            oPlayerScore++;
            oPlayerText.text = oPlayerScore.ToString();
            //winnerText.text = "Player O Wins!";
            playerOWin.SetActive(true);
            
        }
        winningLine[index].SetActive(true);
        for (int i = 0; i < tictactoeSpace.Length; i++)
        {
            tictactoeSpace[i].interactable = false;
        }
       
    }

    public void Rematch()
    {
       
        GameSetup();
        for (int i = 0; i < winningLine.Length; i++)
        {
            winningLine[i].SetActive(false);

        }
        ///winningPanel.SetActive(false);
        xPlayerButton.interactable = true;
        oPlayerButton.interactable = true;
        playerXWin.SetActive(false);
        playerOWin.SetActive(false);
        drawText.SetActive(false);
    }
   
    public void Restart()
    {
        Rematch();
        xPlayerScore = 0;
        oPlayerScore = 0;
        xPlayerText.text = "0";
        oPlayerText.text = "0";
    }

    public void SwitchPlayer(int whichPlayer)
    {
        if (whichPlayer == 0)
        {
            whoTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
        }
        else if (whichPlayer == 1)
        {
            whoTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
        }
    }

    void CAT()
    {
        ///winningPanel.SetActive(true);
        drawText.SetActive(true);
        
    }
    public void clickAudio()
    {
        buttonClick.Play();
    }

}
