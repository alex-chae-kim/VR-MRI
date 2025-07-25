using UnityEngine;

[System.Serializable]
public class Scan
{
    public string name;
    public string clipName;
    public string announcement;
    public bool allowUserMusic;

    public Scan(string name, string clipName, string announcement, bool allowUserMusic)
    {
        this.name = name;
        this.clipName = clipName;
        this.announcement = announcement;
        this.allowUserMusic = allowUserMusic;
    }
}
