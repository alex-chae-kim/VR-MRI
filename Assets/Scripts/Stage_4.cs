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
    public Stage_5 stage5;
    public InputGetter InputGetter;
    public AudioManager audioManager;


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
        audioManager.Play("Audio 12");
        yield return new WaitForSeconds(24f);
        StartCoroutine("slideIntoMRI");
    }

    private IEnumerator slideIntoMRI()
    {
        bedAnimator.enabled = true;
        yield return new WaitForSeconds(10f);
        audioManager.Play("Chime2");
        yield return new WaitForSeconds(2f);
        audioManager.Play("Audio 13");
        yield return new WaitForSeconds(18f);
        stage5.startScanManager();
    }
}
