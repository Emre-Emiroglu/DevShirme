using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public class ADModel : IADModel
    {
        private readonly ADSettings adSettings;

        public ADSettings ADSettings => adSettings;

        public ADModel()
        {
            adSettings = Resources.Load<ADSettings>("Settings/ADSettings");
        }
    }
}
