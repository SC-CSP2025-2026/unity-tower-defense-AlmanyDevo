using UnityEngine;
using UnityEngine.Events;

public class TileController : MonoBehaviour
{
    [field: SerializeField]
    public bool IsOccupied { get; private set; } = false;

    [field: SerializeField]
    public UnityEvent<TileController> OnCursorEnter;

    [field: SerializeField]
    public UnityEvent<TileController> OnCursorExit;

    [field: SerializeField]
    public UnityEvent<TileController> OnCursorClicked;

    public void SetIsOccupied(bool isOccupied)
    {
        IsOccupied = isOccupied;
    }

    public void NotifyCursorEnter()
    {
        Debug.Log("Notify cursor entered");
        OnCursorEnter.Invoke(this);
    }

    public void NotifyCursorExit()
    {
        OnCursorExit.Invoke(this);
    }

    public void NotifyCursorClicked()
    {
        OnCursorClicked.Invoke(this);
    }
}