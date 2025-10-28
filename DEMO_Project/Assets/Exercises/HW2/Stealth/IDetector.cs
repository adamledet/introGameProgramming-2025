using UnityEngine;

public interface IDetector
{
    Transform GetTransform();
    void Backstab();
    void GetHit();
    bool IsUnaware();
}
