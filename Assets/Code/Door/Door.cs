using System;
using UnityEngine;

namespace Code.Door
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Signaling _signaling;
        
        private void OnCollisionEnter2D(Collision2D col)
        {
            _signaling.RaiseVolume();
        }
        
        private void OnCollisionExit2D(Collision2D col)
        {
            _signaling.LowerVolume();
        }
    }
}
