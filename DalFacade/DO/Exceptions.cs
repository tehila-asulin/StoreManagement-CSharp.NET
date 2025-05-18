namespace DO;


[Serializable]
public class DalIdNotFoundException : Exception
{
    public DalIdNotFoundException(string message) : base(message) { }

    public DalIdNotFoundException(string message, Exception innerException) : base(message, innerException) { }
}
[Serializable]
public class DalIdExistException : Exception
{
    public DalIdExistException(string message) : base(message) { }

    public DalIdExistException(string message, Exception innerException) : base(message, innerException) { }
}
