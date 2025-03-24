using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FallingRockInteractable : MonoBehaviour
{
    [SerializeField]
    [Tooltip("If true, the rock will fall when grabbed.")]
    private bool m_IsUnstable = true;

    private Rigidbody rb;
    private bool hasFallen = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // Keep it static until grabbed
        rb.useGravity = false;
    }

    public void OnGrabbed()
    {
        if (m_IsUnstable && !hasFallen)
        {
            rb.isKinematic = false; // Enable physics
            rb.useGravity = true;
            rb.AddForce(Vector3.down * 2f, ForceMode.Impulse); // Optional initial push
            hasFallen = true; // Prevent multiple falls
        }
    }
}
