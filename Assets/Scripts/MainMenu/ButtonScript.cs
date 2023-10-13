using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    //Let's break this down Real Quick
    
    //SerializeField for a certain scene, can be called whatever as long as the string matches an existing scene
    //If the scene exists but Unity is shittin' bricks, please add the scene in build settings
    
    [SerializeField] private string mainMenu = "Main Menu";
    
    //Create a new void method that vaguely describes the button it should be attached to
    public void NewMenuButtons()
    {
        //Invoke Scene Manager and load the scene that you made earlier. 
        SceneManager.LoadScene(mainMenu);
        //Done and repeat for however many scenes you have.
    }
    
    [SerializeField] private string mainGame = "Board Scene";
    
    public void NewGameButton()
    {
        SceneManager.LoadScene(mainGame);

    }
    
    [SerializeField] private string gameInstructions = "Game Instructions";
    
    public void NewInstructionsButton()
    {
        SceneManager.LoadScene(gameInstructions);

    }
    
    [SerializeField] private string gameCredits = "Game Credits";
    
    public void NewCreditsButton()
    {
        SceneManager.LoadScene(gameCredits);

    }
    
    public void QuitGameButton()
    {
        Application.Quit();

    }
    
}
