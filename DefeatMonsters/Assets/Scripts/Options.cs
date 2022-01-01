using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    [SerializeField] RectTransform fader;
    public Button btnBack;


    private void btnDisappearCha()
    {
        if (btnBack.gameObject.activeSelf == true)
        {
            btnBack.gameObject.SetActive(false);
        }
    }



    public void ClickBack()
    {
        btnBack.gameObject.SetActive(true);
        Invoke("btnDisappearCha", 0f);

        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete(() =>
        {
            Invoke("back", 0.5f);
        });
    }

    private void back()
    {
        SceneManager.LoadScene("Menu");
    }
}
