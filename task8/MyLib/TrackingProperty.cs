using System;

namespace MyLib
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TrackingProperty : Attribute
    {
        public object PropertyName { get; set; }

        public TrackingProperty()
        {

        }

        public TrackingProperty(object obj)
        {
            PropertyName = obj;
        }
    }
}
