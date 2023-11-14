using Infinity.ECS.Component;
using Unity.Entities;
using UnityEngine;

namespace Infinity.ECS.Authoring
{
    public class HumanSpawnerAuthoring : Spawner
    {
        public float xWidth;
        public float yWidth;
        public float moveSpeed;

        public class HumanAuthoringBaker : Baker<HumanSpawnerAuthoring>
        {
            public override void Bake(HumanSpawnerAuthoring authoring)
            {
                //var humanEntity = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic);
                //AddComponent(humanEntity, new HumanComp
                //{
                //    xWidth = authoring.xWidth,
                //    yWidth = authoring.yWidth,
                //    moveSpeed = authoring.moveSpeed,
                //});

                var spawnerEntity = GetEntity(TransformUsageFlags.None);
                AddComponent(spawnerEntity, new SpawnerComp
                {
                    entity = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
                    position = authoring.transform.position,
                    rotation = authoring.transform.rotation,
                    radius = authoring.radius,
                    num = authoring.num
                });






                Destroy(authoring.gameObject);
            }
        }

    }

}
