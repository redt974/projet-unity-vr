using System;
using UnityEngine;
using UnityEngine.Events;

public class CanonButton : MonoBehaviour
{
    public Action<Collision> OnCollision;

    public CollisionUnityEvent OnCollisionEvent = new CollisionUnityEvent();

   [Serializable]
    public class CollisionUnityEvent : UnityEvent<Collision>
    {

    }
   void Update()
   {

   }

   public void OnExternalTrigger()
   {
      var collision = new Collision();
      OnCollision?.Invoke(collision);
      OnCollisionEvent?.Invoke(collision);
   }

   private void OnCollisionEnter(Collision other) 
   {
      Debug.Log("Percution " + gameObject.name);
      OnCollision?.Invoke(other);
      OnCollisionEvent?.Invoke(other);
   }
}
