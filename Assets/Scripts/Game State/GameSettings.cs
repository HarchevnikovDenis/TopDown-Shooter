using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private List<LevelSpawnOptions> levelsOption;
    [Header("Bullet Damage Settings")]
    [SerializeField, Range(1.0f, 75.0f)] private float playerDamage;
    [SerializeField, Range(1.0f, 100.0f)] private float enemyDamage;

    private GameObject currentLevelObject;
    private float playerDamageOld;
    private float enemyDamageOld;
    private int currentLevel = 1;
    public float PlayerDamage { get { return playerDamage; } }
    public float EnemyDamage { get { return enemyDamage; } }

    private void Awake()
    {
        playerDamageOld = playerDamage;
        enemyDamageOld = enemyDamage;

        SpawnLevel(0);
    }

    public void StartLevel(bool isRestart = false)
    {
        int index = currentLevel;
        if (!isRestart)
        {
            index++;
            if(index > levelsOption.Count - 1)
            {
                index = 0; 
            }
        }

        SpawnLevel(index);
    }

    // Проверяем были ли изменены значения урона оружия через инспектор
    private void Update()
    {
        if(playerDamageOld != playerDamage)
        {
            UpdatePlayerBulletsDamage();
            playerDamageOld = playerDamage;
        }

        if(enemyDamageOld != enemyDamage)
        {
            UpdateEnemyBulletsDamage();
            enemyDamageOld = enemyDamage;
        }
    }

    private void UpdatePlayerBulletsDamage()
    {
        List<BulletCollision> bullets = FindObjectsOfType<BulletCollision>().ToList();

        foreach (BulletCollision bullet in bullets)
        {
            if(bullet.isPlayer)
            {
                bullet.damage = playerDamage;
            }
        }
    }

    private void UpdateEnemyBulletsDamage()
    {
        List<BulletCollision> bullets = FindObjectsOfType<BulletCollision>().ToList();

        foreach (BulletCollision bullet in bullets)
        {
            if (!bullet.isPlayer)
            {
                bullet.damage = enemyDamage;
            }
        }
    }

    private void SpawnLevel(int index)
    {
        GameObject oldLevel = currentLevelObject;
        Destroy(oldLevel);
        foreach (LevelSpawnOptions level in levelsOption)
        {
            if(level.Index == index)
            {
                currentLevelObject = Instantiate(level.LevelPrefab, level.SpawnPosition, Quaternion.identity);
                Vector3 playerPositionSpawn = level.SpawnPosition + Vector3.up;
                Instantiate(playerPrefab, playerPositionSpawn, Quaternion.identity);
                currentLevel = index;
            }
        }

        Camera.main.gameObject.GetComponent<CameraFollow>().FindNewTarget();
    }
}
