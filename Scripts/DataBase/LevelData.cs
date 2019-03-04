using System;
/// <summary>
/// Stores Level Data information, this is array from GameData.cs.
/// </summary>
[Serializable]
public class LevelData
{
    public int levelNumber;     // This represents the level number.
    public bool isUnlocked;     // This unlocks or locks a level.
    public int starsAwarded;    // This keeps ammount of Stars for a levle number.
    public int levelScore;      // Tracks the ammount of score in level.
}
