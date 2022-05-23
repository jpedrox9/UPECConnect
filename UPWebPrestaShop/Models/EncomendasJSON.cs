using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPWebPrestaShop.Models.Encomenda
{
    public class EncomendasResponse
    {
        public Order order { get; set; }
        public List<Order> orders { get; set; }
    }

    public class Order
    {
        public int id { get; set; }
        public string id_address_delivery { get; set; }
        public string id_address_invoice { get; set; }
        public string id_cart { get; set; }
        public string id_currency { get; set; }
        public string id_lang { get; set; }
        public string id_customer { get; set; }
        public string id_carrier { get; set; }
        public string current_state { get; set; }
        public string module { get; set; }
        public string invoice_number { get; set; }
        public string invoice_date { get; set; }
        public string delivery_number { get; set; }
        public string delivery_date { get; set; }
        public string valid { get; set; }
        public string date_add { get; set; }
        public string date_upd { get; set; }
        public string shipping_number { get; set; }
        public string id_shop_group { get; set; }
        public string id_shop { get; set; }
        public string secure_key { get; set; }
        public string payment { get; set; }
        public string recyclable { get; set; }
        public string gift { get; set; }
        public string gift_message { get; set; }
        public string mobile_theme { get; set; }
        public string total_discounts { get; set; }
        public string total_discounts_tax_incl { get; set; }
        public string total_discounts_tax_excl { get; set; }
        public string total_paid { get; set; }
        public string total_paid_tax_incl { get; set; }
        public string total_paid_tax_excl { get; set; }
        public string total_paid_real { get; set; }
        public string total_products { get; set; }
        public string total_products_wt { get; set; }
        public string total_shipping { get; set; }
        public string total_shipping_tax_incl { get; set; }
        public string total_shipping_tax_excl { get; set; }
        public string carrier_tax_rate { get; set; }
        public string total_wrapping { get; set; }
        public string total_wrapping_tax_incl { get; set; }
        public string total_wrapping_tax_excl { get; set; }
        public string round_mode { get; set; }
        public string round_type { get; set; }
        public string conversion_rate { get; set; }
        public string reference { get; set; }
        public Associations associations { get; set; }
    }

    public class Associations
    {
        public List<Order_Rows> order_rows { get; set; }
    }

    public class Order_Rows
    {
        public string id { get; set; }
        public string product_id { get; set; }
        public string product_attribute_id { get; set; }
        public string product_quantity { get; set; }
        public string product_name { get; set; }
        public string product_reference { get; set; }
        public string product_ean13 { get; set; }
        public string product_isbn { get; set; }
        public string product_upc { get; set; }
        public string product_price { get; set; }
        public string id_customization { get; set; }
        public string unit_price_tax_incl { get; set; }
        public string unit_price_tax_excl { get; set; }
    }

}
