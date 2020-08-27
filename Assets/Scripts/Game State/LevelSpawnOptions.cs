using UnityEngine;

[System.Serializable]
public class LevelSpawnOptions
{
    [SerializeField] private GameObject levelPrefab;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private int index;

    public GameObject LevelPrefab { get { return levelPrefab; } }
    public Vector3 SpawnPosition { get { return spawnPosition; } }
    public int Index { get { return index; } }
}
