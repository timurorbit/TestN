using System.Collections.Generic;
using UnityEngine;

namespace MageDefence
{
   public class TargetLocatorClosest : ITargetLocator
   {
       private List<Transform> _potentialTargets = new();
       public Transform GetTarget(Vector3 enemyPosition)
       {
           if (_potentialTargets.Count == 0)
           {
               return null; 
           }
           if (_potentialTargets.Count == 1)
           {
               return _potentialTargets[0];
           }
           return GetClosestTarget(enemyPosition);
       }
   
       private Transform GetClosestTarget(Vector3 enemyPosition)
       {
           Transform closest = null;
           float minDistance = Mathf.Infinity;
   
           foreach (var target in _potentialTargets)
           {
               if (!target) continue;
               
               float distance = Vector3.Distance(enemyPosition, target.position);
               if (distance < minDistance)
               {
                   minDistance = distance;
                   closest = target;
               }
           }
   
           return closest;
       }
   
       public void RegisterTarget(Transform target)
       {
           if (!_potentialTargets.Contains(target))
           {
               _potentialTargets.Add(target);
           }
       }
   
       public void UnregisterTarget(Transform target)
       {
           _potentialTargets.Remove(target);
       }
   } 
}