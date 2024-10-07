/// <summary>
/// Game-wide constants. Change values here — do not scatter magic numbers
/// across individual scripts.
/// </summary>
public static class GameConstants
{
    public const double ProgressPerPuzzle = 6.66666666667;

    public const float AutoSaveInterval = 60f;

    public const float MenuInputCooldown = 0.5f;

    public const float InteractionCooldown = 2.0f;

    public const float ZoneTransitionDuration = 1f;

    public const float PuzzleResetDelay = 1.0f;

    // Scene names

    public const string SceneMainMenu = "MainMenu";

    public const string SceneGame = "EastonRoyal";

    // Level identifiers (used to track the current active zone at runtime)

    public const string LevelDungeon = "dungeon";

    public const string LevelLibrary = "library";

    // Object tags (must match tags defined in the Unity project settings)

    public const string TagMatch = "match";

    public const string TagDungeonKey = "dungeonKey";

    public const string TagDrawerKey = "drawerKey";

    public const string TagBottle = "bottle";

    public const string TagThumbtackCorrect = "chincheta_buena";

    public const string TagFinalKey = "finalKey";

    // Runtime settings (set from the main menu before the game scene loads)

    public static int MusicTrackIndex = 0;
}
