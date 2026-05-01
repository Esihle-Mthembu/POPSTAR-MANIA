using UnityEngine;

[CreateAssetMenu(fileName = "NewLyricsDa", menuName = "Game/Lyrics Data")]
public class LyricsGameData : ScriptableObject
{
    public LyricLines[] lines;
}