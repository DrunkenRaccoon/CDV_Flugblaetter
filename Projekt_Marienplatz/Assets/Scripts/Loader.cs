using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public static class Loader {

    public enum Scene {
        SampleScene,
        Loading,
    }

    private static Action onLoaderCallback;

    public static void Load(Scene scene) {
        onLoaderCallback = () => {
        SceneManager.LoadScene(scene.ToString());
        };

        SceneManager.LoadScene(Scene.Loading.ToString());
    }

    public static void LoaderCallback() {
        if (onLoaderCallback != null) { 
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
