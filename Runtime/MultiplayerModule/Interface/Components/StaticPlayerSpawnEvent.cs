using System;
using FishNet.Object;
namespace MultiplayerModule.Interface.Components
{
    public static class StaticPlayerSpawnEvent
    {
        public static event Action<NetworkObject> OnPlayerSpawn;
        
        public static void InvokeOnPlayerSpawn(NetworkObject nob)
        {
            OnPlayerSpawn?.Invoke(nob);
        }
    }
}
