using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] RectTransform fader;
    public Button btnRetry;
    public Button btnMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickRetry()
    {
        btnRetry.gameObject.SetActive(true);
        btnMenu.gameObject.SetActive(true);
        Invoke("btnDisappearCha", 0f);

        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete(() =>
        {
            Invoke("loadRetry", 0.5f);
        });
    }

    private void loadRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void btnDisappearCha()
    {
        if (btnRetry.gameObject.activeSelf == true)
        {
            btnMenu.gameObject.SetActive(false);
            btnRetry.gameObject.SetActive(false);
        }
        else if (btnMenu.gameObject.activeSelf == true)
        {
            btnMenu.gameObject.SetActive(false);
            btnRetry.gameObject.SetActive(false);
        }
    }

    public void ClickMenu()
    {
        btnRetry.gameObject.SetActive(true);
        btnMenu.gameObject.SetActive(true);
        Invoke("btnDisappearCha", 0f);

        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete(() =>
        {
            Invoke("menu", 0.5f);
        });
    }

    private void menu()
    {
        SceneManager.LoadScene("Menu");
    }


    public void ClickContinue()
    {
        btnRetry.gameObject.SetActive(true);
        btnMenu.gameObject.SetActive(true);
        Invoke("btnDisappearCha", 0f);

        fader.gameObject.SetActive(true);
        LeanTween.alpha(fader, 0, 0);
        LeanTween.alpha(fader, 1, 0.5f).setOnComplete(() =>
        {
            Invoke("Continues", 0.5f);
        });
    }

    private void Continues()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
