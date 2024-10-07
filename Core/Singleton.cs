using UnityEngine;

/// <summary>
/// Generic MonoBehaviour singleton base class. Derive from this instead of
/// re-implementing the pattern in every manager script.
/// </summary>
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning($"[Singleton] Duplicate {typeof(T).Name} detected — destroying the new one.");
            Destroy(gameObject);
            return;
        }

        Instance = this as T;
        DontDestroyOnLoad(gameObject);
    }
}
