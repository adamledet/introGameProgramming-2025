using System.Collections.Specialized;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public interface IStealth
{
    bool IsHidden();
    void Notify(Transform enemy);
    Transform getTransform();
}
