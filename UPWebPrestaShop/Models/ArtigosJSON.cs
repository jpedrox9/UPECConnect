using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace UPWebPrestaShop.Models
{
    public class ArtigosResponse
    {
        [JsonProperty("products")]
        public List<Product> Produtos { get; set; }

        [JsonProperty("product")]
        public Product Produto { get; set; }
    }
    public class Product
    {
        public string id { get; set; }
        public string id_manufacturer { get; set; }
        public string id_supplier { get; set; }
        public string id_category_default { get; set; }
        public string _new { get; set; }
        public string cache_default_attribute { get; set; }
        public string id_default_image { get; set; }
        public string id_default_combination { get; set; }
        public string id_tax_rules_group { get; set; }
        public string position_in_category { get; set; }
        public string type { get; set; }
        public string id_shop_default { get; set; }
        public string reference { get; set; }
        public string supplier_reference { get; set; }
        public string location { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string depth { get; set; }
        public string weight { get; set; }
        public string quantity_discount { get; set; }
        public string ean13 { get; set; }
        public string isbn { get; set; }
        public string upc { get; set; }
        public string cache_is_pack { get; set; }
        public string cache_has_attachments { get; set; }
        public string is_virtual { get; set; }
        public string state { get; set; }
        public string additional_delivery_times { get; set; }
        public string delivery_in_stock { get; set; }
        public string delivery_out_stock { get; set; }
        public string on_sale { get; set; }
        public string online_only { get; set; }
        public string ecotax { get; set; }
        public string minimal_quantity { get; set; }
        public string low_stock_threshold { get; set; }
        public string low_stock_alert { get; set; }
        public string price { get; set; }
        public string wholesale_price { get; set; }
        public string unity { get; set; }
        public string unit_price_ratio { get; set; }
        public string additional_shipping_cost { get; set; }
        public string customizable { get; set; }
        public string text_fields { get; set; }
        public string uploadable_files { get; set; }
        public string active { get; set; }
        public string redirect_type { get; set; }
        public string id_type_redirected { get; set; }
        public string available_for_order { get; set; }
        public string available_date { get; set; }
        public string show_condition { get; set; }
        public string condition { get; set; }
        public string show_price { get; set; }
        public string indexed { get; set; }
        public string visibility { get; set; }
        public string advanced_stock_management { get; set; }
        public string date_add { get; set; }
        public string date_upd { get; set; }
        public string pack_stock_type { get; set; }
        public string meta_description { get; set; }
        public string meta_keywords { get; set; }
        public string meta_title { get; set; }
        public string link_rewrite { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string description_short { get; set; }
        public string available_now { get; set; }
        public string available_later { get; set; }
        public Associations associations { get; set; }
    }

    public class Associations
    {
        public Category[] categories { get; set; }
        public Image[] images { get; set; }
        public Combination[] combinations { get; set; }
        public Product_Option_Values[] product_option_values { get; set; }
        public Product_Features[] product_features { get; set; }
        public Tag[] tags { get; set; }
        public Stock_Availables[] stock_availables { get; set; }
        public Accessory[] accessories { get; set; }
        public Product_Bundle[] product_bundle { get; set; }
    }

    public class Category
    {
        public object id { get; set; }
    }

    public class Image
    {
        public object id { get; set; }
    }

    public class Combination
    {
        public object id { get; set; }
    }

    public class Product_Option_Values
    {
        public object id { get; set; }
    }

    public class Product_Features
    {
        public object id { get; set; }
        public object id_feature_value { get; set; }
    }

    public class Tag
    {
        public object id { get; set; }
    }

    public class Stock_Availables
    {
        public object id { get; set; }
        public object id_product_attribute { get; set; }
    }

    public class Accessory
    {
        public object id { get; set; }
    }

    public class Product_Bundle
    {
        public object id { get; set; }
        public object id_product_attribute { get; set; }
        public object quantity { get; set; }
    }
}