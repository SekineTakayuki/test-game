using Cysharp.Threading.Tasks;
using R3;
using System;
using TMPro;
using UnityEngine;

namespace DungeonGame
{
    /// <summary>
    /// スタート時のカウントダウン
    /// </summary>
    public class CountDownView : MonoBehaviour
    {
        [SerializeField] private int countDown = 3;
        [SerializeField] private TMP_Text countDownText;
        [SerializeField] private CanvasGroup countCanvasGroup;

        private Subject<Unit> completeCountDownSubject;
        public Observable<Unit> CompleteCountDownAsObservable
            => completeCountDownSubject;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Init()
        {
            countDownText.text = countDown.ToString();

            completeCountDownSubject = new Subject<Unit>().AddTo(this);
        }

        /// <summary>
        /// カウントダウン開始
        /// </summary>
        public async UniTask StartCountDownAsync()
        {
            countCanvasGroup.alpha = 1f;

            for (int i = countDown; i > 0; i--)
            {
                countDownText.text = i.ToString();

                await UniTask.Delay(TimeSpan.FromSeconds(1f));
            }

            countCanvasGroup.alpha = 0f;

            // 完了を通知
            completeCountDownSubject.OnNext(Unit.Default);
        }
    }
}