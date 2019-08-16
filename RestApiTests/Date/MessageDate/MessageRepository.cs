namespace RestApiTests.Date.MessageDate
{
    public class MessageRepository
    {
        private static volatile MessageRepository _instance;
        private static readonly object LookingObject = new object();

        private MessageRepository()
        { }
        public static MessageRepository Get()
        {
            if (_instance == null)
            {
                lock (LookingObject)
                {
                    if (_instance == null)
                    {
                        _instance = new MessageRepository();
                    }
                }
            }
            return _instance;
        }
    }
}
