using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{

    public enum Scene {
        GameScene,
        HomeScene
    }

    public static void  Load(Scene previousScene, Scene scene){
        SceneManager.LoadScene(scene.ToString());
    }
}
