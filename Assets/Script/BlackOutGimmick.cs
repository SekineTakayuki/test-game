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
            SetBlackOut(false);
            SetMaskPos(MapDataManager.Instance.GetStartPos());
        }

        /// <summary>
        /// 暗闇設定
        /// </summary>
        public void SetBlackOut(bool _isActive)
        {
            gameObject.SetActive(_isActive);
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