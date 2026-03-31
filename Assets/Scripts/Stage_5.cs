using System.Collections;
using Unity.XR.CoreUtils;
using UnityEngine;

public class Stage_5 : MonoBehaviour
{
    public Scan_Manager scanManager;
    public Animator headCoilAnimator;
    public Animator bedAnimator;
    public GameObject stage6;
    public AudioManager audioManager;

    public Transform target;
    public XROrigin XROrigin;
    public GameObject oldXROrigin;
    public Animator oldAnimator;

    private bool flag = true;
    // Update is called once per frame
    void Update()
    {
        if (scanManager.scansCompleted && flag)
        {
            flag = false;
            StartCoroutine(exitMRI());
        }
    }

    public void startScanManager()
    {
        scanManager.StartScanSequence();
    }

    private IEnumerator exitMRI()
    {
        audioManager.Play("Audio 15");
        yield return new WaitForSeconds(8f);
        bedAnimator.SetTrigger("mriExit");
        yield return new WaitForSeconds(6f); 
        audioManager.Play("Audio 16");
        yield return new WaitForSeconds(2f);
        headCoilAnimator.SetTrigger("coilToTable");
        yield return new WaitForSeconds(10f);
        oldAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(3f);
        XROrigin.MoveCameraToWorldLocation(target.position);
        XROrigin.MatchOriginUpCameraForward(target.up, target.forward);
        oldAnimator.SetTrigger("FadeIn");
        //oldXROrigin.SetActive(false);
        //newXROrigin.SetActive(true);
        stage6.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
