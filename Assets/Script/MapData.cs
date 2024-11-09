using UnityEngine;

namespace DungeonGame
{
    /// <summary>
    /// マップデータ
    /// </summary>
    public class MapData
    {
        public enum MapObjectType
        {
            None = 0,
            StartPoint,
            GoalPoint,
            Block
        }

        public readonly int Id;
        public readonly MapObjectType ObjectType;
        public readonly Vector2 Potition;
        public readonly float Rotate;

        public MapData(int _id, int _mapObjectType, float _posX, float _posY, float _rotate)
        {
            Id = _id;
            ObjectType = (MapObjectType)_mapObjectType;
            Potition = new Vector2(_posX, _posY);
            Rotate = _rotate;
        }
    }
}