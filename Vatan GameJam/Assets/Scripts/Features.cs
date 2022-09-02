using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Features
{
    public static string[] RAM { get; private set; } = new string[] { "4 GB RAM", "8 GB RAM", "16 GB RAM", "32 GB RAM", "64 GB RAM", "128 GB RAM" };
    public static string[] DebugMessages { get; private set; } = new string[] { "<color=\"red\"><size=70%><b><ERROR - Unknown product.></b><color=\"black\">" };
}