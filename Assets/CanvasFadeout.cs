using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFadeout : MonoBehaviour
{
    void Start() {
        fadeCanvasPub();
    }
    [SerializeField]
    Canvas canvas;
    public void fadeCanvasPub() {
        StartCoroutine(fadeCanvas());
    }

    IEnumerator fadeCanvas() {
        var canvasGroup = canvas.GetComponent<CanvasGroup>();
        var alphaColor = canvasGroup.alpha;
        float fadeDuration = 1f;
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration) {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(alphaColor, 1.0f - alphaColor, elapsedTime / fadeDuration);
            yield return null;
        }
        canvasGroup.alpha = 1.0f - alphaColor;
    }
}
