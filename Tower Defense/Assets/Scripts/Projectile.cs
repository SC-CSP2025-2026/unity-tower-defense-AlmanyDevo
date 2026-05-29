using UnityEngine;

public class Projectile : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; private set; } = 15f;

    [field: SerializeField]
    public float Damage { get; private set; } = 1;

    [field: SerializeField]
    public Transform Target { get; set; }

    void Update()
    {
        if (Target == null)
        {
            Destroy(gameObject);
            return;
        }

        transform.LookAt(Target);

        transform.position = Vector3.MoveTowards(
            transform.position,
            Target.position,
            Speed * Time.deltaTime
        );

        float distance = Vector3.Distance(transform.position, Target.position);

        if (distance <= 0.5f)
        {
            Health healthComponent = Target.GetComponentInParent<Health>();

            if (healthComponent != null)
            {
                healthComponent.ApplyHit(this);
            }

            Destroy(gameObject);
        }
    }
}