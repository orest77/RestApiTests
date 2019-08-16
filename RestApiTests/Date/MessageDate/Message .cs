namespace RestApiTests.Date.MessageDate
{
    public interface ISetMessage
    {
        ISetStatus SetMessage(string message);
    }

    public interface ISetStatus
    {
        IMassageBuild SetStatus(string status);
    }

    public interface IMassageBuild
    {
        IMessage Build();
    }

    public interface IMessage
    {
        string GetMessage();
        string GetStatus();
    }
    public class Message : IMessage, IMassageBuild, ISetMessage, ISetStatus
    {
        private string _message;
        private string _status;

        private Message()
        {
        }

        public IMessage Build()
        {
            return this;
        }

        public static ISetMessage Get()
        {
            return new Message();
        }

        public ISetStatus SetMessage(string message)
        {
            _message = message;
            return this;
        }

        public IMassageBuild SetStatus(string status)
        {
            _status = status;
            return this;
        }

        public string GetMessage()
        {
            return _message;
        }

        public string GetStatus()
        {
            return _status;
        }
    }
}
