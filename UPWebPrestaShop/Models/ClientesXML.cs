using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UPWebPrestaShop.Models
{
    public class ClientesXML
    {

        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class prestashopCl
        {

            private prestashopCustomer customerField;

            /// <remarks/>
            public prestashopCustomer customer
            {
                get
                {
                    return customerField;
                }
                set
                {
                    customerField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class prestashopCustomer
        {

            private string idField;

            private string id_default_groupField;

            private string id_langField;

            private string newsletter_date_addField;

            private string ip_registration_newsletterField;

            private string last_passwd_genField;

            private string secure_keyField;

            private string deletedField;

            private string passwdField;

            private string lastnameField;

            private string firstnameField;

            private string emailField;

            private string id_genderField;

            private string birthdayField;

            private string newsletterField;

            private string optinField;

            private string websiteField;

            private string companyField;

            private string siretField;

            private string apeField;

            private string outstanding_allow_amountField;

            private string show_public_pricesField;

            private string id_riskField;

            private string max_payment_daysField;

            private string activeField;

            private string noteField;

            private string is_guestField;

            private string id_shopField;

            private string id_shop_groupField;

            private string date_addField;

            private string date_updField;

            private string reset_password_tokenField;

            private string reset_password_validityField;

            private prestashopCustomerAssociations associationsField;

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

            /// <remarks/>
            public string id_default_group
            {
                get
                {
                    return id_default_groupField;
                }
                set
                {
                    id_default_groupField = value;
                }
            }

            /// <remarks/>
            public string id_lang
            {
                get
                {
                    return id_langField;
                }
                set
                {
                    id_langField = value;
                }
            }

            /// <remarks/>
            public string newsletter_date_add
            {
                get
                {
                    return newsletter_date_addField;
                }
                set
                {
                    newsletter_date_addField = value;
                }
            }

            /// <remarks/>
            public string ip_registration_newsletter
            {
                get
                {
                    return ip_registration_newsletterField;
                }
                set
                {
                    ip_registration_newsletterField = value;
                }
            }

            /// <remarks/>
            public string last_passwd_gen
            {
                get
                {
                    return last_passwd_genField;
                }
                set
                {
                    last_passwd_genField = value;
                }
            }

            /// <remarks/>
            public string secure_key
            {
                get
                {
                    return secure_keyField;
                }
                set
                {
                    secure_keyField = value;
                }
            }

            /// <remarks/>
            public string deleted
            {
                get
                {
                    return deletedField;
                }
                set
                {
                    deletedField = value;
                }
            }

            /// <remarks/>
            public string passwd
            {
                get
                {
                    return passwdField;
                }
                set
                {
                    passwdField = value;
                }
            }

            /// <remarks/>
            public string lastname
            {
                get
                {
                    return lastnameField;
                }
                set
                {
                    lastnameField = value;
                }
            }

            /// <remarks/>
            public string firstname
            {
                get
                {
                    return firstnameField;
                }
                set
                {
                    firstnameField = value;
                }
            }

            /// <remarks/>
            public string email
            {
                get
                {
                    return emailField;
                }
                set
                {
                    emailField = value;
                }
            }

            /// <remarks/>
            public string id_gender
            {
                get
                {
                    return id_genderField;
                }
                set
                {
                    id_genderField = value;
                }
            }

            /// <remarks/>
            public string birthday
            {
                get
                {
                    return birthdayField;
                }
                set
                {
                    birthdayField = value;
                }
            }

            /// <remarks/>
            public string newsletter
            {
                get
                {
                    return newsletterField;
                }
                set
                {
                    newsletterField = value;
                }
            }

            /// <remarks/>
            public string optin
            {
                get
                {
                    return optinField;
                }
                set
                {
                    optinField = value;
                }
            }

            /// <remarks/>
            public string website
            {
                get
                {
                    return websiteField;
                }
                set
                {
                    websiteField = value;
                }
            }

            /// <remarks/>
            public string company
            {
                get
                {
                    return companyField;
                }
                set
                {
                    companyField = value;
                }
            }

            /// <remarks/>
            public string siret
            {
                get
                {
                    return siretField;
                }
                set
                {
                    siretField = value;
                }
            }

            /// <remarks/>
            public string ape
            {
                get
                {
                    return apeField;
                }
                set
                {
                    apeField = value;
                }
            }

            /// <remarks/>
            public string outstanding_allow_amount
            {
                get
                {
                    return outstanding_allow_amountField;
                }
                set
                {
                    outstanding_allow_amountField = value;
                }
            }

            /// <remarks/>
            public string show_public_prices
            {
                get
                {
                    return show_public_pricesField;
                }
                set
                {
                    show_public_pricesField = value;
                }
            }

            /// <remarks/>
            public string id_risk
            {
                get
                {
                    return id_riskField;
                }
                set
                {
                    id_riskField = value;
                }
            }

            /// <remarks/>
            public string max_payment_days
            {
                get
                {
                    return max_payment_daysField;
                }
                set
                {
                    max_payment_daysField = value;
                }
            }

            /// <remarks/>
            public string active
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
            public string note
            {
                get
                {
                    return noteField;
                }
                set
                {
                    noteField = value;
                }
            }

            /// <remarks/>
            public string is_guest
            {
                get
                {
                    return is_guestField;
                }
                set
                {
                    is_guestField = value;
                }
            }

            /// <remarks/>
            public string id_shop
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
            public string id_shop_group
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
            public string date_add
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
            public string date_upd
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
            public string reset_password_token
            {
                get
                {
                    return reset_password_tokenField;
                }
                set
                {
                    reset_password_tokenField = value;
                }
            }

            /// <remarks/>
            public string reset_password_validity
            {
                get
                {
                    return reset_password_validityField;
                }
                set
                {
                    reset_password_validityField = value;
                }
            }

            /// <remarks/>
            public prestashopCustomerAssociations associations
            {
                get
                {
                    return associationsField;
                }
                set
                {
                    associationsField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class prestashopCustomerAssociations
        {

            private prestashopCustomerAssociationsGroups groupsField;

            /// <remarks/>
            public prestashopCustomerAssociationsGroups groups
            {
                get
                {
                    return groupsField;
                }
                set
                {
                    groupsField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class prestashopCustomerAssociationsGroups
        {

            private prestashopCustomerAssociationsGroupsGroup groupField;

            /// <remarks/>
            public prestashopCustomerAssociationsGroupsGroup group
            {
                get
                {
                    return groupField;
                }
                set
                {
                    groupField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class prestashopCustomerAssociationsGroupsGroup
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


    }
}
