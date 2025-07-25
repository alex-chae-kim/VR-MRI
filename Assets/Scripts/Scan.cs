using UnityEngine;

[System.Serializable]
public class Scan
{
    public string name;
    public string clipName;
    public string announcement;
    public float durationSeconds;
    public bool allowUserMusic;

    public Scan(string name, string clipName, string announcement, float durationSeconds, bool allowUserMusic)
    {
        this.name = name;
        this.clipName = clipName;
        this.announcement = announcement;
        this.durationSeconds = durationSeconds;
        this.allowUserMusic = allowUserMusic;
    }
}
