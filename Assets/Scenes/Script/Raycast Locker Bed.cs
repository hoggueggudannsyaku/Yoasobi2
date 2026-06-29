using UnityEngine;

public class HideSystem : MonoBehaviour
{
    public float rayDistance = 3f;          // 判定距離
    public Transform cameraTransform;       // プレイヤーの視点（FPSカメラ）
    public bool isHiding = false;           // 隠れているかどうか

    void Update()
    {
        // すでに隠れている状態なら、Eキーで出る処理だけ行う
        if (isHiding)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ExitHide();
            }
            return;
        }

        RaycastHit hit;

        // カメラ正面に Ray を飛ばす
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, rayDistance))
        {
            // TagLocker または TagBed に当たっているか
            if (hit.collider.CompareTag("TagLocker") || hit.collider.CompareTag("TagBed"))
            {
                // Eキーが押されたら隠れる
                if (Input.GetKeyDown(KeyCode.E))
                {
                    EnterHide(hit.collider.gameObject);
                }
            }
        }

        // デバッグ用 Ray
        Debug.DrawRay(cameraTransform.position, cameraTransform.forward * rayDistance, Color.cyan);
    }

    void EnterHide(GameObject hideObject)
    {
        isHiding = true;

        // プレイヤーを非表示にする例（FPSならカメラだけ残す）
        // ここはゲーム仕様に合わせて変更してOK
        GetComponent<CharacterController>().enabled = false;
        transform.position = hideObject.transform.position; // ロッカーやベッドの中に移動
        Debug.Log("隠れた！");
    }

    void ExitHide()
    {
        isHiding = false;

        // プレイヤーを再表示
        GetComponent<CharacterController>().enabled = true;
        Debug.Log("隠れるのをやめた！");
    }
}
