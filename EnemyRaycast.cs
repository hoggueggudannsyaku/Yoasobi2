using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    public float rayDistance = 10f; // Rayの長さ
    public LayerMask targetLayer;   // プレイヤーなど判定したいレイヤー

    void Update()
    {
        RaycastHit hit;

        // 敵の正面にRayを飛ばす
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, targetLayer))
        {
            Debug.Log("敵の正面にいるもの: " + hit.collider.name);
        }

        // Sceneビューで可視化
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
    }
}
