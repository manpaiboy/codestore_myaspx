#region License, Terms and Conditions
//
// Maticsoft - JSON and JSON-RPC for Microsoft .NET Framework and Mono
//
// Copyright (c) 2006-2012 Maticsoft. All Rights Reserved.
//
// This library is free software; you can redistribute it and/or modify it under
// the terms of the GNU Lesser General Public License as published by the Free
// Software Foundation; either version 3 of the License, or (at your option)
// any later version.
//
// This library is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public License for more
// details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this library; if not, write to the Free Software Foundation, Inc.,
// 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA 
//
#endregion

using System;
using System.Collections;

namespace MyAspx.Json.RPC
{
    #region Imports

    

    #endregion

    /// <summary> 
    /// Helper methods for collections. This type supports the
    /// Maticsoft infrastructure and is not intended to be used directly from
    /// your code. 
    /// </summary>
    
    public sealed class CollectionHelper
    {
        private static readonly object[] _zeroObjects = new object[0];
        
        public static object[] ToArray(ICollection collection)
        {
            if (collection == null)
                return _zeroObjects;

            object[] values = new object[collection.Count];
            collection.CopyTo(values, 0);
            return values;
        }
        
        public static Array ToArray(ICollection collection, Type elementType)
        {
            if (elementType == null)
                elementType = typeof(object);
            
            if (collection == null)
                return _zeroObjects;

            return (new ArrayList(collection)).ToArray(elementType);
        }
        
        public static IList ToList(ICollection collection)
        {
            return collection != null ? new ArrayList(collection) : new ArrayList();
        }

        private CollectionHelper()
        {
            throw new NotSupportedException();
        }
    }
}
