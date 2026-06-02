using UnityEngine;

public class TurrentSpawner : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TurrentPrefab { get; private set; }

    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }

    [field: SerializeField]
    public PlayerController Controller { get; private set; }

    [field: SerializeField]
    public TurrentSpawner OtherSpawner { get; private set; }

    void OnEnable()
    {
        if (OtherSpawner != null)
        {
            OtherSpawner.enabled = false;
        }

        Controller.InfoLabel.text = "Select a Tile";
        ListenToTilesIn(TargetGrid);
    }

    void OnDisable()
    {
        StopListeningToTilesIn(TargetGrid);

        if (Controller != null && Controller.InfoLabel != null)
        {
            Controller.InfoLabel.text = "Click Build to Place a Turret";
        }
    }

    public void ListenToTilesIn(GameObject grid)
    {
        foreach (TileController tile in grid.GetComponentsInChildren<TileController>())
        {
            tile.OnCursorEnter.AddListener(ShowInfo);
            tile.OnCursorExit.AddListener(ShowSelectTile);
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
            tile.OnCursorEnter.RemoveListener(ShowInfo);
            tile.OnCursorExit.RemoveListener(ShowSelectTile);
            tile.OnCursorClicked.RemoveListener(SpawnTurrent);
        }
    }

    public bool CanSpawn(TileController tileController)
    {
        if (tileController.IsOccupied)
        {
            return false;
        }

        if (Controller.Gold < 50)
        {
            return false;
        }

        return true;
    }

    public void SpawnTurrent(TileController TileController)
    {
        if (!CanSpawn(TileController))
        {
            return;
        }

        GameObject newTurrent = Instantiate(TurrentPrefab, Controller.transform);
        newTurrent.transform.position = TileController.transform.position;

        TileController.SetIsOccupied(true);
        Controller.Gold -= 50;
    }

    public void ShowInfo(TileController tileController)
    {
        if (tileController.IsOccupied)
        {
            Controller.InfoLabel.text = "Cannot build here";
        }
        else if (Controller.Gold < 50)
        {
            Controller.InfoLabel.text = "<color=red>Not Enough Gold</color>";
        }
        else
        {
            Controller.InfoLabel.text = "50 Gold - Place Turret";
        }
    }

    public void ShowSelectTile(TileController tileController)
    {
        Controller.InfoLabel.text = "Select a Tile";
    }
}