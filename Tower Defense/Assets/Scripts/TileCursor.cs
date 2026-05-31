using UnityEngine;

public class TileCursor : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }

    private void OnEnable()
    {
        ListenToTilesIn(TargetGrid);
    }

    public void ListenToTilesIn(GameObject grid)
    {
        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.AddListener(HandleTileEntered);
        }
    }

    public void HandleTileEntered(TileController tile)
    {
        transform.position = tile.transform.position;
    }
}