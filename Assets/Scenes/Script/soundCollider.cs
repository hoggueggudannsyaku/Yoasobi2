using Unity.VisualScripting;
using UnityEngine;

public class soundCollider : MonoBehaviour
{
    private GameObject  target;
     // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float LastPosX = gameObject.transform.position.x;
        float LastPosZ = gameObject.transform.position.z;
        target = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = target.transform.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("enemy"))
        other.GetComponent<AINavMeshEnemy>().NowMode = AINavMeshEnemy.Mode.Seach;//ここが問題
    }
}
