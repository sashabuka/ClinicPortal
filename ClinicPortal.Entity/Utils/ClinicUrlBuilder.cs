using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace ClinicPortal.Entity.Utils
{
    public class ClinicUrlBuilder
    {
        private readonly StringBuilder builder;

        public ClinicUrlBuilder(string baseUrl)
        {
            builder = new StringBuilder(baseUrl.EndsWith("/") ? baseUrl : $"{baseUrl}/");
        }

        public ClinicUrlBuilder Search()
        {
            builder.Append("search");
            return this;
        }

        public ClinicUrlBuilder WithParams()
        {
            builder.Append("?");
            return this;
        }
        public ClinicUrlBuilder AddTerms(string value)
        {
            builder.Append($"terms={Uri.EscapeDataString(value)}");
            return this;
        }

        public ClinicUrlBuilder And()
        {
            builder.Append("&");
            return this;
        }

        public ClinicUrlBuilder AddSearchFields(string[] values)
        {
            builder.Append($"sf={string.Join(',', values.Select(Uri.EscapeDataString)) }");
            return this;
        }

        public ClinicUrlBuilder AddMaxList(int value)
        {
            builder.Append($"maxList={value}");
            return this;
        }

        public string Build()
        {
            return builder.ToString();
        }
    }
}
