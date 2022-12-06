using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.UIModule
{
    public class LevelTextView : TextView
    {
        public override void SetText()
        {
        }
        public override void SetText(int level)
        {
            text.SetText("Level " + level.ToString());
        }
    }
}

