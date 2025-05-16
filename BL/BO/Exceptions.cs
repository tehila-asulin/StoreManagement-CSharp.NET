namespace BO;
[Serializable]
public class BLIdNotExistException : Exception
{
    public BLIdNotExistException(string message) : base(message) { }
    public BLIdNotExistException(string message, Exception innerException) : base(message, innerException) { }

}
[Serializable]
public class BLCodeExistException : Exception
{
    public BLCodeExistException(string message) : base(message) { }
    public BLCodeExistException(string message, Exception innerException) : base(message, innerException) { }

}

    [Serializable]
    public class BlInvalidOperationException : Exception
    {
        public BlInvalidOperationException(string message) : base(message) { }
        public BlInvalidOperationException(string message, Exception innerException) : base(message, innerException) { }
    }

