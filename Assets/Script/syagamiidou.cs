using UnityEngine;

public class PlayerMoveWithCrouch : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cameraTransform;

    public float normalSpeed = 5f;        // 通常の加える力
    public float crouchSpeed = 2.5f;      // しゃがみ時の加える力

    public float normalCameraHeight = 1.6f;   // 通常視点
    public float crouchCameraHeight = 0.8f;   // しゃがみ視点

    public float normalMaxSpeed = 5f;     // 通常時の最高速度
    public float crouchMaxSpeed = 2f;     // しゃがみ時の最高速度

    private bool isCrouching = false;

    void Update()
    {
        // しゃがみ判定（Shift押しっぱなし）
        isCrouching = Input.GetKey(KeyCode.LeftShift);

        // カメラの高さ変更
        Vector3 camPos = cameraTransform.localPosition;
        camPos.y = isCrouching ? crouchCameraHeight : normalCameraHeight;
        cameraTransform.localPosition = camPos;

        // 移動速度（加える力）を切り替え
        float speed = isCrouching ? crouchSpeed : normalSpeed;

        // AddForceで移動
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(transform.forward * speed, ForceMode.Force);

        if (Input.GetKey(KeyCode.S))
            rb.AddForce(-transform.forward * speed, ForceMode.Force);

        // 左右回転
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -2f, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, 2f, 0);

        // ▼▼▼ ここが重要：最高速度を制限する ▼▼▼
        LimitSpeed();
    }

    void LimitSpeed()
    {
        float maxSpeed = isCrouching ? crouchMaxSpeed : normalMaxSpeed;

        // 水平方向の速度だけを見る（上下は無視）
        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        if (horizontalVelocity.magnitude > maxSpeed)
        {
            // 最高速度に制限
            Vector3 limited = horizontalVelocity.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(limited.x, rb.linearVelocity.y, limited.z);
        }
    }
}
