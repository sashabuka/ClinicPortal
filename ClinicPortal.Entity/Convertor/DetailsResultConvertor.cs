using ClinicPortal.Entity.Search.Result.Details;
using Newtonsoft.Json.Linq;

namespace ClinicPortal.Entity.Convertor
{
    public class DetailsResultConvertor: IClinicApiConvertor<DetailsResult>
    {
        private const int DATA_INDEX = 2;

        public static DetailsResult Get(string input)
        {
            var response = JArray.Parse(input);
            if (response.Count <= DATA_INDEX) return null;
            return response[DATA_INDEX].ToObject<DetailsResult>();
        }

        public DetailsResult Execute(string input)
        {
            return Get(input);
        }
    }
}