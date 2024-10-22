using System;
using fsi.cutscene.Characters;
using UnityEngine;

namespace fsi.cutscene.Shots
{
    [Serializable]
    public class CharacterShot
    {
        [SerializeField]
        private Character character;

        [SerializeField]
        private string enterTrigger = "";
        
        [SerializeField]
        private string exitTrigger = "";

        [SerializeField]
        private bool shouldMove = false;

        [SerializeField]
        private Transform moveTarget;

        public void Enter()
        {
            character.SetTrigger(enterTrigger);
            if (shouldMove)
            {
                character.MoveTo(moveTarget.position);
            }
        }

        public void Exit()
        {
            character.SetTrigger(exitTrigger);
        }
    }
}