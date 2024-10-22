using System.Collections.Generic;
using fsi.cutscene.Shots;
using UnityEngine;

namespace fsi.cutscene
{
    public class Cutscene : MonoBehaviour
    {
        [SerializeField]
        private bool playOnAwake = true;
        
        [Header("Shots")]
        
        [SerializeField]
        private List<Shot> shots = new();
        
        private readonly Queue<Shot> shotQueue = new();
        
        // input

        private void Awake()
        {
            foreach (var shot in shots)
            {
                shotQueue.Enqueue(shot);
            }

            if (playOnAwake)
            {
                Play();
            }
        }

        public void Play()
        {
            NextShot();
        }

        private void NextShot()
        {
            Shot shot = shotQueue.Dequeue();
            shot.Enter();
        }
    }
}
