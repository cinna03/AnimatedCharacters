using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject homeScreen;
    public GameObject characterSelectScreen;
    public GameObject interactionScreen;

    public TextMeshProUGUI characterNameText;
    public TextMeshProUGUI moodText;

    public Animator uiAnimator;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void GoToCharacterSelect()
    {
        homeScreen.SetActive(false);
        characterSelectScreen.SetActive(true);
        uiAnimator.SetTrigger("SlideIn");
    }

    public void GoToInteraction()
    {
        characterSelectScreen.SetActive(false);
        interactionScreen.SetActive(true);
        uiAnimator.SetTrigger("SlideIn");
    }

    public void GoBack()
    {
        interactionScreen.SetActive(false);
        characterSelectScreen.SetActive(true);
        uiAnimator.SetTrigger("SlideIn");
    }

    public void UpdateCharacterDisplay(int index)
    {
        string[] names = { "Alex", "Jordan", "Sam" };
        characterNameText.text = names[index];
    }

    public void UpdateMoodDisplay(string mood)
    {
        moodText.text = $"Mood: {mood}";
    }
}