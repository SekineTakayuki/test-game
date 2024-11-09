using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace DungeonGame
{
    /// <summary>
    /// マップデータマネージャー
    /// </summary>
    public class MapDataManager
    {
        private const string CSV_PATH = "Assets/CSV/MapData.csv";

        // シングルトン
        private static MapDataManager instance;
        public static MapDataManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MapDataManager();
                }
                return instance;
            }
        }

        public static void DestoryInstance()
        {
            instance = null;
        }

        private List<MapData> mapDataList;

        /// <summary>
        /// マップデータ読み込み
        /// </summary>
        public void LoadData()
        {
            mapDataList = new List<MapData>();
            var csvLineList = new List<string>(File.ReadAllLines(CSV_PATH));
            csvLineList.RemoveAt(0);
            foreach (var line in csvLineList)
            {
                var items = line.Split(',');
                var mapData = new MapData(
                        int.Parse(items[0]),
                        int.Parse(items[1]),
                        float.Parse(items[2]),
                        float.Parse(items[3]),
                        float.Parse(items[4])
                    );
                mapDataList.Add(mapData);
            }
        }

        /// <summary>
        /// ブロック情報取得
        /// </summary>
        public MapData[] GetBlockPos()
        {
            var blockData = mapDataList
                             .Where(x => x.ObjectType == MapData.MapObjectType.Block)
                             .ToArray();

            return blockData;
        }

        /// <summary>
        /// 開始位置取得
        /// </summary>
        public Vector2 GetStartPos()
        {
            var startData = mapDataList
                            .FirstOrDefault(x => x.ObjectType == MapData.MapObjectType.StartPoint);

            return startData.Potition;
        }

        /// <summary>
        /// ゴール位置取得
        /// </summary>
        public Vector2 GetGoalPos()
        {
            var goalData = mapDataList
                            .FirstOrDefault(x => x.ObjectType == MapData.MapObjectType.GoalPoint);
            return goalData.Potition;
        }
    }
}