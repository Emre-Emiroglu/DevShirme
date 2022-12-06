using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.UIModule
{
    public class ScoreTextView : TextView
    {
        public override void SetText()
        {
        }
        public override void SetText(int amount)
        {
            text.SetText(amount.ToString());
        }
    }
}

