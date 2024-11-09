using UnityEngine;
using UnityEngine.UI;
using R3;
using UnityEngine.SceneManagement;

namespace DungeonGame
{
    /// <summary>
    /// タイトル画面
    /// </summary>
    public class TitleScene : MonoBehaviour
    {
        [SerializeField] private Button startButton;

        void Start()
        {
            // ゲーム本編へ遷移
            startButton.OnClickAsObservable().Subscribe(_ =>
            {
                SceneManager.LoadScene("MainGame");
            }).AddTo(this);
        }
    }
}
