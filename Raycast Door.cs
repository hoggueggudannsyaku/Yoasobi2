using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public float rayDistance = 3f;     // どれくらい先まで判定するか
    public Transform cameraTransform;  // プレイヤーの視点（FPSならカメラ）

    void Update()
    {
        RaycastHit hit;

        // カメラの正面に Ray を飛ばす
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, rayDistance))
        {
            // 当たった相手が TagDoor なら
            if (hit.collider.CompareTag("TagDoor"))
            {
                // Eキーが押されたらドアを開く
                if (Input.GetKeyDown(KeyCode.E))
                {
                    // ドアのスクリプトを取得して開く
                    Door door = hit.collider.GetComponent<Door>();
                    if (door != null)
                    {
                        door.OpenDoor();
                    }
                }
            }
        }

        // デバッグ用に Ray を表示
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * rayDistance, Color.yellow);
    }
}
