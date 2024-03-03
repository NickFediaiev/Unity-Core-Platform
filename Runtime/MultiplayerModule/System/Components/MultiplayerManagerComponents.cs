using FishNet.Component.Spawning;
using FishNet.Example;
using FishNet.Managing;
using FishNet.Managing.Observing;
using FishNet.Transporting;
using UnityEngine;
namespace MultiplayerModule.System.Components
{
    public class MultiplayerManagerComponents : MonoBehaviour
    {
        [SerializeField] NetworkManager networkManager;
        [SerializeField] ObserverManager observerManager;
        [SerializeField] PlayerSpawner playerSpawner;
        [SerializeField] NetworkHudCanvases networkHudCanvases;
        [SerializeField] Transport transport;
    }
}
