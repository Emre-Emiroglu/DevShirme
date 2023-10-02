using DevShirme.Interfaces;
using DevShirme.Settings;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DevShirme.Models
{
    public interface IUIModel: IInitializable
    {
        public UISettings UISettings { get; }
    }
}
