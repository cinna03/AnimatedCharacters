using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Animator animator;
    public string characterName;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetActive(bool state)
    {
        gameObject.SetActive(state);
    }

    public void PlayMoodAnimation(string mood)
    {
        // Reset all triggers first
        animator.ResetTrigger("Happy");
        animator.ResetTrigger("Sad");
        animator.ResetTrigger("Angry");

        animator.SetTrigger(mood);
    }
}