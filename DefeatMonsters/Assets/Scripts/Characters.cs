using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Characters : MonoBehaviour
{
    [SerializeField] RectTransform fader;
    [SerializeField] RectTransform fader1;
    public Button btnSelect;
    public Button btnBack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickSelect()
    {
        btnSelect.gameObject.SetActive(true);
        btnBack.gameObject.SetActive(true);
        Invoke("btnDisappearCha", 0f);

        fader1.gameObject.SetActive(true);
        LeanTween.alpha(fader1, 0, 0);
        LeanTween.alpha(fader1, 1, 0.5f).setOnComplete(() =>
        {
            Invoke("loadSelect", 0.5f);
        });
    }

    private void loadSelect()
    {
        SceneManager.LoadScene("Level1");
    }

    private void btnDisappearCha()
    {
        if (btnSelect.gameObject.activeSelf == true)
        {
            btnBack.gameObject.SetActive(false);
            btnSelect.gameObject.SetActive(false);
        }
        else if (btnBack.gameObject.activeSelf == true)
        {
            btnBack.gameObject.SetActive(false);
            btnSelect.gameObject.SetActive(false);
        }
    }



    public void ClickBack()
    {
        btnSelect.gameObject.SetActive(true);
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
