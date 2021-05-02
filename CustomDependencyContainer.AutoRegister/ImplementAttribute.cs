using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDependencyContainer.AutoRegister
{
    /// <summary>
    /// Attribut permettant l'implémentation d'une interface définie dans le projet
    /// </summary>
    public class ImplementAttribute : Attribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromType">typeOf(Interface à implémenter)</param>
        public ImplementAttribute(Type fromType)
        {
            if (fromType == null)
            {
                throw new ArgumentNullException(nameof(fromType));
            }

            FromType = fromType;
        }

        public Type FromType { get; protected set; }
    }
}
