using R3;
using UnityEngine;

namespace DungeonGame
{
    public class GoalObject : MonoBehaviour
    {
        private Subject<Unit> goalSubject;
        public Observable<Unit> OnGoalAsObservable
            => goalSubject;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Init()
        {
            goalSubject = new Subject<Unit>().AddTo(this);
        }

        void OnTriggerEnter2D(Collider2D _other)
        {
            // ゴールを通知
            goalSubject.OnNext(Unit.Default);
        }
    }
}