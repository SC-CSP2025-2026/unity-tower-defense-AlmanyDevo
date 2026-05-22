using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [field: SerializeField]
    public float Speed { get; private set; } = 1f;

    [field: SerializeField]
    public Waypoint Target { get; private set; }

    void Start()
    {
        transform.position = Target.transform.position;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, Time.deltaTime * Speed);
        float distance = Vector3.Distance(transform.position, Target.transform.position);
        if (distance <= Mathf.Epsilon)
        {
            Target = Target.Next;
        }
    }

    public Transform GetCurrentWaypoint()
    {
        return Target.transform;
    }
}
