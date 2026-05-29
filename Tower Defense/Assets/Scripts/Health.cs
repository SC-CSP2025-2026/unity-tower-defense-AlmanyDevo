using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [field: SerializeField]
    public float BaseHealth { get; private set; } = 5f;

    [field: SerializeField]
    public float CurrentHealth { get; private set; }

    [field: SerializeField]
    public UnityEvent<Health> OnDeath { get; private set; }

    void Start()
    {
        CurrentHealth = BaseHealth;
    }

    public void ApplyHit(Projectile projectile)
    {
        CurrentHealth -= projectile.Damage;

        Debug.Log(CurrentHealth);

        if (CurrentHealth <= 0)
        {
            OnDeath.Invoke(this);

            Destroy(gameObject);
        }
    }
}