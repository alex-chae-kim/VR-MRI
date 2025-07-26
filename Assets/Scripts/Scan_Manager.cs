using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scan_Manager : MonoBehaviour
{
    public List<Scan> scans;
    public AudioManager audioManager;
    public string scanStartAnnouncementClip;
    public Scan currentScan;
    public string music;
    public bool scansCompleted = false;

    private int currentScanIndex = 0;
    private bool isScanning = false;
    private bool playingMusic = false;

    void Start()
    {
    }

    public void addScan(Scan scan)
    {
        if (scan != null && !scans.Contains(scan))
        {
            scans.Add(scan);
            Debug.Log($"Scan '{scan.name}' added to the list.");
        }
        else
        {
            Debug.LogWarning("Scan is null or already exists in the list.");
        }
    }

    IEnumerator PlayAllScans()
    {
        isScanning = true;

        while (currentScanIndex < scans.Count)
        {
            currentScan = scans[currentScanIndex];

            // Announce scan start and duration
            yield return StartCoroutine(AnnounceScan(currentScan));

            // Play user music if allowed
            if (currentScan.allowUserMusic && !playingMusic)
            {
                audioManager.Play(music);
                playingMusic = true;
            }

            // Play MRI scan sound
            Sound scanSound = audioManager.Play(currentScan.clipName);

            // Wait for duration
            yield return new WaitForSeconds(scanSound.length + 1f);

            // Stop user music and scan sound
            if (currentScan.allowUserMusic && playingMusic)
            {
                audioManager.Stop(music);
                playingMusic = false;
            }

            audioManager.Stop(currentScan.clipName); // Optional if looped

            currentScanIndex++;
        }

        isScanning = false;
        scansCompleted = true;
    }

    IEnumerator AnnounceScan(Scan scan)
    {
        Sound announcementSound = audioManager.Play(scanStartAnnouncementClip);
        yield return new WaitForSeconds(announcementSound.length + 1f);
    }

    public void StartScanSequence()
    {
        if (!isScanning)
        {
            currentScanIndex = 0;
            StartCoroutine(PlayAllScans());
        }
    }
}
