using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargetLocator
{
    public Transform GetTarget(Vector3 currentPosition);

    public void RegisterTarget(Transform target);

    public void UnregisterTarget(Transform target);
}
