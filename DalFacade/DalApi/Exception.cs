using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DalApi;

[Serializable]
public class ObjExistException : Exception
{
    public ObjExistException() : base() { }
    public ObjExistException(string message) : base(message) { }
    public ObjExistException(string message, Exception inner) : base(message, inner) { }
    protected ObjExistException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}

[Serializable]
public class ObjNotExistException : Exception
{
    public ObjNotExistException() : base() { }
    public ObjNotExistException(string message) : base(message) { }
    public ObjNotExistException(string message, Exception inner) : base(message, inner) { }
    protected ObjNotExistException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
