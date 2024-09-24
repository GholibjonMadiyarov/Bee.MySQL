namespace Bee.MySQL.Models
{
    public class Query
    {
        public bool execute { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public bool duplicate { get; set; }

        public Query() 
        {
            execute = false;
            message = null;
            data = null;
            duplicate = false;
        }
    }
}
