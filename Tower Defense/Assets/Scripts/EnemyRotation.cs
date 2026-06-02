using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    private EnemyMovement EnemyMovement;

    void Start()
    {
        EnemyMovement = GetComponent<EnemyMovement>();
    }

    void Update()
    {
        Transform currentWaypoint = EnemyMovement.GetCurrentWaypoint();

        if (currentWaypoint != null)
        {
            transform.LookAt(currentWaypoint);
        }
    }
}