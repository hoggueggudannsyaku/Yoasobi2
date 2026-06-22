using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float rayDistance = 10f;      // Rayの長さ
    public Transform eyePoint;           // 敵の目の位置
    public LayerMask targetLayer;        // Playerレイヤー
    public Transform destinationPoint;   // プレイヤー未発見時の目的地

    private Transform playerTarget;      // 見つけたプレイヤー
    private NavMeshAgent agent;          // NavMeshAgent

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        DetectPlayer();   // プレイヤーを探す
        MoveEnemy();      // 状況に応じて移動
    }

    // -------------------------
    // プレイヤー検知処理
    // -------------------------
    void DetectPlayer()
    {
        RaycastHit hit;

        Vector3 origin = eyePoint ? eyePoint.position : transform.position;
        Vector3 direction = eyePoint ? eyePoint.forward : transform.forward;

        if (Physics.Raycast(origin, direction, out hit, rayDistance, targetLayer))
        {
            if (hit.collider.CompareTag("Player"))
            {
                playerTarget = hit.collider.transform;
            }
        }
        else
        {
            playerTarget = null; // 見失ったら解除
        }

        Debug.DrawRay(origin, direction * rayDistance, Color.red);
    }

    // -------------------------
    // 移動処理
    // -------------------------
    void MoveEnemy()
    {
        if (playerTarget != null)
        {
            // プレイヤーを追跡
            agent.SetDestination(playerTarget.position);
        }
        else
        {
            // プレイヤー未発見 → 目的地へ移動
            if (destinationPoint != null)
            {
                agent.SetDestination(destinationPoint.position);
            }
        }
    }
}
