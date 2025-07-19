using UnityEngine;
using System.Collections;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
using Unity.VRTemplate;

public class Stage_4 : StepManager
{
    public Animator headCoilAnimator;
    public Animator bedAnimator;
    public GameObject stage4;
    public InputGetter InputGetter;
    public AudioManager audioManager;
    private float holdTime = 2f;
    private float holdTime_2 = 2f;
    private bool headCoilAudioPlayed = false;
    private bool readyToBeginAudioPlayed = false;
    private bool first_1 = true;
    private bool first_2 = true;

    // Update is called once per frame
    void Update()
    {
        if (InputGetter.GetRightTrigger() > 0.5f && headCoilAudioPlayed)
        {
            holdTime -= Time.deltaTime;
            if (holdTime <= 0f && first_1)
            {
                first_1 = false;
                StartCoroutine("slideIntoMRI");
            }
        }
        else
        {
            holdTime = 2f;
        }

        if (InputGetter.GetRightTrigger() > 0.5f && readyToBeginAudioPlayed)
        {
            holdTime_2 -= Time.deltaTime;
            if (holdTime_2 <= 0f && first_2)
            {
                first_2 = false;
                Debug.Log("Begin MRI sequence");
            }
        }
        else
        {
            holdTime_2 = 2f;
        }
    }

    public override void OnLastContinue()
    {
        Debug.Log("Stage 4: OnLastContinue called");
        StartCoroutine("putOnHeadCoil");
    }

    private IEnumerator putOnHeadCoil()
    {
        stage4.SetActive(false);
        headCoilAnimator.enabled = true;
        yield return new WaitForSeconds(7f);
        audioManager.Play("HeadCoilPrompt");
        yield return new WaitForSeconds(5f);
        headCoilAudioPlayed = true;

    }

    private IEnumerator slideIntoMRI()
    {
        bedAnimator.enabled = true;
        yield return new WaitForSeconds(10f);
        audioManager.Play("ReadyToBegin?");
        yield return new WaitForSeconds(5f);
        readyToBeginAudioPlayed = true;

    }

    // start next stage
}
