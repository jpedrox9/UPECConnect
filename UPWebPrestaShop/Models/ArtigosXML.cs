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
[System.SerializableAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
[XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class prestashopART {
    
    private prestashopProduct productField;
    
    /// <remarks/>
    public prestashopProduct product {
        get {
            return productField;
        }
        set {
            productField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class prestashopProduct {
    
    private string idField;
    
    private string id_manufacturerField;
    
    private string id_supplierField;
    
    private string id_category_defaultField;
    
    private string newField;
    
    private string cache_default_attributeField;
    
    private string id_default_imageField;
    
    private string id_default_combinationField;
    
    private string id_tax_rules_groupField;
    
    private string position_in_categoryField;
    
    private string typeField;
    
    private string id_shop_defaultField;
    
    private string referenceField;
    
    private string supplier_referenceField;
    
    private string locationField;
    
    private string widthField;
    
    private string heightField;
    
    private string depthField;
    
    private string weightField;
    
    private string quantity_discountField;
    
    private string ean13Field;
    
    private string isbnField;
    
    private string upcField;
    
    private string cache_is_packField;
    
    private string cache_has_attachmentsField;
    
    private string is_virtualField;
    
    private string stateField;
    
    private string additional_delivery_timesField;
    
    private List<prestashopProductLanguage> delivery_in_stockField;
    
    private List<prestashopProductLanguage1> delivery_out_stockField;
    
    private string on_saleField;
    
    private string online_onlyField;
    
    private string ecotaxField;
    
    private string minimal_quantityField;
    
    private string low_stock_thresholdField;
    
    private string low_stock_alertField;
    
    private string priceField;
    
    private string wholesale_priceField;
    
    private string unityField;
    
    private string unit_price_ratioField;
    
    private string additional_shipping_costField;
    
    private string customizableField;
    
    private string text_fieldsField;
    
    private string uploadable_filesField;
    
    private string activeField;
    
    private string redirect_typeField;
    
    private string id_type_redirectedField;
    
    private string available_for_orderField;
    
    private string available_dateField;
    
    private string show_conditionField;
    
    private string conditionField;
    
    private string show_priceField;
    
    private string indexedField;
    
    private string visibilityField;
    
    private string advanced_stock_managementField;
    
    private string date_addField;
    
    private string date_updField;
    
    private string pack_stock_typeField;
    
    private List<prestashopProductLanguage2> meta_descriptionField;
    
    private List<prestashopProductLanguage3> meta_keywordsField;
    
    private List<prestashopProductLanguage4> meta_titleField;
    
    private List<prestashopProductLanguage5> link_rewriteField;
    
    private List<prestashopProductLanguage6> nameField;
    
    private List<prestashopProductLanguage7> descriptionField;
    
    private List<prestashopProductLanguage8> description_shortField;
    
    private List<prestashopProductLanguage9> available_nowField;
    
    private List<prestashopProductLanguage10> available_laterField;
    
    private associations associationsField;
    
    /// <remarks/>
    public string id {
        get {
            return idField;
        }
        set {
            idField = value;
        }
    }
    
    /// <remarks/>
    public string id_manufacturer {
        get {
            return id_manufacturerField;
        }
        set {
            id_manufacturerField = value;
        }
    }
    
    /// <remarks/>
    public string id_supplier {
        get {
            return id_supplierField;
        }
        set {
            id_supplierField = value;
        }
    }
    
    /// <remarks/>
    public string id_category_default {
        get {
            return id_category_defaultField;
        }
        set {
            id_category_defaultField = value;
        }
    }
    
    /// <remarks/>
    public string @new {
        get {
            return newField;
        }
        set {
            newField = value;
        }
    }
    
    /// <remarks/>
    public string cache_default_attribute {
        get {
            return cache_default_attributeField;
        }
        set {
            cache_default_attributeField = value;
        }
    }
    
    /// <remarks/>
    public string id_default_image {
        get {
            return id_default_imageField;
        }
        set {
            id_default_imageField = value;
        }
    }
    
    /// <remarks/>
    public string id_default_combination {
        get {
            return id_default_combinationField;
        }
        set {
            id_default_combinationField = value;
        }
    }
    
    /// <remarks/>
    public string id_tax_rules_group {
        get {
            return id_tax_rules_groupField;
        }
        set {
            id_tax_rules_groupField = value;
        }
    }
    
    /// <remarks/>
    public string position_in_category {
        get {
            return position_in_categoryField;
        }
        set {
            position_in_categoryField = value;
        }
    }
    
    /// <remarks/>
    public string type {
        get {
            return typeField;
        }
        set {
            typeField = value;
        }
    }
    
    /// <remarks/>
    public string id_shop_default {
        get {
            return id_shop_defaultField;
        }
        set {
            id_shop_defaultField = value;
        }
    }
    
    /// <remarks/>
    public string reference {
        get {
            return referenceField;
        }
        set {
            referenceField = value;
        }
    }
    
    /// <remarks/>
    public string supplier_reference {
        get {
            return supplier_referenceField;
        }
        set {
            supplier_referenceField = value;
        }
    }
    
    /// <remarks/>
    public string location {
        get {
            return locationField;
        }
        set {
            locationField = value;
        }
    }
    
    /// <remarks/>
    public string width {
        get {
            return widthField;
        }
        set {
            widthField = value;
        }
    }
    
    /// <remarks/>
    public string height {
        get {
            return heightField;
        }
        set {
            heightField = value;
        }
    }
    
    /// <remarks/>
    public string depth {
        get {
            return depthField;
        }
        set {
            depthField = value;
        }
    }
    
    /// <remarks/>
    public string weight {
        get {
            return weightField;
        }
        set {
            weightField = value;
        }
    }
    
    /// <remarks/>
    public string quantity_discount {
        get {
            return quantity_discountField;
        }
        set {
            quantity_discountField = value;
        }
    }
    
    /// <remarks/>
    public string ean13 {
        get {
            return ean13Field;
        }
        set {
            ean13Field = value;
        }
    }
    
    /// <remarks/>
    public string isbn {
        get {
            return isbnField;
        }
        set {
            isbnField = value;
        }
    }
    
    /// <remarks/>
    public string upc {
        get {
            return upcField;
        }
        set {
            upcField = value;
        }
    }
    
    /// <remarks/>
    public string cache_is_pack {
        get {
            return cache_is_packField;
        }
        set {
            cache_is_packField = value;
        }
    }
    
    /// <remarks/>
    public string cache_has_attachments {
        get {
            return cache_has_attachmentsField;
        }
        set {
            cache_has_attachmentsField = value;
        }
    }
    
    /// <remarks/>
    public string is_virtual {
        get {
            return is_virtualField;
        }
        set {
            is_virtualField = value;
        }
    }
    
    /// <remarks/>
    public string state {
        get {
            return stateField;
        }
        set {
            stateField = value;
        }
    }
    
    /// <remarks/>
    public string additional_delivery_times {
        get {
            return additional_delivery_timesField;
        }
        set {
            additional_delivery_timesField = value;
        }
    }
    
    /// <remarks/>
    [XmlArrayItemAttribute("language", IsNullable=false)]
    public List<prestashopProductLanguage> delivery_in_stock {
        get {
            return delivery_in_stockField;
        }
        set {
            delivery_in_stockField = value;
        }
    }
    
    /// <remarks/>
    [XmlArrayItemAttribute("language", IsNullable=false)]
    public List<prestashopProductLanguage1> delivery_out_stock {
        get {
            return delivery_out_stockField;
        }
        set {
            delivery_out_stockField = value;
        }
    }
    
    /// <remarks/>
    public string on_sale {
        get {
            return on_saleField;
        }
        set {
            on_saleField = value;
        }
    }
    
    /// <remarks/>
    public string online_only {
        get {
            return online_onlyField;
        }
        set {
            online_onlyField = value;
        }
    }
    
    /// <remarks/>
    public string ecotax {
        get {
            return ecotaxField;
        }
        set {
            ecotaxField = value;
        }
    }
    
    /// <remarks/>
    public string minimal_quantity {
        get {
            return minimal_quantityField;
        }
        set {
            minimal_quantityField = value;
        }
    }
    
    /// <remarks/>
    public string low_stock_threshold {
        get {
            return low_stock_thresholdField;
        }
        set {
            low_stock_thresholdField = value;
        }
    }
    
    /// <remarks/>
    public string low_stock_alert {
        get {
            return low_stock_alertField;
        }
        set {
            low_stock_alertField = value;
        }
    }
    
    /// <remarks/>
    public string price {
        get {
            return priceField;
        }
        set {
            priceField = value;
        }
    }
    
    /// <remarks/>
    public string wholesale_price {
        get {
            return wholesale_priceField;
        }
        set {
            wholesale_priceField = value;
        }
    }
    
    /// <remarks/>
    public string unity {
        get {
            return unityField;
        }
        set {
            unityField = value;
        }
    }
    
    /// <remarks/>
    public string unit_price_ratio {
        get {
            return unit_price_ratioField;
        }
        set {
            unit_price_ratioField = value;
        }
    }
    
    /// <remarks/>
    public string additional_shipping_cost {
        get {
            return additional_shipping_costField;
        }
        set {
            additional_shipping_costField = value;
        }
    }
    
    /// <remarks/>
    public string customizable {
        get {
            return customizableField;
        }
        set {
            customizableField = value;
        }
    }
    
    /// <remarks/>
    public string text_fields {
        get {
            return text_fieldsField;
        }
        set {
            text_fieldsField = value;
        }
    }
    
    /// <remarks/>
    public string uploadable_files {
        get {
            return uploadable_filesField;
        }
        set {
            uploadable_filesField = value;
        }
    }
    
    /// <remarks/>
    public string active {
        get {
            return activeField;
        }
        set {
            activeField = value;
        }
    }
    
    /// <remarks/>
    public string redirect_type {
        get {
            return redirect_typeField;
        }
        set {
            redirect_typeField = value;
        }
    }
    
    /// <remarks/>
    public string id_type_redirected {
        get {
            return id_type_redirectedField;
        }
        set {
            id_type_redirectedField = value;
        }
    }
    
    /// <remarks/>
    public string available_for_order {
        get {
            return available_for_orderField;
        }
        set {
            available_for_orderField = value;
        }
    }
    
    /// <remarks/>
    public string available_date {
        get {
            return available_dateField;
        }
        set {
            available_dateField = value;
        }
    }
    
    /// <remarks/>
    public string show_condition {
        get {
            return show_conditionField;
        }
        set {
            show_conditionField = value;
        }
    }
    
    /// <remarks/>
    public string condition {
        get {
            return conditionField;
        }
        set {
            conditionField = value;
        }
    }
    
    /// <remarks/>
    public string show_price {
        get {
            return show_priceField;
        }
        set {
            show_priceField = value;
        }
    }
    
    /// <remarks/>
    public string indexed {
        get {
            return indexedField;
        }
        set {
            indexedField = value;
        }
    }
    
    /// <remarks/>
    public string visibility {
        get {
            return visibilityField;
        }
        set {
            visibilityField = value;
        }
    }
    
    /// <remarks/>
    public string advanced_stock_management {
        get {
            return advanced_stock_managementField;
        }
        set {
            advanced_stock_managementField = value;
        }
    }
    
    /// <remarks/>
    public string date_add {
        get {
            return date_addField;
        }
        set {
            date_addField = value;
        }
    }
    
    /// <remarks/>
    public string date_upd {
        get {
            return date_updField;
        }
        set {
            date_updField = value;
        }
    }
    
    /// <remarks/>
    public string pack_stock_type {
        get {
            return pack_stock_typeField;
        }
        set {
            pack_stock_typeField = value;
        }
    }
    
    /// <remarks/>
    [XmlArrayItemAttribute("language", IsNullable=false)]
    public List<prestashopProductLanguage2> meta_description {
        get {
            return meta_descriptionField;
        }
        set {
            meta_descriptionField = value;
        }
    }
    
    /// <remarks/>
    [XmlArrayItemAttribute("language", IsNullable=false)]
    public List<prestashopProductLanguage3> meta_keywords {
        get {
            return meta_keywordsField;
        }
        set {
            meta_keywordsField = value;
        }
    }
    
    /// <remarks/>
    [XmlArrayItemAttribute("language", IsNullable=false)]
    public List<prestashopProductLanguage4> meta_title {
        get {
            return meta_titleField;
        }
        set {
            meta_titleField = value;
        }
    }
    
    /// <remarks/>
    [XmlArrayItemAttribute("language", IsNullable=false)]
    public List<prestashopProductLanguage5> link_rewrite {
        get {
            return link_rewriteField;
        }
        set {
            link_rewriteField = value;
        }
    }
    
    /// <remarks/>
    [XmlArrayItemAttribute("language", IsNullable=false)]
    public List<prestashopProductLanguage6> name {
        get {
            return nameField;
        }
        set {
            nameField = value;
        }
    }
    
    /// <remarks/>
    [XmlArrayItemAttribute("language", IsNullable=false)]
    public List<prestashopProductLanguage7> description {
        get {
            return descriptionField;
        }
        set {
            descriptionField = value;
        }
    }
    
    /// <remarks/>
    [XmlArrayItemAttribute("language", IsNullable=false)]
    public List<prestashopProductLanguage8> description_short {
        get {
            return description_shortField;
        }
        set {
            description_shortField = value;
        }
    }
    
    /// <remarks/>
    [XmlArrayItemAttribute("language", IsNullable=false)]
    public List<prestashopProductLanguage9> available_now {
        get {
            return available_nowField;
        }
        set {
            available_nowField = value;
        }
    }
    
    /// <remarks/>
    [XmlArrayItemAttribute("language", IsNullable=false)]
    public List<prestashopProductLanguage10> available_later {
        get {
            return available_laterField;
        }
        set {
            available_laterField = value;
        }
    }
    
    /// <remarks/>
    public associations associations {
        get {
            return associationsField;
        }
        set {
            associationsField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class prestashopProductLanguage {
    
    private byte idField;
    
    private string valueField;
    
    /// <remarks/>
    [XmlAttributeAttribute()]
    public byte id {
        get {
            return idField;
        }
        set {
            idField = value;
        }
    }
    
    /// <remarks/>
    [XmlTextAttribute()]
    public string Value {
        get {
            return valueField;
        }
        set {
            valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class prestashopProductLanguage1 {
    
    private byte idField;
    
    private string valueField;
    
    /// <remarks/>
    [XmlAttributeAttribute()]
    public byte id {
        get {
            return idField;
        }
        set {
            idField = value;
        }
    }
    
    /// <remarks/>
    [XmlTextAttribute()]
    public string Value {
        get {
            return valueField;
        }
        set {
            valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class prestashopProductLanguage2 {
    
    private byte idField;
    
    private string valueField;
    
    /// <remarks/>
    [XmlAttributeAttribute()]
    public byte id {
        get {
            return idField;
        }
        set {
            idField = value;
        }
    }
    
    /// <remarks/>
    [XmlTextAttribute()]
    public string Value {
        get {
            return valueField;
        }
        set {
            valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class prestashopProductLanguage3 {
    
    private byte idField;
    
    private string valueField;
    
    /// <remarks/>
    [XmlAttributeAttribute()]
    public byte id {
        get {
            return idField;
        }
        set {
            idField = value;
        }
    }
    
    /// <remarks/>
    [XmlTextAttribute()]
    public string Value {
        get {
            return valueField;
        }
        set {
            valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class prestashopProductLanguage4 {
    
    private byte idField;
    
    private string valueField;
    
    /// <remarks/>
    [XmlAttributeAttribute()]
    public byte id {
        get {
            return idField;
        }
        set {
            idField = value;
        }
    }
    
    /// <remarks/>
    [XmlTextAttribute()]
    public string Value {
        get {
            return valueField;
        }
        set {
            valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class prestashopProductLanguage5 {
    
    private byte idField;
    
    private string valueField;
    
    /// <remarks/>
    [XmlAttributeAttribute()]
    public byte id {
        get {
            return idField;
        }
        set {
            idField = value;
        }
    }
    
    /// <remarks/>
    [XmlTextAttribute()]
    public string Value {
        get {
            return valueField;
        }
        set {
            valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class prestashopProductLanguage6 {
    
    private byte idField;
    
    private string valueField;
    
    /// <remarks/>
    [XmlAttributeAttribute()]
    public byte id {
        get {
            return idField;
        }
        set {
            idField = value;
        }
    }
    
    /// <remarks/>
    [XmlTextAttribute()]
    public string Value {
        get {
            return valueField;
        }
        set {
            valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class prestashopProductLanguage7 {
    
    private byte idField;
    
    private string valueField;
    
    /// <remarks/>
    [XmlAttributeAttribute()]
    public byte id {
        get {
            return idField;
        }
        set {
            idField = value;
        }
    }
    
    /// <remarks/>
    [XmlTextAttribute()]
    public string Value {
        get {
            return valueField;
        }
        set {
            valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class prestashopProductLanguage8 {
    
    private byte idField;
    
    private string valueField;
    
    /// <remarks/>
    [XmlAttributeAttribute()]
    public byte id {
        get {
            return idField;
        }
        set {
            idField = value;
        }
    }
    
    /// <remarks/>
    [XmlTextAttribute()]
    public string Value {
        get {
            return valueField;
        }
        set {
            valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class prestashopProductLanguage9 {
    
    private byte idField;
    
    private string valueField;
    
    /// <remarks/>
    [XmlAttributeAttribute()]
    public byte id {
        get {
            return idField;
        }
        set {
            idField = value;
        }
    }
    
    /// <remarks/>
    [XmlTextAttribute()]
    public string Value {
        get {
            return valueField;
        }
        set {
            valueField = value;
        }
    }
}

/// <remarks/>
[System.SerializableAttribute()]
[DesignerCategoryAttribute("code")]
[XmlTypeAttribute(AnonymousType=true)]
public partial class prestashopProductLanguage10 {
    
    private byte idField;
    
    private string valueField;
    
    /// <remarks/>
    [XmlAttributeAttribute()]
    public byte id {
        get {
            return idField;
        }
        set {
            idField = value;
        }
    }
    
    /// <remarks/>
    [XmlTextAttribute()]
    public string Value {
        get {
            return valueField;
        }
        set {
            valueField = value;
        }
    }
}


    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class associations
    {

        private List<category> categoriesField;

        private associationsImages imagesField;

        private associationsCombinations combinationsField;

        private associationsProduct_option_values product_option_valuesField;

        private associationsProduct_features product_featuresField;

        private associationsTags tagsField;

        private associationsStock_availables stock_availablesField;

        private associationsAccessories accessoriesField;

        private associationsProduct_bundle product_bundleField;

        /// <remarks/>
        public List<category> categories
        {
            get
            {
                return categoriesField;
            }
            set
            {
                categoriesField = value;
            }
        }

        /// <remarks/>
        public associationsImages images
        {
            get
            {
                return imagesField;
            }
            set
            {
                imagesField = value;
            }
        }

        /// <remarks/>
        public associationsCombinations combinations
        {
            get
            {
                return combinationsField;
            }
            set
            {
                combinationsField = value;
            }
        }

        /// <remarks/>
        public associationsProduct_option_values product_option_values
        {
            get
            {
                return product_option_valuesField;
            }
            set
            {
                product_option_valuesField = value;
            }
        }

        /// <remarks/>
        public associationsProduct_features product_features
        {
            get
            {
                return product_featuresField;
            }
            set
            {
                product_featuresField = value;
            }
        }

        /// <remarks/>
        public associationsTags tags
        {
            get
            {
                return tagsField;
            }
            set
            {
                tagsField = value;
            }
        }

        /// <remarks/>
        public associationsStock_availables stock_availables
        {
            get
            {
                return stock_availablesField;
            }
            set
            {
                stock_availablesField = value;
            }
        }

        /// <remarks/>
        public associationsAccessories accessories
        {
            get
            {
                return accessoriesField;
            }
            set
            {
                accessoriesField = value;
            }
        }

        /// <remarks/>
        public associationsProduct_bundle product_bundle
        {
            get
            {
                return product_bundleField;
            }
            set
            {
                product_bundleField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class category
    {

        private string idField;

        /// <remarks/>
        public string id
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
    }


    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsImages
    {

        private associationsImagesImage imageField;

        /// <remarks/>
        public associationsImagesImage image
        {
            get
            {
                return imageField;
            }
            set
            {
                imageField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsImagesImage
    {

        private object idField;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsCombinations
    {

        private associationsCombinationsCombination combinationField;

        /// <remarks/>
        public associationsCombinationsCombination combination
        {
            get
            {
                return combinationField;
            }
            set
            {
                combinationField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsCombinationsCombination
    {

        private object idField;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsProduct_option_values
    {

        private associationsProduct_option_valuesProduct_option_value product_option_valueField;

        /// <remarks/>
        public associationsProduct_option_valuesProduct_option_value product_option_value
        {
            get
            {
                return product_option_valueField;
            }
            set
            {
                product_option_valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsProduct_option_valuesProduct_option_value
    {

        private object idField;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsProduct_features
    {

        private associationsProduct_featuresProduct_feature product_featureField;

        /// <remarks/>
        public associationsProduct_featuresProduct_feature product_feature
        {
            get
            {
                return product_featureField;
            }
            set
            {
                product_featureField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsProduct_featuresProduct_feature
    {

        private object idField;

        private object id_feature_valueField;

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
        public object id_feature_value
        {
            get
            {
                return id_feature_valueField;
            }
            set
            {
                id_feature_valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsTags
    {

        private associationsTagsTag tagField;

        /// <remarks/>
        public associationsTagsTag tag
        {
            get
            {
                return tagField;
            }
            set
            {
                tagField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsTagsTag
    {

        private object idField;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsStock_availables
    {

        private associationsStock_availablesStock_available stock_availableField;

        /// <remarks/>
        public associationsStock_availablesStock_available stock_available
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
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsStock_availablesStock_available
    {

        private object idField;

        private object id_product_attributeField;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsAccessories
    {

        private associationsAccessoriesProduct productField;

        /// <remarks/>
        public associationsAccessoriesProduct product
        {
            get
            {
                return productField;
            }
            set
            {
                productField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsAccessoriesProduct
    {

        private object idField;

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
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsProduct_bundle
    {

        private associationsProduct_bundleProduct productField;

        /// <remarks/>
        public associationsProduct_bundleProduct product
        {
            get
            {
                return productField;
            }
            set
            {
                productField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    public partial class associationsProduct_bundleProduct
    {

        private object idField;

        private object id_product_attributeField;

        private object quantityField;

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
    }




}