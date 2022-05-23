using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Xml.Serialization;

namespace UPWebPrestaShop.Models
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class prestashopSupp
    {

        private prestashopSupplier supplierField;

        /// <remarks/>
        public prestashopSupplier supplier
        {
            get
            {
                return supplierField;
            }
            set
            {
                supplierField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class prestashopSupplier
    {

        private object idField;

        private object link_rewriteField;

        private object nameField;

        private object activeField;

        private object date_addField;

        private object date_updField;

        private prestashopSupplierDescription descriptionField;

        private prestashopSupplierMeta_title meta_titleField;

        private prestashopSupplierMeta_description meta_descriptionField;

        private prestashopSupplierMeta_keywords meta_keywordsField;

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
        public object link_rewrite
        {
            get
            {
                return link_rewriteField;
            }
            set
            {
                link_rewriteField = value;
            }
        }

        /// <remarks/>
        public object name
        {
            get
            {
                return nameField;
            }
            set
            {
                nameField = value;
            }
        }

        /// <remarks/>
        public object active
        {
            get
            {
                return activeField;
            }
            set
            {
                activeField = value;
            }
        }

        /// <remarks/>
        public object date_add
        {
            get
            {
                return date_addField;
            }
            set
            {
                date_addField = value;
            }
        }

        /// <remarks/>
        public object date_upd
        {
            get
            {
                return date_updField;
            }
            set
            {
                date_updField = value;
            }
        }

        /// <remarks/>
        public prestashopSupplierDescription description
        {
            get
            {
                return descriptionField;
            }
            set
            {
                descriptionField = value;
            }
        }

        /// <remarks/>
        public prestashopSupplierMeta_title meta_title
        {
            get
            {
                return meta_titleField;
            }
            set
            {
                meta_titleField = value;
            }
        }

        /// <remarks/>
        public prestashopSupplierMeta_description meta_description
        {
            get
            {
                return meta_descriptionField;
            }
            set
            {
                meta_descriptionField = value;
            }
        }

        /// <remarks/>
        public prestashopSupplierMeta_keywords meta_keywords
        {
            get
            {
                return meta_keywordsField;
            }
            set
            {
                meta_keywordsField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class prestashopSupplierDescription
    {

        private prestashopSupplierDescriptionLanguage languageField;

        /// <remarks/>
        public prestashopSupplierDescriptionLanguage language
        {
            get
            {
                return languageField;
            }
            set
            {
                languageField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class prestashopSupplierDescriptionLanguage
    {

        private byte idField;

        private string valueField;

        /// <remarks/>
        [XmlAttributeAttribute()]
        public byte id
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
        [XmlTextAttribute()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class prestashopSupplierMeta_title
    {

        private prestashopSupplierMeta_titleLanguage languageField;

        /// <remarks/>
        public prestashopSupplierMeta_titleLanguage language
        {
            get
            {
                return languageField;
            }
            set
            {
                languageField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class prestashopSupplierMeta_titleLanguage
    {

        private byte idField;

        private string valueField;

        /// <remarks/>
        [XmlAttributeAttribute()]
        public byte id
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
        [XmlTextAttribute()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class prestashopSupplierMeta_description
    {

        private prestashopSupplierMeta_descriptionLanguage languageField;

        /// <remarks/>
        public prestashopSupplierMeta_descriptionLanguage language
        {
            get
            {
                return languageField;
            }
            set
            {
                languageField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class prestashopSupplierMeta_descriptionLanguage
    {

        private byte idField;

        private string valueField;

        /// <remarks/>
        [XmlAttributeAttribute()]
        public byte id
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
        [XmlTextAttribute()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class prestashopSupplierMeta_keywords
    {

        private prestashopSupplierMeta_keywordsLanguage languageField;

        /// <remarks/>
        public prestashopSupplierMeta_keywordsLanguage language
        {
            get
            {
                return languageField;
            }
            set
            {
                languageField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class prestashopSupplierMeta_keywordsLanguage
    {

        private byte idField;

        private string valueField;

        /// <remarks/>
        [XmlAttributeAttribute()]
        public byte id
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
        [XmlTextAttribute()]
        public string Value
        {
            get
            {
                return valueField;
            }
            set
            {
                valueField = value;
            }
        }
    }


}
