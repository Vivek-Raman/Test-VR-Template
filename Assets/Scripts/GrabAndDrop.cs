using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class GrabAndDrop : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("test");
        }

        private void OnTriggerEnter(Collider other)
        {
            this.GetComponent<Renderer>().enabled = false;
        }

        private void OnTriggerExit(Collider other)
        {
            this.GetComponent<Renderer>().enabled = true;
        }
    }
}