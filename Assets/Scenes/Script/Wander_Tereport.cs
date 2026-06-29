using UnityEngine;

public class Wander_Tereport : MonoBehaviour
{
    [SerializeField]private int tereportPos_Min_X;
    [SerializeField]private int tereportPos_Max_X;
    [SerializeField]private int tereportPos_Min_Z;
    [SerializeField]private int tereportPos_Max_Z;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            int tereportPosX = Random.Range(tereportPos_Min_X,tereportPos_Max_X+1);
            int tereportPosY = Random.Range(tereportPos_Min_Z,tereportPos_Max_Z+1);
            this.gameObject.transform.position =new Vector3 (tereportPosX,transform.position.y,tereportPosY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
