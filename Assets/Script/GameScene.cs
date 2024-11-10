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
        [SerializeField] private BlackOutGimmick blackOutGimmick;
        [SerializeField] private CountDownView countDownView;

        void Start()
        {
            // マップ生成
            mapCreator.CreateMap();
            var goalObject = mapCreator.GoalPointObject;
            goalObject.OnGoalAsObservable.Subscribe(_ =>
            {
                // ゴール時の処理
                ShowClearAsync().Forget();
            }).AddTo(this);

            // 暗闇ギミック
            blackOutGimmick.Init();

            // プレイヤー
            player.Init();
            player.UpdatePositionAsObservable.Subscribe(x =>
            {
                // 移動したらマスクも動かす
                blackOutGimmick.SetMaskPos(x);
            }).AddTo(this);

            // スタート時のカウントダウン
            countDownView.Init();
            countDownView.CompleteCountDownAsObservable.Subscribe(_ =>
            {
                // カウントダウン終了
                player.StartMove();
                blackOutGimmick.EnableBlackOut(true);
            }).AddTo(this);
            countDownView.StartCountDownAsync().Forget();
        }

        /// <summary>
        /// クリア表示
        /// </summary>
        private async UniTask ShowClearAsync()
        {
            player.StopMove();
            blackOutGimmick.EnableBlackOut(false);
            clearCanvasGroup.alpha = 1f;

            // 3秒後にタイトルへ
            await UniTask.Delay(TimeSpan.FromSeconds(3f));

            SceneManager.LoadScene("TitleScene");
        }

        private void OnDestroy()
        {
            MapDataManager.DestoryInstance();
        }

    }
}