
using System.Runtime.Serialization;

namespace BO;


[Serializable]
public class ReadObjectFailedException : Exception
{
    public ReadObjectFailedException() : base() { }
    public ReadObjectFailedException(string message) : base(message) { }
    public ReadObjectFailedException(string message, Exception inner) : base(message, inner) { }
    protected ReadObjectFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    override public string ToString() =>
    "Read Object Failed Exception:" + " overloaded\n" + Message;
}



[Serializable]
public class CreateObjectFailedException : Exception
{
    public CreateObjectFailedException() : base() { }
    public CreateObjectFailedException(string message) : base(message) { }
    public CreateObjectFailedException(string message, Exception inner) : base(message, inner) { }
    protected CreateObjectFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    override public string ToString() =>
    "Create Object Failed Exception:" + " overloaded\n" + Message;
}


[Serializable]
public class UpdateObjectFailedException : Exception
{
    public UpdateObjectFailedException() : base() { }
    public UpdateObjectFailedException(string message) : base(message) { }
    public UpdateObjectFailedException(string message, Exception inner) : base(message, inner) { }
    protected UpdateObjectFailedException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    override public string ToString() =>
    "Update Object Failed Exception:" + " overloaded\n" + Message;
}

[Serializable]
public class ObjectNotExistException : Exception
{
    public ObjectNotExistException() : base() { }
    public ObjectNotExistException(string message) : base(message) { }
    public ObjectNotExistException(string message, Exception inner) : base(message, inner) { }
    protected ObjectNotExistException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    override public string ToString() =>
    "Object Not Exist Exception:" + " overloaded\n" + Message;
}
