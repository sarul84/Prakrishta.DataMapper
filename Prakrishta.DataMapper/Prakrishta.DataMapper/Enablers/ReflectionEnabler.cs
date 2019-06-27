﻿//----------------------------------------------------------------------------------
// <copyright file="ReflectionEnabler.cs" company="Prakrishta Technologies">
//     Copyright (c) 2019 Prakrishta Technologies. All rights reserved.
// </copyright>
// <author>Arul Sengottaiyan</author>
// <date>6/28/2019</date>
// <summary>Class that has utility methods for the reflection.</summary>
//-----------------------------------------------------------------------------------

namespace Prakrishta.DataMapper.Enablers
{
    using System;
    using System.Reflection;

    /// <summary>
    /// Class that has utility methods for the reflection.
    /// </summary>
    internal static class ReflectionEnabler
    {
        #region |Methods|

        /// <summary>
        /// Gets the static Parse method for the specified type.
        /// </summary>
        /// <param name="type">The type to get Parse method.</param>
        /// <returns>A <see cref="MethodInfo"/> representing the Parse method or <c>null</c>, if type has no Parse method.</returns>
        public static MethodInfo GetParseMethod(Type type)
        {
            return type.GetMethod("Parse", BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(string) }, null);
        }

        /// <summary>
        /// Gets the static TryParse method for the specified type.
        /// </summary>
        /// <param name="type">The type to get TryParse method.</param>
        /// <returns>A <see cref="MethodInfo"/> representing the TryParse method or <c>null</c>, if type has no TryParse method.</returns>
        public static MethodInfo GetTryParseMethod(Type type)
        {
            return type.GetMethod("TryParse", BindingFlags.InvokeMethod | BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(string), type.MakeByRefType() }, null);
        }

        /// <summary>
        /// Determines if provided type supports parsing.
        /// </summary>
        /// <param name="type">A type to check.</param>
        /// <returns><c>true</c> usual static TryParse or Parse method; <c>false</c> otherwise.</returns>
        public static bool SupportsParsing(Type type)
        {
            var method = GetTryParseMethod(type);

            if (method != null)
            {
                return true;
            }

            method = GetParseMethod(type);

            if (method != null)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}