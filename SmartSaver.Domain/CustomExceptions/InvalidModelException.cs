﻿using System;

namespace SmartSaver.Domain.CustomExceptions
{
    [Serializable]
    public class InvalidModelException : Exception
    {
        public InvalidModelException() : base() {}
        public InvalidModelException(string message) : base(message) {}
        public InvalidModelException(string message, Exception inner) : base(message, inner) { }
        protected InvalidModelException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        public override string StackTrace { get ; }
    }
}
