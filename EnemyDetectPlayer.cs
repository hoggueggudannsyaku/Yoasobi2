using UnityEngine;

public class EnemyDetectPlayer : MonoBehaviour
{
    public float rayDistance = 10f;      // Rayの長さ
    public Transform eyePoint;           // 敵の目の位置（任意）
    public LayerMask targetLayer;        // Playerレイヤーを指定
    private Transform playerTarget;      // 見つけたプレイヤーのTransform

    void Update()
    {
        RaycastHit hit;

        // Rayを飛ばす位置（eyePointがあればそこから）
        Vector3 origin = eyePoint ? eyePoint.position : transform.position;
        Vector3 direction = eyePoint ? eyePoint.forward : transform.forward;

        // Raycast実行
        if (Physics.Raycast(origin, direction, out hit, rayDistance, targetLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                // プレイヤーのTransformを取得し続ける
                playerTarget = hit.collider.transform;

                Debug.Log("Player発見！位置: " + playerTarget.position);
            }
        }
        else
        {
            // 見失ったら null にする（必要なら）
            playerTarget = null;
        }

        // デバッグRay
        Debug.DrawRay(origin, direction * rayDistance, Color.red);
    }

    // 他のスクリプトからプレイヤー位置を使いたい場合
    public Vector3 GetPlayerPosition()
    {
        if (playerTarget != null)
            return playerTarget.position;

        return Vector3.zero;
    }
}
