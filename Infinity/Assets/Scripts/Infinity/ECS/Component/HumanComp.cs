using Unity.Entities;
using UnityEngine;

namespace Infinity.ECS.Component
{
    public struct HumanComp : IComponentData
    {
        public float xWidth;
        public float yWidth;
        public float moveSpeed;
        public Entity human;
    }
}

