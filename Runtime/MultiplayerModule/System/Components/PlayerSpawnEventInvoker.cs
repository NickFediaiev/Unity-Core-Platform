using FishNet.Object;
using MultiplayerModule.Interface.Components;
namespace MultiplayerModule.System.Components
{
    public class PlayerSpawnEventInvoker : NetworkBehaviour
    {
        public override void OnStartClient()
        {
            base.OnStartClient();

            if (!IsOwner)
                return;
            
            StaticPlayerSpawnEvent.InvokeOnPlayerSpawn(GetComponent<NetworkObject>());
        }
    }
}