using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] RectTransform fader;
    [SerializeField] RectTransform fader1;

    public Button btnStart;
    public Button btnOption;
    public Button btnQuit;

    // Start is called before the first frame update
    void Start()
    {
        //fader.gameObject.SetActive(true);

        //LeanTween.scale(fader, new Vector3(1, 1, 1), 0);

        //LeanTween.scale(fader, Vector3.zero, 0.5f).setOnComplete (() =>
        //{
        //    fader.gameObject.SetActive(false);
        //});

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //button play in menu
    public void ClickStart()
    {
        btnStart.gameObject.SetActive(true);
        btnOption.gameObject.SetActive(true);
        btnQuit.gameObject.SetActive(true);
        Invoke("btnDisappear", 0f);

        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete(() =>
        {
            Invoke("loadCharacters", 0.5f);
        });
    }

    // disappear button when click
    private void btnDisappear()
    {
        if (btnStart.gameObject.activeSelf == true)
        {
            btnStart.gameObject.SetActive(false);
            btnOption.gameObject.SetActive(false);
            btnQuit.gameObject.SetActive(false);
        }
        else if (btnOption.gameObject.activeSelf == true)
        {
            btnStart.gameObject.SetActive(false);
            btnOption.gameObject.SetActive(false);
            btnQuit.gameObject.SetActive(false);
        }
        else if (btnQuit.gameObject.activeSelf == true)
        {
            btnStart.gameObject.SetActive(false);
            btnOption.gameObject.SetActive(false);
            btnQuit.gameObject.SetActive(false);
        }
    }

    private void loadCharacters()
    {
        SceneManager.LoadScene("Characters");
    }


    //button play in menu
    public void ClickOptions()
    {
        btnStart.gameObject.SetActive(true);
        btnOption.gameObject.SetActive(true);
        btnQuit.gameObject.SetActive(true);
        Invoke("btnDisappear", 0f);

        fader1.gameObject.SetActive(true);
        LeanTween.alpha(fader1, 0, 0);
        LeanTween.alpha(fader1, 1, 0.5f).setOnComplete(() =>
        {
            Invoke("loadOptions", 0.5f);
        });
    }


    private void loadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    //button Exit in menu
    public void Exit()
    {
        Application.Quit();
    }

}
