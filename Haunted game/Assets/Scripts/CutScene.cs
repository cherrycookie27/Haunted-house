using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] GameObject background;
    [SerializeField] Sprite[] cutsceneImages;
    [SerializeField] float waitTime, fadeIn, fadeOut;
    int currentIndex;

    private void Start()
    {
        StartCoroutine(CutScene());
    }


    public IEnumerator CutScene()
    {
        background.SetActive(true);
        // Suorittaa looppia kunnes kuvat loppuu
        while (currentIndex < cutsceneImages.Length)
        {
            // Laittaa spriten kuvaan
            image.sprite = cutsceneImages[currentIndex];

            // Fade in
            for (float t = 0; t < fadeIn; t += Time.deltaTime)
            {
                image.color = new Color(1f, 1f, 1f, t += Time.deltaTime);
                yield return null;
            }

            // Kuvan vaihto aika
            yield return new WaitForSeconds(waitTime);

            // Fade out
            for (float t = 0; t < fadeOut; t += Time.deltaTime)
            {
                image.color = new Color(1f, 1f, 1f, 1 - (t / fadeIn));
                yield return null;
            }

            // Lisää yhden numeron indexiin
            currentIndex++;
        }

        background.SetActive(false);
        SceneManager.LoadScene("Game level");
    }
}
