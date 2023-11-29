using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFadeout : MonoBehaviour
{
    void Start() {
        fadeCanvasPub();
    }
    [SerializeField]
    CanvasGroup canvasGroup;
    public void fadeCanvasPub() {
        StartCoroutine(fadeCanvas());
    }

    IEnumerator fadeCanvas() {
        var alphaColor = canvasGroup.alpha;
        float fadeDuration = 1f;
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration) {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(alphaColor, 1.0f - alphaColor, elapsedTime / fadeDuration);
            yield return null;
        }
        Debug.Log("Setting alpha to " + (1.0f - alphaColor));
        canvasGroup.alpha = 1.0f - alphaColor;
    }
}
