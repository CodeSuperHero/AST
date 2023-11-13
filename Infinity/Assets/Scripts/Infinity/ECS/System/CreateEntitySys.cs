using Assets.HeroEditor.Common.Scripts.ExampleScripts;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using static Infinity.ECS.Authoring.HumanAuthoring;

namespace Assets.Scripts.Infinity.ECS.System
{
    public partial struct CreateEntitySys : ISystem
    {
        
        void OnCreate(ref SystemState state)
        {
        }

        void OnDestroy(ref SystemState state)
        {
        }

        void OnUpdate(ref SystemState state)
        {
            var sys = SystemAPI.GetSingleton<EndSimulationEntityCommandBufferSystem.Singleton>();
            var ecb = sys.CreateCommandBuffer(state.WorldUnmanaged);
            foreach (var item in SystemAPI.Query<HumanProperty>())
            {
                var random = Random.CreateFromIndex(1024);
                var units = state.EntityManager.Instantiate(item.human, 500, Allocator.Temp);
                for (int i = 0; i < units.Length; i++)
                {
                    var entity = ecb.Instantiate(item.human);
                    var v = random.NextFloat();
                    ecb.AddComponent(entity, LocalTransform.FromPosition(new float3(v * 10.8f - 5.4f, v * 19.20f - 9.6f, 0f)));
                    //ecb.AddComponent(entity, LocalTransform.FromPosition(new float3(v * 10.8f - 5.4f, v * 19.20f - 9.6f, 0f)));

                }
            }
            state.Enabled = false;
        }
    }
}