using UnityEngine;
using UnityEngine.Events;

public class TileController : MonoBehaviour
{
    [field: SerializeField]
    public bool IsOccupied { get; private set; } = false;

    [field: SerializeField]
    public UnityEvent<TileController> OnCursorEnter = new();

    public void NotifyCursorEnter()
    {
        OnCursorEnter.Invoke(this);
    }
}