using UnityEngine;

public class TileCursor : MonoBehaviour
{
    public void HandleTileEntered(TileController tile)
    {
        transform.position = tile.transform.position;
    }
}
