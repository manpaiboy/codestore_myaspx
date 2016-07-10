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
using System.Runtime.Serialization;
using XM.Json;
using MyAspx.Json.Common;
using MyAspx.Json.RPC.JsonRpc;

namespace MyAspx.Json.RPC.JsonRpc
{
    #region Imports

    

    #endregion

    [ Serializable ]
    public class BadRequestException : JsonRpcException
    {
        private const string _defaultMessage = "Invalid JSON-RPC request.";

        private readonly object _request;

        public BadRequestException() : this((string) null) {}

        public BadRequestException(Exception innerException) :
            base(_defaultMessage, innerException) {}

        public BadRequestException(string message) : 
            base((string) Mask.NullString(message, _defaultMessage)) {}

        public BadRequestException(string message, Exception innerException) :
            this(message, innerException, null) {}

        public BadRequestException(string message, Exception innerException, object request) :
            base(Mask.NullString(message, _defaultMessage), innerException)
        {
            _request = request;
        }

        protected BadRequestException(SerializationInfo info, StreamingContext context) :
            base(info, context) {}

        public object Request
        {
            get { return _request; }
        }
    }
}