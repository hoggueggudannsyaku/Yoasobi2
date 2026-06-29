using UnityEngine;

public class SoundEmitter : MonoBehaviour
{
    public float moveThreshold = 0.1f;   // 動いたと判定する最小距離
    public float normalSoundRadius = 5f; // 通常時の音の大きさ
    public float crouchSoundRadius = 2f; // しゃがみ時の音の大きさ（小さめ）
    public LayerMask targetLayer;        // 敵など音を聞く対象のレイヤー

    public bool isCrouching = false;     // 外部（プレイヤー移動スクリプト）から更新する

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        float distanceMoved = Vector3.Distance(transform.position, lastPosition);

        // 動いたら音を発生
        if (distanceMoved > moveThreshold)
        {
            EmitSound();
        }

        lastPosition = transform.position;
    }

    void EmitSound()
    {
        // しゃがみ中は音を小さく
        float radius = isCrouching ? crouchSoundRadius : normalSoundRadius;

        Collider[] hits = Physics.OverlapSphere(transform.position, radius, targetLayer);

        foreach (Collider hit in hits)
        {
            hit.SendMessage("OnHearSound", transform.position, SendMessageOptions.DontRequireReceiver);
        }

        Debug.DrawRay(transform.position, Vector3.up * 0.1f, Color.yellow, 0.2f);
        Debug.Log("音を発生！ radius = " + radius);
    }
}
