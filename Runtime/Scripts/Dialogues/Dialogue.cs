using System;
using UnityEngine;

namespace fsi.cutscene.Dialogues
{
    [Serializable]
    public class Dialogue
    {
        [SerializeField]
        private string text;

        [SerializeField]
        private Sprite icon;
    }
}