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

namespace MyAspx.Json.Conversion
{
    using System;
    using System.ComponentModel;
    
    /// <summary>
    /// Marks a type, typically an attribute, as a customization targeting
    /// a <see cref="PropertyDescriptor"/>.
    /// </summary>

    public interface IPropertyDescriptorCustomization
    {
        void Apply(PropertyDescriptor property);
    }
    
    /// <summary>
    /// Defines getter and setter methods that encapsulate a property 
    /// implementation.
    /// </summary>

    public interface IPropertyImpl
    {
        object GetValue(object obj);
        void SetValue(object obj, object value);
    }
    
    /// <summary>
    /// Advertises a property that can be customized at run-time.
    /// </summary>

    public interface IPropertyCustomization
    {
        void SetName(string name);
        void SetType(Type type);
        IPropertyImpl OverrideImpl(IPropertyImpl impl);
    }
}