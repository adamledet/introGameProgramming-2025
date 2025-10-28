using System.Collections.Specialized;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public interface IStealth
{
    bool IsCrouched();
    void Notify(IDetector enemy);
    Transform getTransform();
}
