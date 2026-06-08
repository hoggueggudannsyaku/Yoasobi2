using UnityEngine;

public class MoveByForce : MonoBehaviour
{
    public float speed = 5f; // 加える力の大きさ
    Rigidbody rb;

    void Start()
    {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        

        // 前進（Wキー）
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(transform.forward * speed, ForceMode.Force);

        // 後退（Sキー）
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(-transform.forward * speed, ForceMode.Force);

        // 左右回転（A・Dキー）
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(0, -2f, 0);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(0, 2f, 0);
    }
}
