﻿using UnityEngine;
using System;
using System.Collections;

#if UNITY_EDITOR
using UnityEditor;

public class MinMaxRangeAttribute : Attribute
{
	public MinMaxRangeAttribute(float min, float max)
	{
		Min = min;
		Max = max;
	}
	public float Min { get; private set; }
	public float Max { get; private set; }
}
#endif