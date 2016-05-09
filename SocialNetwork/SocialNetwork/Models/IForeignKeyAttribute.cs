using System;

namespace SocialNetwork.Models
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class IForeignKeyAttribute : Attribute
    {
        public string Name { get; set; }
        /// <summary>
        /// Manages ForeignKeys for interfaces  
        /// </summary>
        /// <param name="name">Name of the ID Parameter</param>
        public IForeignKeyAttribute(string name)
        {
            this.Name = name;

            this.
        }
    }
}