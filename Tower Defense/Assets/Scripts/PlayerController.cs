using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [field: SerializeField]
    public int Gold { get; set; } = 200;

    [field: SerializeField]
    public TextMeshProUGUI InfoLabel { get; private set; }

    void Start()
    {
        InfoLabel.text = "Click Build to Place a Turret";
    }
}