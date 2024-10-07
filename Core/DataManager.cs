using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>Manages player profiles: creation, selection, auto-save, and UI population.</summary>
public class DataManager : Singleton<DataManager>
{
    public GameObject profileCardPrefab;

    public GameObject profileCardContainer;

    public InputField playerNameInput;

    public string nameCurrentPlayer;

    public SerializableUserData CurrentPlayer { get; set; }

    public string pathCurrentPlayer;

    public List<string> profileNames;

    private List<SerializableUserData> _allProfiles = new();
    private float _autoSaveTimer;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        ShowDataUI();
        _autoSaveTimer = 0f;
    }

    private void Update()
    {
        _autoSaveTimer += Time.deltaTime;

        // Read the name field every frame so it is current when the player confirms
        nameCurrentPlayer = playerNameInput.text;

        if (_autoSaveTimer >= GameConstants.AutoSaveInterval)
        {
            if (CurrentPlayer != null)
                SaveSystem.UpdatePlayer(CurrentPlayer);
            _autoSaveTimer = 0f;
        }

        if (startGameRequested)
        {
            if (!profileNames.Contains(nameCurrentPlayer))
                Insert();

            LoadCurrentPlayer();
            UnityEngine.SceneManagement.SceneManager.LoadScene(GameConstants.SceneGame);
            startGameRequested = false;
        }
    }

    public bool startGameRequested = false;

    public void LoadCurrentPlayer()
    {
        CurrentPlayer = SaveSystem.LoadCurrentPlayer(nameCurrentPlayer);
    }

    private void Insert()
    {
        var newProfile = new SerializableUserData(nameCurrentPlayer);
        SaveSystem.SaveUser(newProfile);
        Debug.Log($"[DataManager] Created new profile: {nameCurrentPlayer}");
    }

    private void ShowDataUI()
    {
        _allProfiles = SaveSystem.LoadUser();
        profileNames = new List<string>(_allProfiles.Count);

        if (_allProfiles.Count == 0)
        {
            Debug.Log("[DataManager] No saved profiles found.");
            return;
        }

        foreach (SerializableUserData profile in _allProfiles)
        {
            profileNames.Add(profile.Name);

            GameObject card = Instantiate(profileCardPrefab, profileCardContainer.transform);
            card.GetComponent<PlayerProfileCard>().SetData(profile);
        }
    }
}
