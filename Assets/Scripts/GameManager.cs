using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public CharacterController[] characters;
    private int activeCharacterIndex = 0;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void SetActiveCharacter(int index)
    {
        // Deactivate all first
        foreach (var c in characters)
            c.SetActive(false);

        activeCharacterIndex = index;
        characters[index].SetActive(true);

        AudioManager.Instance.PlayCharacterTheme(index);
        UIManager.Instance.UpdateCharacterDisplay(index);
    }

    public void TriggerMood(string mood)
    {
        characters[activeCharacterIndex].PlayMoodAnimation(mood);
        AudioManager.Instance.PlayMoodSound(mood);
        UIManager.Instance.UpdateMoodDisplay(mood);
    }
}