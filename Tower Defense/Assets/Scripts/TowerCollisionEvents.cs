using UnityEngine;
using UnityEngine.Events;

public class TowerCollisionEvents : MonoBehaviour
{
    [field: SerializeField]
    public UnityEvent<EnemyAttack> OnEnemyHit { get; private set; }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);

        EnemyAttack attack = other.GetComponentInParent<EnemyAttack>();

        if (attack == null)
        {
            return;
        }

        OnEnemyHit.Invoke(attack);
    }
}