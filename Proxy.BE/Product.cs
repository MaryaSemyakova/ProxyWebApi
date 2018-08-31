using Newtonsoft.Json;

namespace Proxy.BE
{
    public class Product
    {
        [JsonProperty(PropertyName = "part_number")]
        public long PartNumber { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "supplier")]
        public string Supplier { get; set; }

        [JsonProperty(PropertyName = "vendor")]
        public string Vendor { get; set; }

        [JsonProperty(PropertyName = "vendor_part_number")]
        public long VendorPartNumber { get; set; }

        [JsonProperty(PropertyName = "vendor_description")]
        public string VendorDescription { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }
    }
}
