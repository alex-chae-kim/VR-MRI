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

    private bool first = true;
    // Update is called once per frame
    void Update()
    {
        if (scanManager.scansCompleted && first)
        {
            first = false;
            StartCoroutine(exitMRI());
        }
    }

    public void startScanManager()
    {
        scanManager.StartScanSequence();
    }

    private IEnumerator exitMRI()
    {
        audioManager.Play("Scans Completed");
        yield return new WaitForSeconds(5f); // Adjust time as needed
        bedAnimator.SetTrigger("mriExit");
        yield return new WaitForSeconds(8f); // Adjust time as needed
        headCoilAnimator.SetTrigger("coilToTable");
        yield return new WaitForSeconds(8f); // Adjust time as needed
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
