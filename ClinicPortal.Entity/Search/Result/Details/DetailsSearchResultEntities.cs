using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ClinicPortal.Entity.Search.Result.Details
{
    public class DetailsResult
    {
        [JsonProperty("NPI")]
        public string[] NPI { get; set; }

        [JsonProperty("provider_type")]
        [Display(Name = "Provider Type")]
        public string[] ProviderType { get; set; }

        [JsonProperty("gender")]
        public string[] Gender { get; set; }

        [JsonProperty("licenses")]
        public License[][] Licenses { get; set; }

        [JsonProperty("name")]
        public Name[] Name { get; set; }

        [Display(Name = "Address Practice")]
        [JsonProperty("addr_practice")]
        public Address[] AddrPractice { get; set; }

        [Display(Name = "Mailing Address")]
        [JsonProperty("addr_mailing")]
        public Address[] AddrMailing { get; set; }

        [Display(Name = "Other Name")]
        [JsonProperty("name_other")]
        public Name[] NameOther { get; set; }

        [Display(Name = "Other Id")]
        [JsonProperty("other_ids")]
        public OtherId[][] OtherIds { get; set; }

        [JsonProperty("misc")]
        public Misc[] Misc { get; set; }
    }

    public class Address
    {
        [JsonProperty("line1")]
        public string Line1 { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("zip")]
        public long Zip { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        [JsonProperty("full")]
        public string Full { get; set; }
    }

    public class License
    {
        [JsonProperty("taxonomy")]
        public Taxonomy Taxonomy { get; set; }

        [Display(Name = "License Number")]
        [JsonProperty("lic_number")]
        public string LicNumber { get; set; }

        [Display(Name = "License State")]
        [JsonProperty("lic_state")]
        public string LicState { get; set; }

        [Display(Name = "Is Primary")]
        [JsonProperty("is_primary_taxonomy")]
        public string IsPrimaryTaxonomy { get; set; }

        [JsonProperty("medicare")]
        public Medicare[] Medicare { get; set; }
    }

    public class Medicare
    {
        [Display(Name = "Spc Code")]
        [JsonProperty("spc_code")]
        public string SpcCode { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }


    public class Taxonomy
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("grouping")]
        public string Grouping { get; set; }

        [JsonProperty("classification")]
        public string Classification { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }

    public class Misc
    {
        [Display(Name = "Enumeration")]
        [JsonProperty("enumeration_date")]
        public string EnumerationDate { get; set; }

        [Display(Name = "Last Update")]
        [JsonProperty("last_update_date")]
        public string LastUpdateDate { get; set; }

        [Display(Name = "Is Sole Proprietor")]
        [JsonProperty("is_sole_proprietor")]
        public string IsSoleProprietor { get; set; }
    }

    public class Name
    {
        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("middle")]
        public string Middle { get; set; }

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("credential")]
        public string Credential { get; set; }

        [JsonProperty("full")]
        public string Full { get; set; }
    }

    public class OtherId
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("issuer")]
        public string Issuer { get; set; }
    }
}