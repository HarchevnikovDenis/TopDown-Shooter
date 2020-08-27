using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerShooting : GeneralShooting
{
    private List<Transform> enemies = new List<Transform>();
    
    private void Start()
    {
        InitializeEnemiesTransform();
    }

    // Находим всех противников
    private void InitializeEnemiesTransform()
    {
        List<EnemyShooting> enemyShooting = FindObjectsOfType<EnemyShooting>().ToList();
        foreach (EnemyShooting enemy in enemyShooting)
        {
            enemies.Add(enemy.gameObject.transform);
        }
    }

    private void Update()
    {
        if(target == null)
        {
            FindNearestEnemy();
            timeSinceLastShoot += Time.deltaTime;
            return;
        }

        if(timeSinceLastShoot >= rate)
        {
            Shoot();
        }
        else
        {
            timeSinceLastShoot += Time.deltaTime;
        }

        transform.LookAt(target);
    }

    private void FindNearestEnemy()
    {
        float shortestDistance = Mathf.Infinity;
        int index = 0;

        for (int i = 0; i < enemies.Count; i++)
        {
            if(enemies[i] == null)
            {
                enemies.RemoveAt(i);
                continue;
            }

            if(Vector3.Distance(transform.position, enemies[i].position) < shortestDistance)
            {
                shortestDistance = Vector3.Distance(transform.position, enemies[i].position);
                index = i;
            }
        }

        if(enemies.Count == 0)
        {
            // Игрок победил
            UI_Controller ui_controller = FindObjectOfType<UI_Controller>();
            ui_controller?.ShowPanel(true);
        }
        else
        {
            target = enemies[index];
        }
    }
}
