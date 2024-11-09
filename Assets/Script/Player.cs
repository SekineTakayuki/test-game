using System.Collections;
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

        public bool IsGoal { get; set; } = false;
        public void Init()
        {
            // 操作設定
            Observable.EveryUpdate()
                .Where(_ => !IsGoal)
                .Where(_ => (Input.GetAxis("Horizontal") != 0) || (Input.GetAxis("Vertical") != 0))
                .Subscribe(_ =>
                {
                    Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
                }).AddTo(this);

            // 開始位置に設定
            var startPos = MapDataManager.Instance.GetStartPos();
            transform.position = startPos;
        }

        /// <summary>
        /// プレイヤー移動
        /// </summary>
        private void Move(Vector2 moveVec)
        {
            var moveParam = new Vector2(moveVec.x * moveSpeed, moveVec.y * moveSpeed);
            transform.position += new Vector3(moveParam.x * Time.deltaTime, moveParam.y * Time.deltaTime);
        }
    }
}