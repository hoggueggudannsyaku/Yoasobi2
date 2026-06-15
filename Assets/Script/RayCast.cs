using UnityEngine;

public class ForwardRaycast : MonoBehaviour
{
    public float rayDistance = 5f; // Rayの長さ

    void Update()
    {
        // Rayの情報を保存する変数
        RaycastHit hit;

        // transform.position から transform.forward 方向へ Ray を飛ばす
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance))
        {
            Debug.Log("Ray が当たった相手: " + hit.collider.name);
        }

        // Sceneビューで可視化（デバッグ用）
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
    }
}
