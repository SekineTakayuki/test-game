using Cysharp.Threading.Tasks;
using R3;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DungeonGame
{
    /// <summary>
    /// ゲーム画面
    /// </summary>
    public class GameScene : MonoBehaviour
    {
        [SerializeField] private Player player;
        [SerializeField] private MapCreator mapCreator;
        [SerializeField] private CanvasGroup clearCanvasGroup;

        void Start()
        {
            mapCreator.CreateMap();
            var goalObject = mapCreator.GoalPointObject;
            goalObject.OnGoalAsObservable.Subscribe(_ =>
            {
                ShowClearAsync().Forget();
            }).AddTo(this);

            player.Init();
        }

        /// <summary>
        /// クリア表示
        /// </summary>
        private async UniTask ShowClearAsync()
        {
            player.IsGoal = true;
            clearCanvasGroup.alpha = 1;

            // 3秒後にタイトルへ
            await UniTask.Delay(TimeSpan.FromSeconds(3f));

            MapDataManager.DestoryInstance();

            SceneManager.LoadScene("TitleScene");
        }
        
    }
}