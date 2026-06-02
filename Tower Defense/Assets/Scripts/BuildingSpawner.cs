using UnityEngine;

public class BuildingSpawner : MonoBehaviour
{
    [field: SerializeField]
    public BuildingData Selected { get; private set; }

    [field: SerializeField]
    public GameObject TargetGrid { get; private set; }

    [field: SerializeField]
    public PlayerController Controller { get; private set; }

    void OnEnable()
    {
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

        if (Controller.Gold < Selected.Cost)
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

        GameObject newTurrent = Instantiate(Selected.BuildingPrefab, Controller.transform);
        newTurrent.transform.position = TileController.transform.position;

        TileController.SetIsOccupied(true);
        Controller.Gold -= Selected.Cost;
    }

    public void ShowInfo(TileController tileController)
    {
        if (tileController.IsOccupied)
        {
            Controller.InfoLabel.text = "Cannot build here";
        }
        else if (Controller.Gold < Selected.Cost)
        {
            Controller.InfoLabel.text = "<color=red>Not Enough Gold</color>";
        }
        else
        {
            Controller.InfoLabel.text = $"{Selected.Cost} Gold - Place {Selected.name}";
        }
    }

    public void ShowSelectTile(TileController tileController)
    {
        Controller.InfoLabel.text = "Select a Tile";
    }
}