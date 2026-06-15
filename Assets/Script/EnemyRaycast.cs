using UnityEditor;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyRaycast : MonoBehaviour
{
    public float rayDistance = 1.0f;
    AINavMeshEnemy aI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        aI = GetComponent<AINavMeshEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        RayCastCheck();
    }
    private void RayCastCheck()
    {
        RaycastHit PlHit;
        Ray seachRay = new Ray(transform.position,transform.forward);
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);
        if(Physics.Raycast(seachRay,out PlHit, rayDistance))
        {
            if (PlHit.collider.gameObject.CompareTag("Player"))
            {
                aI.timer = 5.0f;
                aI.playermiss = false;
                aI.NowMode = AINavMeshEnemy.Mode.Chase;
            }
        }
    }
}
