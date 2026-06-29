using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHit : MonoBehaviour
{
    public CanvasGroup fadeCanvas;   // 暗転用のCanvasGroup
    public float fadeTime = 3f;      // 暗転までの時間（3秒）

    private bool isHit = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isHit)
        {
            isHit = true;
            StartCoroutine(FadeAndGameOver());
        }
    }

    private IEnumerator FadeAndGameOver()
    {
        float t = 0;

        // 3秒かけて暗転
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            fadeCanvas.alpha = t / fadeTime;  // 0 → 1 に変化
            yield return null;
        }

        // 暗転後にゲームオーバーシーンへ移行
        SceneManager.LoadScene("GameOver");
    }
}
