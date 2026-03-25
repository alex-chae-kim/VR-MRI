using System.Collections;
using UnityEngine;

public class Narration_Manager : MonoBehaviour
{
    [SerializeField] string[] narrationTitles;
    private int totalNarrations;
    public AudioManager audioManager;

    [Header("Initial Narration Settings")]
    public float startingDelay = 0f;

    private int currentNarrationIndex = -1;

    private void Awake()
    {
        totalNarrations = narrationTitles != null ? narrationTitles.Length : 0;

        if (totalNarrations > 0)
        {
            StartCoroutine(PlayNarrationAfterDelay(0, startingDelay));
        }
    }

    private IEnumerator PlayNarrationAfterDelay(int narrationIndex, float delay)
    {
        yield return new WaitForSeconds(delay);

        currentNarrationIndex = narrationIndex;

        audioManager.Play(narrationTitles[currentNarrationIndex]);
    }

    public void Next()
    {
        if (currentNarrationIndex >= 0 && currentNarrationIndex < totalNarrations)
        {
            audioManager.Stop(narrationTitles[currentNarrationIndex]);
        }

        int nextIndex = currentNarrationIndex + 1;

        if (nextIndex >= 0 && nextIndex < totalNarrations)
        {
            currentNarrationIndex = nextIndex;

            audioManager.Play(narrationTitles[currentNarrationIndex]);
        }
        else
        {
            currentNarrationIndex = totalNarrations;
        }
    }
}