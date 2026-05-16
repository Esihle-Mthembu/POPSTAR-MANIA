using UnityEngine;
using UnityEngine.InputSystem;

// =================================
// Define namespace.
// =================================

namespace MirzaBeig 
{ 

    namespace ParicleSystems 
    { 
    
    
        namespace Demos
        {

            // ==============================
            // classes.
            // ==============================

            //[ExecuteInEditMode]
            [System.Serializable]

            //[RequireComponent(typeof(TrialRenderer))]

            public class FollowMouse : MonoBehaviour
            {
                // ===============================
                // Nested Classes and Structures
                // ===============================

                // ...

                // ===============================
                // Variables.
                // ===============================

                // ...

                public float speed = 8.0f;
                public float distanceFromCamera = 5.0f;

                // ================================
                // Functions.
                // ================================

                // ...

                void Awake()
                {

                }

                // ...

                void Start()
                {

                }

                // ...

                void Update()
                {
                    Vector3 mousePosition = Mouse.current.position.ReadValue();
                    mousePosition.z = distanceFromCamera;

                    Vector3 mouseScreenToWorld = Camera.main.ScreenToWorldPoint(mousePosition);

                    Vector3 position = Vector3.Lerp(transform.position, mouseScreenToWorld, 1.0f - Mathf.Exp(-speed * Time.deltaTime));
                  
                    transform.position = position;
                }
                 
                // ...

                void LateUpdate()
                {

                }

            // ================================
            // End functions.
            // ================================
                
            }

            // ================================
            // End namespace.
            // ================================

        }

    }

}

// ================================
// --End-- //
// ================================