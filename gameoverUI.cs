using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    // コンティニュー（ゲームを再開）
    public void OnContinueButton()
    {
        // 例：ゲームのメインシーンに戻る
        SceneManager.LoadScene("MainScene");
    }

    // ゲームを終了する
    public void OnQuitButton()
    {
        // Unityエディタでは終了しないので注意
        Application.Quit();
    }
}
