using UnityEngine;

public class TurrentSpawner : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TurrentPrefab { get; private set; }

    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }

    void OnEnable()
    {
        ListenToTilesIn(TargetGrid);
    }

    void OnDisable()
    {
        StopListeningToTilesIn(TargetGrid);
    }

    public void ListenToTilesIn(GameObject grid)
    {
        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorClicked.AddListener(SpawnTurrent);
        }
    }

    public void StopListeningToTilesIn(GameObject grid)
    {
        if (grid == null)
        {
            return;
        }

        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorClicked.RemoveListener(SpawnTurrent);
        }
    }

    public void SpawnTurrent(TileController TileController)
    {
        if (TileController.IsOccupied)
        {
            return;
        }

        GameObject newTurrent = Instantiate(TurrentPrefab);
        newTurrent.transform.position = TileController.transform.position;

        TileController.SetIsOccupied(true);
    }
}