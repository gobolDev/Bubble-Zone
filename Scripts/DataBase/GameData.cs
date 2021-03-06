﻿using System;               // Gives access to the [Serializable] attribute!
/// <summary>
/// The Data Model for my game data
/// </summary>
[Serializable]
public class GameData
{
    public int Score;                       // Tracks the ammount of score in level.
    public int Life;                        // Tracks the ammount of players life.
    public LevelData[] levelData;           // Stores information of each level.
    public bool IsFirstBoot;                // Checks if the game was loaded for the first time.
}
