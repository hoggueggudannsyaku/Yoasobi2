using UnityEngine;

public class DoorSound : MonoBehaviour
{
    public AudioClip test;
    [SerializeField]private GameObject soundCollider;
    [SerializeField]private GameObject sound;
    [SerializeField]private Transform EM;
    private Vector3 doorVec;
    AudioSource audioSource;
    private EnemySoundCheker EMSOUD;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        EMSOUD = GetComponent<EnemySoundCheker>();
        doorVec = new Vector3(gameObject.transform.position.x,gameObject.transform.position.y,gameObject.transform.position.z);
    }
    public void SoundPlay()
    {
        audioSource.PlayOneShot(test);
        Vector3 soundPOS=new Vector3(this.gameObject.transform.position.x, EM.transform.position.y,this.gameObject.transform.position.z);
        Instantiate(soundCollider,this.gameObject.transform.position,this.gameObject.transform.rotation);
        Instantiate(sound,soundPOS,transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
