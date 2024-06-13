

using UnityEngine;

public interface IStackable
{
    public void OnStack(GameObject bed) { }
    public bool CanStack(GameObject bed);
}
