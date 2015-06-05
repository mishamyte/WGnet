using WGnet.Model;

namespace WGnet.Utils
{
    public class WgResponse<T> where T : class, new ()
    {
        public string Status { get; set; }

        public Meta Meta { get; set; }

        public T Data { get; set; }
    }
}
