using UnityEngine;

namespace DungeonGame
{
    /// <summary>
    /// 暗闇ギミック
    /// </summary>
    public class BlackOutGimmick : MonoBehaviour
    {
        [SerializeField] private Transform maskObjectTransform;

        /// <summary>
        /// 初期化
        /// </summary>
        public void Init()
        {
            EnableBlackOut(false);
            SetMaskPos(MapDataManager.Instance.GetStartPos());
        }

        /// <summary>
        /// 暗闇設定
        /// </summary>
        public void EnableBlackOut(bool _isEnable)
        {
            gameObject.SetActive(_isEnable);
        }

        /// <summary>
        /// マスク位置設定
        /// </summary>
        public void SetMaskPos(Vector2 _pos)
        {
            maskObjectTransform.position = new Vector2(_pos.x, _pos.y);
        }
    }
}