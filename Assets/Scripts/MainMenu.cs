using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void PlayNowButton()
    {
        // Play Now Button has been pressed, here you can initialize your game (For example Load a Scene called GameLevel etc.)
        Loader.Load(Loader.Scene.HomeScene, Loader.Scene.GameScene);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}