using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform player;

    [Header("Position")]
    [SerializeField] private Vector3 offset = new Vector3(0, 6, -8);

    [Header("Follow settings")]
    [Range(0.1f, 10f)]
    [SerializeField] private float followSpeed = 2f;

    private void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPosition = player.position + offset;

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            followSpeed * Time.deltaTime
        );
    }
}
