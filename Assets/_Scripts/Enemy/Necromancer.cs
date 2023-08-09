using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Necromancer : RangedEnemyController
{
    [SerializeField] private Bossbar bossbar;
    [SerializeField] private Animator sceneTransitionAnim;

    public GameObject skeletonPrefab;
    public float spawnDelay;
    public float spawnOffset;

    protected override void Start()
    {
        base.Start();
        bossbar.SetMaxBossHealth(maxHealth);
        StartCoroutine(SpawnSkeleton());
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        GetEnemies();
    }

    IEnumerator SpawnSkeleton()
    {
        while (true)
        {
            Vector3 spawnPositionLeft = transform.position - transform.right * spawnOffset;
            Instantiate(skeletonPrefab, spawnPositionLeft, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public override void TakeDamage(float damage, Vector2 knockbackDirection)
    {
        base.TakeDamage(damage, knockbackDirection);
        bossbar.SetBossHealth(currentHealth);
    }

    protected override void DestroyEnemy()
    {
        base.DestroyEnemy();
        bossbar.enabled = false;
        SceneController.instance.LoadLevel();
    }
}
