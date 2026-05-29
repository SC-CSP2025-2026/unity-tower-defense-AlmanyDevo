using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    [field: SerializeField]
    public AreaOfEngagement AoE { get; private set; }

    [field: SerializeField]
    public Projectile ProjectilePrefab { get; private set; }

    [field: SerializeField]
    public float CooldownTime { get; private set; } = 1f;

    [field: SerializeField]
    public bool IsOnCooldown { get; private set; } = false;

    void Update()
    {
        if (IsOnCooldown)
        {
            return;
        }

        if (AoE.Targets.Count == 0)
        {
            return;
        }

        Fire();

        IsOnCooldown = true;
        Invoke(nameof(ResetCooldown), CooldownTime);
    }

    public void Fire()
    {
        Projectile newProjectile = Instantiate(ProjectilePrefab);

        newProjectile.transform.position = transform.position;

        newProjectile.Target = AoE.Targets[0].transform;
    }

    public void ResetCooldown()
    {
        IsOnCooldown = false;
    }
}