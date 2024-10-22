using System;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

namespace fsi.cutscene.Shots
{
    [Serializable]
    public class Shot
    {
        [SerializeField]
        private CinemachineCamera camera;

        [SerializeField]
        private List<CharacterShot> characterShots = new List<CharacterShot>();
        
        public void Enter()
        {
            camera.gameObject.SetActive(true);

            foreach (var cShot in characterShots)
            {
                cShot.Enter();
            }
        }

        public void Exit()
        {
            camera.gameObject.SetActive(false);

            foreach (var cShot in characterShots)
            {
                cShot.Exit();
            }
        }
    }
}