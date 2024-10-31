using System;
using UnityEngine;

namespace _Scripts.Core
{
    /// <summary>
    /// This class is the base class for all 2D movement scripts.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(BoxCollider2D))]
    public abstract class Movement2D : MonoBehaviour
    {
        /// <summary>
        /// A reference to the Rigidbody2D component and is accessed by the derived classes.
        /// </summary>
        protected Rigidbody2D Rb;
        /// <summary>
        /// A vector that represents the direction of movement and is accessed by the derived classes.
        /// </summary>
        internal Vector2 MovementDirection;
        /// <summary>
        /// A default speed value that can be changed in the inspector.
        /// </summary>
        public float speed = 1f;

        /// <summary>
        /// Awake is called when the script instance is being loaded and will reference the Rigidbody2D component.
        /// </summary>
        internal void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
        }
        
        /// <summary>
        /// Update is called once per frame and will move the object in the direction of the MovementDirection vector,
        /// and is accessed by the derived classes.
        /// </summary>
        protected void Update()
        {
            transform.position += (Vector3) MovementDirection * (speed * Time.deltaTime);
        }
    }
}
