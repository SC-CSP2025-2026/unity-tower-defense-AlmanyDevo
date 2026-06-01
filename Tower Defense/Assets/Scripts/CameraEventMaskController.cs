using UnityEngine;

public class CameraEventMaskController : MonoBehaviour
{
    [field: SerializeField]
    public LayerMask EventMask { get; private set; }
    
}
