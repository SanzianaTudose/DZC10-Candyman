using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Invector.vCharacterController
{
    public class DetectPlayer : MonoBehaviour
    {
        public Rigidbody characterControllerRb;
        private int buttonCount = 0;

        private void Start()
        {
           
        }

        private void Update()
        {
            Debug.Log(buttonCount);
        }



        private void OnTriggerEnter(Collider other)
        {
            
            Debug.Log("wow");
            if (other.gameObject.CompareTag("Player"))
            {
                characterControllerRb.constraints = RigidbodyConstraints.FreezeAll;
                
            }
               
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.gameObject.CompareTag("Player"))
            {
                if (Input.GetKey(KeyCode.F))
                {
                    buttonCount++;

                    if(buttonCount > 10)
                    {
                        Debug.Log("got free!");
                        characterControllerRb.constraints = RigidbodyConstraints.None;
                    }
                }
            }
           
        }
    }
}

