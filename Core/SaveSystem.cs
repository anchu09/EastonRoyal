using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Handles persistence of player profiles to disk using JSON serialization.
/// Files are stored under <c>Application.persistentDataPath/data/</c> and named
/// <c>user1.json</c>, <c>user2.json</c>, etc.
/// </summary>
public static class SaveSystem
{
    private static readonly string DataDirectory =
        Path.Combine(Application.persistentDataPath, "data");

    public static void SaveUser(SerializableUserData user)
    {
        EnsureDataDirectoryExists();

        int slotCount = Directory.GetFiles(DataDirectory, "user*.json").Length;
        string filePath = Path.Combine(DataDirectory, $"user{slotCount + 1}.json");

        WriteJson(filePath, user);
        Debug.Log($"[SaveSystem] Saved new player to {filePath}");
    }

    public static void UpdatePlayer(SerializableUserData user)
    {
        string filePath = DataManager.Instance.pathCurrentPlayer;
        WriteJson(filePath, user);
        Debug.Log($"[SaveSystem] Updated player save at {filePath}");
    }

    public static List<SerializableUserData> LoadUser()
    {
        if (!Directory.Exists(DataDirectory))
        {
            Debug.Log("[SaveSystem] No save directory found.");
            return new List<SerializableUserData>();
        }

        string[] files = Directory.GetFiles(DataDirectory, "user*.json");
        var players = new List<SerializableUserData>(files.Length);

        foreach (string filePath in files)
        {
            SerializableUserData player = ReadJson(filePath);
            if (player != null)
                players.Add(player);
        }

        Debug.Log($"[SaveSystem] Loaded {players.Count} player profile(s).");
        return players;
    }

    /// <summary>
    /// Loads the save file for the player with the given name and stores its path
    /// in <see cref="DataManager.pathCurrentPlayer"/>.
    /// </summary>
    public static SerializableUserData LoadCurrentPlayer(string playerName)
    {
        if (!Directory.Exists(DataDirectory))
        {
            Debug.LogError("[SaveSystem] Save directory does not exist.");
            return null;
        }

        foreach (string filePath in Directory.GetFiles(DataDirectory, "user*.json"))
        {
            SerializableUserData player = ReadJson(filePath);
            if (player != null && player.Name == playerName)
            {
                DataManager.Instance.pathCurrentPlayer = filePath;
                Debug.Log($"[SaveSystem] Loaded player '{playerName}' from {filePath}");
                return player;
            }
        }

        Debug.LogError($"[SaveSystem] No save file found for player '{playerName}'.");
        return null;
    }

    private static void EnsureDataDirectoryExists()
    {
        if (!Directory.Exists(DataDirectory))
            Directory.CreateDirectory(DataDirectory);
    }

    private static void WriteJson(string filePath, SerializableUserData user)
    {
        File.WriteAllText(filePath, JsonUtility.ToJson(user, prettyPrint: true));
    }

    private static SerializableUserData ReadJson(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Debug.LogWarning($"[SaveSystem] File not found: {filePath}");
            return null;
        }
        return JsonUtility.FromJson<SerializableUserData>(File.ReadAllText(filePath));
    }
}
