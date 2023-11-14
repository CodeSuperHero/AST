using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Infinity.ECS.Component
{
    public struct SpawnerComp : IComponentData
    {
        public Entity entity;

        public float3 position;

        public quaternion rotation;

        public float radius;

        public int num;
    }
}

