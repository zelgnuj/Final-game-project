using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    private EntityFX fx;

    [Header("Major stats")]
    public Stat strength; // 1 point increase damage by 1 and crit.power by 1%

    [Header("Offensive stats")]
    public Stat damage;

    [Header("Defensive stats")]
    public Stat maxHealth;

    public int currentHealth;

    public System.Action onHealthChanged;
    protected bool isDead;

    protected virtual void Start()
    {
        currentHealth = GetMaxHealthValue();

        fx = GetComponent<EntityFX>();
    }

    protected virtual void Update()
    {
    }



    public virtual void DoDamage(CharacterStats _targetStats)
    {

        int totalDamage = damage.GetValue() + strength.GetValue();

        _targetStats.TakeDamage(totalDamage);

    }


    public virtual void TakeDamage(int _damage)
    {
        DecreaseHealthBy(_damage);

        if (currentHealth < 0 && !isDead)
            Die();


    }

    protected virtual void DecreaseHealthBy(int _damage)
    {
        currentHealth -= _damage;

        if (onHealthChanged != null)
            onHealthChanged();
    }

    protected virtual void Die()
    {
        isDead = true;
    }

    public void KillEntity() => Die();

    public int GetMaxHealthValue()
    {
        return maxHealth.GetValue();
    }

}
