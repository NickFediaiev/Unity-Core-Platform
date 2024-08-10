using ScreenManagerModule.Interface.Interfaces;
using UnityEngine;
namespace ScreenManagerModule.Interface.Entities
{
    public class ViewBase : MonoBehaviour, IView
    {
        public void Destroy() => Destroy(gameObject);
    }
}
