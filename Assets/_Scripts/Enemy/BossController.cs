using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BossController : EnemyController
{
    [SerializeField] private RangedEnemyController rangedAI;
    [SerializeField] private MeleeEnemyController meleeAI;

    protected override void Start()
    {
        base.Start();

        rangedAI = GetComponent<RangedEnemyController>();
        meleeAI = GetComponent<MeleeEnemyController>();

        rangedAI.enabled = true;
        meleeAI.enabled = false;
    }

    private void Update()
    {
        rangedAI.maxHealth = maxHealth;
        rangedAI.currentHealth = currentHealth;

        if (currentHealth <= maxHealth / 2f)
        {
            rangedAI.enabled = false;
            meleeAI.enabled = true;
            meleeAI.maxHealth = currentHealth;
            meleeAI.currentHealth = currentHealth;
            meleeAI.damage = damage;
        }
    }

    public override void TakeDamage(float damage, Vector2 knockbackDirection)
    {
        base.TakeDamage(damage, knockbackDirection);
    }

    protected override void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
