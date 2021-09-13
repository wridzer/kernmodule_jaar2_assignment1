using UnityEngine;

namespace InterfaceTest
{
    public delegate void ViewChanged( float zoom );

    public interface IControllable : IViewable
    {
        bool isViewable { get; }

        void Enter();
        void Exit();

        void HandleInput(float h, float v);
    }

    public interface IViewable
    {
        Vector3 Position { get; }
        float Zoom{ get; }
    }
}