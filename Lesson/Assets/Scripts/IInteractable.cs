using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{
    public interface IInteractable : IAction
    {
        bool IsInteractable { get; }
    }
}