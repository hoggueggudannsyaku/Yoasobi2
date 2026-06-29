using UnityEngine;

public class LightSwitchF : MonoBehaviour
{
    private Light pointLight;

    void Start()
    {
        pointLight = GetComponent<Light>();
    }

    void Update()
    {
        // FキーでON/OFF切り替え
        if (Input.GetKeyDown(KeyCode.F))
        {
            pointLight.enabled = !pointLight.enabled;
        }
    }
}
