using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Oculus.Interaction.Samples;
using System;
public class Fadeout : MonoBehaviour
{
    [SerializeField]
    SceneLoader loader;
    [SerializeField]
    CanvasFadeout canvasFadeout;
    // Start is called before the first frame update
    void Start()
    {
        loader.WhenLoadingScene += Fade;
    }

    void Fade(String name) {
        canvasFadeout.fadeCanvasPub();
        StartCoroutine(waitForFadeout(name));
    }

    IEnumerator waitForFadeout(string scene) {
        yield return new WaitForSeconds(2f);
        loader.HandleReadyToLoad(scene);
    }

}
