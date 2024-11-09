using UnityEngine;
using UnityEngine.UI;
using R3;
using UnityEngine.SceneManagement;

namespace DungeonGame
{
    /// <summary>
    /// �^�C�g�����
    /// </summary>
    public class TitleScene : MonoBehaviour
    {
        [SerializeField] private Button startButton;

        void Start()
        {
            // �Q�[���{�҂֑J��
            startButton.OnClickAsObservable().Subscribe(_ =>
            {
                SceneManager.LoadScene("MainGame");
            }).AddTo(this);
        }
    }
}
