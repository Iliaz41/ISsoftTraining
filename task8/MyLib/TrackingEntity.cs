﻿using System;

namespace MyLib
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class TrackingEntity : Attribute
    {
        public TrackingEntity()
        {

        }
    }
}
