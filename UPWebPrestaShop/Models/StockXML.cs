using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;

namespace UPWebPrestashop.Models
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class prestashopST
    {

        private prestashopStock stock_availableField;

        /// <remarks/>
        public prestashopStock stock_available
        {
            get
            {
                return stock_availableField;
            }
            set
            {
                stock_availableField = value;
            }
        }
    }

    /// <remarks/>
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class prestashopStock
    {

        private object idField;

        private object id_productField;

        private object id_product_attributeField;

        private object id_shopField;

        private object id_shop_groupField;

        private object quantityField;

        private object depends_on_stockField;

        private object out_of_stockField;

        private object locationField;

        /// <remarks/>
        public object id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        /// <remarks/>
        public object id_product
        {
            get
            {
                return id_productField;
            }
            set
            {
                id_productField = value;
            }
        }

        /// <remarks/>
        public object id_product_attribute
        {
            get
            {
                return id_product_attributeField;
            }
            set
            {
                id_product_attributeField = value;
            }
        }

        /// <remarks/>
        public object id_shop
        {
            get
            {
                return id_shopField;
            }
            set
            {
                id_shopField = value;
            }
        }

        /// <remarks/>
        public object id_shop_group
        {
            get
            {
                return id_shop_groupField;
            }
            set
            {
                id_shop_groupField = value;
            }
        }

        /// <remarks/>
        public object quantity
        {
            get
            {
                return quantityField;
            }
            set
            {
                quantityField = value;
            }
        }

        /// <remarks/>
        public object depends_on_stock
        {
            get
            {
                return depends_on_stockField;
            }
            set
            {
                depends_on_stockField = value;
            }
        }

        /// <remarks/>
        public object out_of_stock
        {
            get
            {
                return out_of_stockField;
            }
            set
            {
                out_of_stockField = value;
            }
        }

        /// <remarks/>
        public object location
        {
            get
            {
                return locationField;
            }
            set
            {
                locationField = value;
            }
        }
    }


}
