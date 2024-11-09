using UnityEngine;
using R3;

namespace DungeonGame
{
    /// <summary>
    /// 操作キャラ
    /// </summary>
    public class Player : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 2.2f;

        private Subject<Vector2> updatePositionSubject;
        public Observable<Vector2> UpdatePositionAsObservable
            => updatePositionSubject;

        public bool IsStopPlayer { get; set; } = false;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Init()
        {
            // 操作設定
            Observable.EveryUpdate()
                .Where(_ => !IsStopPlayer)
                .Where(_ => (Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
                .Subscribe(_ =>
                {
                    Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
                }).AddTo(this);

            // 開始位置に設定
            var startPos = MapDataManager.Instance.GetStartPos();
            transform.position = startPos;

            // 位置の通知設定
            updatePositionSubject = new Subject<Vector2>().AddTo(this);
        }

        /// <summary>
        /// プレイヤー移動
        /// </summary>
        private void Move(Vector2 _moveVec)
        {
            var moveParam = new Vector2(_moveVec.x * moveSpeed, _moveVec.y * moveSpeed);
            transform.position += new Vector3(moveParam.x * Time.deltaTime, moveParam.y * Time.deltaTime);

            // 位置を更新
            updatePositionSubject.OnNext(transform.position);
        }
    }
}