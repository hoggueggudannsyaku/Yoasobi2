using UnityEngine;

public class Door : MonoBehaviour
{
    bool DoorCheker = false;
    DoorSound doorSound;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorSound = GetComponent<DoorSound>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OpenDoor()
    {
        if (DoorCheker)
        {
            doorSound.SoundPlay();
        }
        else{
        doorSound.SoundPlay();
        }
    }
}
