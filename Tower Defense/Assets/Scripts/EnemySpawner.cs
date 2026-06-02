using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private EnemyMovement enemy;

    [SerializeField]
    private Waypoint startingWaypoint;

    [SerializeField]
    private float delay = 5f;

    [SerializeField]
    private int spawnsRemaining = 5;

    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), delay, delay);
    }

    public void Spawn()
    {
        EnemyMovement newEnemy = Instantiate(enemy);
        newEnemy.Target = startingWaypoint;

        spawnsRemaining--;

        if (spawnsRemaining <= 0)
        {
            CancelInvoke();
        }
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}