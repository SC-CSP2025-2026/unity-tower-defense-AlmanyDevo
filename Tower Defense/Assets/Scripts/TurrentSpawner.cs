using UnityEngine;

public class TurrentSpawner : MonoBehaviour
{
    [field: SerializeField]
    public GameObject TurrentPrefab { get; private set;}

    public void SpawnTurrent(TileController TileController)
    {
        if(TileController.IsOccupied) { return ;}
        GameObject newTurrent = Instantiate(TurrentPrefab);
        newTurrent.transform.position = TileController.transform.position;
    }
}
