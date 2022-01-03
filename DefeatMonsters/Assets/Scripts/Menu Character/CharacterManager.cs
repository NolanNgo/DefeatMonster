using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    [SerializeField] RectTransform fader;
    [SerializeField] RectTransform fader1;
    public Button btnSelect;
    public Button btnMenu;

    public CharacterDatabase characterDB;
    public Text nameText;
    public Image artworkSprite;
    public int selectedOption = 0;

    public PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        }
        else 
        {
            Load();
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;
        if (selectedOption >= characterDB.CharacterCount) 
        {
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;
        if (selectedOption < 0) 
        {
            selectedOption = characterDB.CharacterCount - 1;
        }
        UpdateCharacter(selectedOption);
        Save();
    }

    private void UpdateCharacter(int selectedOption)
    {
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("seletedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void ClickSelect()
    {
        player.id = selectedOption;
        if (selectedOption == 0)
        {
            player.healthPlayer = 5000;
            player.maxHealth = 5000;
            player.dame = 300;
            player.coins = 0;
        }
        if (selectedOption == 1)
        {
            player.healthPlayer = 4000;
            player.maxHealth = 4000;
            player.dame = 250;
            player.coins = 0;
        }
        if (selectedOption == 2)
        {
            player.healthPlayer = 2500;
            player.maxHealth = 2500;
            player.dame = 300;
            player.coins = 0;
        }
        if (selectedOption == 3)
        {
            player.healthPlayer = 1500;
            player.maxHealth = 1500;
            player.dame = 500;
            player.coins = 0;
        }
        if (selectedOption == 4)
        {
            player.healthPlayer = 1700;
            player.maxHealth = 1700;
            player.dame = 500;
            player.coins = 0;
        }

        SaveSystem.SavePlayer(player);

        btnSelect.gameObject.SetActive(true);
        btnMenu.gameObject.SetActive(true);
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
            btnMenu.gameObject.SetActive(false);
            btnSelect.gameObject.SetActive(false);
        }
        else if (btnMenu.gameObject.activeSelf == true)
        {
            btnMenu.gameObject.SetActive(false);
            btnSelect.gameObject.SetActive(false);
        }
    }



    public void ClickMenu()
    {
        btnSelect.gameObject.SetActive(true);
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
}
