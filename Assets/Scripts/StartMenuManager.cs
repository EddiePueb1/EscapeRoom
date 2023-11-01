using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    //Declare Variables
    public GameObject[] panels;
    public GameObject tutorial;
    public GameObject[] tutorialText;
    public GameObject[] buttons;
    private int tutorialIndex = 0;


    //Load Escape Room Scene
    public void BeginGame()
    {
        SceneManager.LoadScene("EscapeRoom");
    }


    //Increment to the next page of the tutorial
    public void TutorialContinue()
    {
        //Increases tutorial index
        tutorialIndex++;

        //Switches the active tutorial text
        SwitchTuorial();

        //If the last page of tutorial text has been reached swap continue button for start button
        if(tutorialIndex == tutorialText.Length - 1)
        {
            buttons[0].SetActive(false);
            buttons[1].SetActive(true);
        }
    }


    //Deincrement to the previous page of the tutorial
    public void TutorialBack()
    {
        //Decreases tutorial index
        tutorialIndex--;

        //Switches the active tutorial text
        SwitchTuorial();

        //If no on the last page of the tutorial keep the continue button and disable the start button
        if (tutorialIndex < tutorialText.Length - 1)
        {
            buttons[0].SetActive(true);
            buttons[1].SetActive(false);
        }

        //If trying to return from the first page of the tutorial return to the title screen and reset the tutorial index
        if(tutorialIndex < 0)
        {
            ToggleTutorial(false);
            tutorialIndex = 0;
        }
    }


    //Switch between active tutorial text
    private void SwitchTuorial()
    {
        switch (tutorialIndex)
        {
            case 0:
                tutorialText[0].SetActive(true);
                tutorialText[1].SetActive(false);
                break;
            case 1:
                tutorialText[0].SetActive(false);
                tutorialText[1].SetActive(true);
                break;
        }
    }


    //Swap between the title screena dn tutorial screen
    public void ToggleTutorial(bool enabled)
    {
        panels[0].SetActive(!enabled);
        tutorial.SetActive(enabled);
    }


    //Swap between active ui menus
    public void SwitchMenu(int index)
    {
        switch(index)
        {
            case 0: //Title Screen
                panels[0].SetActive(true);
                panels[1].SetActive(false);
                panels[2].SetActive(false);
                break;
            case 1: //Options Screen
                panels[0].SetActive(false);
                panels[1].SetActive(true);
                panels[2].SetActive(false);
                break;
            case 2: //Difficulty Screen
                panels[0].SetActive(false);
                panels[1].SetActive(false);
                panels[2].SetActive(true);
                break;
        }
    }


    //Print the given text when the button is pressed
    public void PrintDifficulty(string diff)
    {
        Debug.Log(diff);
    }

}
