namespace dot_net_RPG.Models
{
    public class ServiceResponse<T>
    {
        public T Data{get; set;}

        public bool Sucess{get; set;} = true;

        public string Message{get; set;} = null;
    }
} 