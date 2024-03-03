using UnityEngine;
namespace ScreenManagerModule.System.Components
{
    public class RootScreensCanvas : MonoBehaviour
    {
        [SerializeField] private Canvas canvas;
        [SerializeField] private Transform standardLayer;
        [SerializeField] private Transform topLayer;
        
        public Canvas Canvas => canvas;
        public Transform StandardLayer => standardLayer;
        public Transform TopLayer => topLayer;
    }
}
