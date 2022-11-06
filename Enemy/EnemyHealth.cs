using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] uint MaxHitPoints = 5;
    [SerializeField] uint difficultyRamp = 1;

    uint currentHitPoints = 0;
    Enemy enemy;

    void OnEnable()
    {
        currentHitPoints = MaxHitPoints;
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints <= 0)
        {
            gameObject.SetActive(false);
            MaxHitPoints += difficultyRamp;
            enemy.RewardGold();
        }
    }
}
