using UnityEngine;

namespace DungeonGame
{
    /// <summary>
    /// マップ生成クラス
    /// </summary>
    public class MapCreator : MonoBehaviour
    {
        private const string START_POINT_PATH = "Prefab/StartPoint";
        private const string GOAL_POINT_PATH = "Prefab/GoalPoint";
        private const string BLOCK_PATH = "Prefab/Block";

        [SerializeField] private Transform objectParent;

        public GoalObject GoalPointObject { get; private set; } = null;

        /// <summary>
        /// マップ生成
        /// </summary>
        public void CreateMap()
        {
            MapDataManager.Instance.LoadData();

            CreateMapObject();
        }

        /// <summary>
        /// マップ上の設置物設定
        /// </summary>
        private void CreateMapObject()
        {
            // ブロック
            var blockObject = Resources.Load<GameObject>(BLOCK_PATH);
            var blockDataArray = MapDataManager.Instance.GetBlockPos();
            foreach (var blockData in blockDataArray)
            {
                Instantiate(blockObject, blockData.Potition, Quaternion.Euler(0,0, blockData.Rotate), objectParent);
            }

            // スタート
            var startObject = Resources.Load<GameObject>(START_POINT_PATH);
            var startPos = MapDataManager.Instance.GetStartPos();
            Instantiate(startObject, startPos, Quaternion.identity, objectParent);

            // ゴール
            var goalObject = Resources.Load<GameObject>(GOAL_POINT_PATH);
            var goalPos = MapDataManager.Instance.GetGoalPos();
            GoalPointObject = Instantiate(goalObject, goalPos, Quaternion.identity, objectParent).GetComponent<GoalObject>();
            GoalPointObject.Init();
        }
    }
}