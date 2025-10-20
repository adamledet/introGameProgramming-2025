using System.Collections.Specialized;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public interface IStealth
{
    bool IsHidden();
    void Notify(IDetector enemy);
    Transform getTransform();
}
