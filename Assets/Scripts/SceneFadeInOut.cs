using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneFadeInOut : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;

    void Awake()
    {
      //  DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToScene(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    IEnumerator FadeIn()
    {
        float t = fadeDuration;
        Color color = fadeImage.color;

        while (t > 0)
        {
            t -= Time.deltaTime;
            color.a = t / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0;
        fadeImage.color = color;
    }

    IEnumerator FadeOut(string sceneName)
    {
        float t = 0;
        Color color = fadeImage.color;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = t / fadeDuration;
            fadeImage.color = color;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
