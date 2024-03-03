using ScreenManagerModule.Interface.Interfaces;
using UnityEngine;
using UnityEngine.Events;
namespace ScreenManagerModule.Interface.Entities
{
    public class ViewBase : MonoBehaviour, IView
    {
        public void Destroy() => Destroy(gameObject);
    }
}
