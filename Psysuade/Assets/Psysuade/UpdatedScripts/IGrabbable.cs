using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbable
{
    public void Grab();

    public bool CanGrab();
}
