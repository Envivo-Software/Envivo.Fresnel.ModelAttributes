using System;

namespace Envivo.Fresnel.ModelAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public class UploadAttribute : Attribute
    {
        public UploadAttribute()
        {
        }

        public UploadAttribute(string accept)
        {
            this.Accept = accept;
        }

        public string Accept { get; set; }
    }
}