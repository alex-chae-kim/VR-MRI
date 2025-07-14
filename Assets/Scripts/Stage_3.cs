using UnityEngine;
using System.Collections;

public class Stage_3 : MonoBehaviour
{
    public InputGetter InputGetter;
    public GameObject newXROrigin;
    public GameObject oldXROrigin;
    public GameObject stage4;
    public Animator Animator;
    private float holdTime = 2f;
    private bool first = false;

    // Update is called once per frame
    void Update()
    {
        if (InputGetter.GetLeftTrigger() > 0.5f && InputGetter.GetRightTrigger() > 0.5f )
        {
            holdTime -= Time.deltaTime;
            if (holdTime <= 0f && first)
            {
                first = false;
                Debug.Log("Stage 3 completed!");
                StartCoroutine(transitionToMRI());
            }
        }
        else
        {
            holdTime = 2f;
        }
    }

    private IEnumerator transitionToMRI()
    {
        Animator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(3f);
        newXROrigin.SetActive(true);
        oldXROrigin.SetActive(false);
        stage4.SetActive(true);
        Animator.SetTrigger("FadeIn");
        this.gameObject.SetActive(false);
    }
}
