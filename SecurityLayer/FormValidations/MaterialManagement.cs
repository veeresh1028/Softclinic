using BusinessEntities.Accounts.MaterialManagement;
using System;
using System.Collections.Generic;

namespace SecurityLayer.FormValidations
{
    public class MaterialManagement
    {
        public static bool isValidUOM(BusinessEntities.Accounts.Masters.UOM data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.uom))
                {
                    errors.Add("uom", "UOM Name is Required.");
                }
                if (string.IsNullOrEmpty(data.uom_category))
                {
                    errors.Add("uom_category", "UOM Category is Required.");
                }
            }
            else
            {
                errors.Add("uom", "UOM Name is Required.");
                errors.Add("uom_category", "UOM Category is Required.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidStockGroup(BusinessEntities.Accounts.Masters.StockGroup data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.ig_group))
                {
                    errors.Add("ig_group", "Stock Group is Required.");
                }
                if (!(data.ig_branch > 0))
                {
                    errors.Add("ig_branch", "Group Brancch is Required.");
                }
            }
            else
            {
                errors.Add("ig_group", "Stock Group is Required.");
                errors.Add("ig_branch", "Group Brancch is Required.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidItemLocation(BusinessEntities.Accounts.Masters.ItemLocation data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.il_location))
                {
                    errors.Add("il_location", "Item Location is Required.");
                }
            }
            else
            {
                errors.Add("il_location", "Item Location is Required.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidSupplier(BusinessEntities.Accounts.Masters.Supplier data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.sup_name))
                {
                    errors.Add("sup_name", "Supplier Name is Required.");
                }
                else
                {
                    if (data.sup_name.Length < 3)
                    {
                        errors.Add("sup_name", "Supplier Name should be minimum 3 characters");
                    }
                }
                decimal _credit = 0;
                if (!decimal.TryParse(data.sup_credit.ToString(), out _credit))
                {
                    errors.Add("sup_obal", "Credit Days are Required.");
                }
                if (!string.IsNullOrEmpty(data.sup_mob))
                {
                    if (data.sup_mob.Length < 10)
                    {
                        errors.Add("sup_mob", "Enter valid mobile number.");
                    }
                }
                if (!string.IsNullOrEmpty(data.sup_tel))
                {
                    if (data.sup_tel.Length < 8)
                    {
                        errors.Add("sup_tel", "Enter valid telephone number.");
                    }
                }
                if (!string.IsNullOrEmpty(data.sup_email))
                {
                    if (!EmailValidation.isValidEmail(data.sup_email))
                    {
                        errors.Add("sup_email", "Invalid Email address");
                    }
                }
            }
            else
            {
                errors.Add("sup_name", "Supplier Name is Required.");
                errors.Add("sup_credit", "Credit Days are Required.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidSupplier_OpeningBalce(BusinessEntities.Accounts.Masters.Supplier data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                decimal _obal = 0;
                if (!decimal.TryParse(data.sup_obal.ToString(), out _obal))
                {
                    errors.Add("sup_obal", "Opening Balane is Required.");
                }
                if (string.IsNullOrEmpty(data.sup_obal_type))
                {
                    errors.Add("sup_obal_type", "select Opening Balance Type.");
                }
                if (string.IsNullOrEmpty(data.sup_account))
                {
                    errors.Add("sup_account", "Error to Get Supplier Account");
                }
            }
            else
            {
                errors.Add("sup_account", "Error to Get Supplier Code.");
                errors.Add("sup_obal", "Opening Balane is Required.");
                errors.Add("sup_obal_type", "select Opening Balance Type.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidItemForm(BusinessEntities.Accounts.Masters.Items data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (string.IsNullOrEmpty(data.item_name))
                {
                    errors.Add("item_name", "Enter Item Name.");
                }
                if (string.IsNullOrEmpty(data.item_type))
                {
                    errors.Add("item_type", "Select Item Type.");
                }
                if (data.item_branch < 1)
                {
                    errors.Add("item_branch", "Select Branch.");
                }
                if (data.item_category < 1)
                {
                    errors.Add("item_category", "Select Group.");
                }
                if (data.item_location < 1)
                {
                    errors.Add("item_location", "Select Location.");
                }
                if (data.item_cost <= 0)
                {
                    errors.Add("item_cost", "Enter Cost Price.");
                }
                if (data.item_cost2 <= 0)
                {
                    errors.Add("item_cost2", "Enter Cost Price.");
                }
                if (data.item_cost3 <= 0)
                {
                    errors.Add("item_cost3", "Enter Cost Price.");
                }
                if (data.item_sprice <= 0)
                {
                    errors.Add("item_sprice", "Enter Sales Price.");
                }
                if (data.item_sprice2 <= 0)
                {
                    errors.Add("item_sprice2", "Enter Sales Price.");
                }
                if (data.item_sprice3 <= 0)
                {
                    errors.Add("item_sprice3", "Enter Sales Price.");
                }
                if (data.item_m_factor < 1)
                {
                    errors.Add("item_m_factor", "Enter Multiplication Factor.");
                }
                if (data.item_m_factor2 < 1)
                {
                    errors.Add("item_m_factor2", "Enter Multiplication Factor.");
                }
                if (string.IsNullOrEmpty(data.item_uom))
                {
                    errors.Add("item_uom", "select UOM");
                }
                if (string.IsNullOrEmpty(data.item_uom2))
                {
                    errors.Add("item_uom2", "select UOM");
                }
                if (string.IsNullOrEmpty(data.item_uom3))
                {
                    errors.Add("item_uom3", "select UOM");
                }
            }
            else
            {
                errors.Add("item_name", "Enter Item Name.");
                errors.Add("item_type", "Select Item Type.");
                errors.Add("item_branch", "Select Branch.");
                errors.Add("item_category", "Select Group.");
                errors.Add("item_location", "Select Location.");
                errors.Add("item_cost", "Enter Cost Price.");
                errors.Add("item_cost2", "Enter Cost Price.");
                errors.Add("item_cost3", "Enter Cost Price.");
                errors.Add("item_sprice", "Enter Sales Price.");
                errors.Add("item_sprice2", "Enter Sales Price.");
                errors.Add("item_sprice3", "Enter Sales Price.");
                errors.Add("item_m_factor", "Enter Multiplication Factor.");
                errors.Add("item_m_factor2", "Enter Multiplication Factor.");
                errors.Add("item_uom", "select UOM");
                errors.Add("item_uom2", "select UOM");
                errors.Add("item_uom3", "select UOM");
            }
            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidItems_OpeningStock(BusinessEntities.Accounts.Masters.Items data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (data.itemId <= 0)
                {
                    errors.Add("itemId", "Erorr Refresh Page Once.");
                }
                if (isValidDecimal(data.item_opening_qty.ToString()) == false)
                {
                    errors.Add("item_opening_qty", "Enter Opening Stock Qty 0.");
                }
                if (isValidDecimal(data.item_opening_qty2.ToString()) == false)
                {
                    errors.Add("item_opening_qty2", "Enter Opening Stock Qty 1.");
                }
                if (isValidDecimal(data.item_opening_qty2.ToString()) == false)
                {
                    errors.Add("item_opening_qty3", "Enter Opening Stock Qty 2.");
                }
            }
            else
            {
                errors.Add("item_opening_qty", "Enter Opening Stock Qty 0.");
                errors.Add("item_opening_qty2", "Enter Opening Stock Qty 1.");
                errors.Add("item_opening_qty3", "Enter Opening Stock Qty 2.");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidPurchaseOrder(PurchaseOrderAndItems data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data != null)
            {
                if (data.purchaseOrders != null)
                {
                    try
                    {
                        if (data.purchaseOrders.pur_branch <= 0)
                        {
                            errors.Add("pur_branch", "Selcet Branch.");
                        }

                        if (data.purchaseOrders.pur_supplier <= 0)
                        {
                            errors.Add("pur_supplier", "Select Supplier.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_type))
                        {
                            errors.Add("pur_type", "Select Order Type.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_odate))
                        {
                            errors.Add("pur_odate", "Enter Purchase Order Date.");
                        }
                        else
                        {
                            if (!DateTime.TryParse(data.purchaseOrders.pur_odate.ToString(), out DateTime _out))
                                errors.Add("pur_odate", "Purchase Order Date is not in Correct Format.");
                        }

                        if (!int.TryParse(data.purchaseOrders.pur_validity.ToString(), out int _out2))
                            data.purchaseOrders.pur_validity = 0;

                        if (!int.TryParse(data.purchaseOrders.pur_pay_terms.ToString(), out int _out3))
                            data.purchaseOrders.pur_pay_terms = 0;

                        if (!string.IsNullOrEmpty(data.purchaseOrders.pur_qdate))
                        {
                            if (!DateTime.TryParse(data.purchaseOrders.pur_qdate.ToString(), out DateTime _out4))
                                errors.Add("pur_odate", "Quotation Date is not in Correct Format.");
                        }
                        else
                            data.purchaseOrders.pur_qdate = DateTime.Now.ToString();

                        if (!string.IsNullOrEmpty(data.purchaseOrders.pur_type))
                        {
                            if (data.purchaseOrders.pur_type == "Purchase Invoice" || data.purchaseOrders.pur_type == "GRN Regular")
                            {
                                if (string.IsNullOrEmpty(data.purchaseOrders.pur_sup_invoice))
                                    errors.Add("pur_sup_invoice", "Enter Supplier Purchase Invoice.");
                            }
                        }

                        if (!string.IsNullOrEmpty(data.purchaseOrders.pur_ship_4))
                        {
                            if (!EmailValidation.isValidEmail(data.purchaseOrders.pur_ship_4))
                            {
                                errors.Add("pur_ship_4", "Ship To Email is not in Correct Format.");
                            }
                        }

                        if (!string.IsNullOrEmpty(data.purchaseOrders.pur_bill_4))
                        {
                            if (!EmailValidation.isValidEmail(data.purchaseOrders.pur_bill_4))
                            {
                                errors.Add("pur_bill_4", "Bill To Email is not in Correct Format.");
                            }
                        }

                        if (!string.IsNullOrEmpty(data.purchaseOrders.pur_buy_4))
                        {
                            if (!EmailValidation.isValidEmail(data.purchaseOrders.pur_buy_4))
                            {
                                errors.Add("pur_buy_4", "Buyer Email is not in Correct Format.");
                            }
                        }

                        if (isValidDecimal(data.purchaseOrders.pur_total.ToString()))
                        {
                            if (data.purchaseOrders.pur_total <= 0)
                                errors.Add("pur_total", "Total Amount Should be Greater than 0.");
                        }
                        else
                            errors.Add("pur_total", "Total Amount is Not in Correct Format.");

                        if (isValidDecimal(data.purchaseOrders.pur_net.ToString()))
                        {
                            if (data.purchaseOrders.pur_net <= 0)
                                errors.Add("pur_net", "Net Amount Should be Greater than 0.");
                        }
                        else
                            errors.Add("pur_net", "Net Amount is Not in Correct Format.");

                        if (!isValidDecimal(data.purchaseOrders.pur_vat.ToString()))
                        {
                            errors.Add("pur_vat", "VAT Amount is Not in Correct Format.");
                        }

                        if (!isValidDecimal(data.purchaseOrders.pur_disc_val.ToString()))
                        {
                            errors.Add("pur_disc_val", "Discount Amount is Not in Correct Format.");
                        }
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_account))
                            data.purchaseOrders.pur_account = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_notes))
                            data.purchaseOrders.pur_notes = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_enqno))
                            data.purchaseOrders.pur_enqno = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_quono))
                            data.purchaseOrders.pur_quono = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_buy_1))
                            data.purchaseOrders.pur_buy_1 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_buy_2))
                            data.purchaseOrders.pur_buy_2 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_buy_3))
                            data.purchaseOrders.pur_buy_3 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_buy_4))
                            data.purchaseOrders.pur_buy_4 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_sup_invoice))
                            data.purchaseOrders.pur_sup_invoice = string.Empty;

                    }
                    catch (Exception ex)
                    {
                        errors.Add("Error : ", " " + ex.Message);
                    }
                }
                else
                {
                    errors.Add("pur_branch", "Selcet Branch.");
                    errors.Add("pur_supplier", "Select Supplier.");
                    errors.Add("pur_odate", "Enter Purchase Order Date.");
                    errors.Add("pur_type", "Select Order Type.");
                }
                if (data.purchaseItems != null)
                {
                    int index = 0;
                    foreach (PurchaseOrderItems items in data.purchaseItems)
                    {
                        index++;
                        if (!int.TryParse(items.pi_item.ToString(), out int _out))
                        {
                            errors.Add("item_name" + index, "Select Purchase Item.");
                        }
                        if (string.IsNullOrEmpty(items.pi_uom))
                        {
                            errors.Add("pi_uom" + index, "Select Item UoM.");
                        }
                        if (string.IsNullOrEmpty(items.pi_disc_type))
                        {
                            errors.Add("item_disc_type" + index, "Select Item Discount Type.");
                        }

                        if (isValidDecimal(items.pi_uprice.ToString()))
                        {
                            if (items.pi_uprice <= 0)
                                errors.Add("item_price" + index, "Item Price Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_price" + index, "Item Price is Not in Correct Format.");

                        if (isValidDecimal(items.pi_oqty.ToString()))
                        {
                            if (items.pi_oqty <= 0)
                                errors.Add("item_qty" + index, "Item Qty Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_qty" + index, "Item Qty is Not in Correct Format.");

                        if (isValidDecimal(items.pi_total.ToString()))
                        {
                            if (items.pi_total <= 0)
                                errors.Add("item_total" + index, "Item Total Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_total" + index, "Item Total is Not in Correct Format.");

                        if (!isValidDecimal(items.pi_disc.ToString()))
                        {
                            errors.Add("item_disc" + index, "Item Discount is Not in Correct Format.");
                        }
                        if (!isValidDecimal(items.pi_disc_value.ToString()))
                        {
                            errors.Add("item_disc_value" + index, "Item Disc. Value is Not in Correct Format.");
                        }
                        if (isValidDecimal(items.pi_net.ToString()))
                        {
                            if (items.pi_net <= 0)
                                errors.Add("item_net" + index, "Item Net Amount Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_net" + index, "Item Net Amount is Not in Correct Format.");

                        if (!isValidDecimal(items.pi_vat.ToString()))
                        {
                            errors.Add("item_vat" + index, "Item VAT Amount is Not in Correct Format.");
                        }


                        if (!string.IsNullOrEmpty(data.purchaseOrders.pur_type))
                        {
                            if (data.purchaseOrders.pur_type == "Purchase Invoice" || data.purchaseOrders.pur_type == "GRN Regular")
                            {
                                if (string.IsNullOrEmpty(items.pi_batch))
                                    errors.Add("item_batch" + index, "Enter Item Batch No#.");

                                if (string.IsNullOrEmpty(items.pi_edate))
                                {
                                    errors.Add("item_expiry" + index, "Enter Item Batch Expiry Date.");
                                }
                                else
                                {
                                    if (!DateTime.TryParse(items.pi_edate.ToString(), out DateTime _out6))
                                        errors.Add("item_expiry" + index, "Item Batch Expiry Date is not in Correct Format.");
                                }

                            }
                            else
                            {
                                items.pi_batch = string.Empty;
                                items.pi_edate = DateTime.Now.AddYears(10).ToString();
                            }
                        }

                        if (!isValidDecimal(items.pi_freeQty.ToString()))
                        {
                            errors.Add("item_qty_free" + index, "Item Free Qty is Not in Correct Format.");
                        }
                        else
                        {
                            if (items.pi_freeQty > 0)
                            {
                                if (string.IsNullOrEmpty(items.pi_freeUOM))
                                {
                                    errors.Add("item_uom_free" + index, "Enter Free Qty UoM.");
                                }
                                if (data.purchaseOrders.pur_type == "Purchase Invoice" || data.purchaseOrders.pur_type == "GRN Regular")
                                {
                                    if (string.IsNullOrEmpty(items.pi_freeBatch))
                                    {
                                        errors.Add("item_batch_free" + index, "Enter Free Qty Batch No#.");
                                    }
                                    if (string.IsNullOrEmpty(items.pi_freeExpiry))
                                    {
                                        errors.Add("item_expiry" + index, "Enter Free Item Batch Expiry Date.");
                                    }
                                    else
                                    {
                                        if (!DateTime.TryParse(items.pi_freeExpiry.ToString(), out DateTime _out8))
                                            errors.Add("item_expiry_free" + index, "Free Item Batch Expiry Date is not in Correct Format.");
                                    }
                                }
                            }
                            else
                            {
                                items.pi_freeUOM = items.pi_uom;
                                items.pi_freeBatch = string.Empty;
                                items.pi_freeExpiry = DateTime.Now.AddYears(10).ToString();
                            }

                        }
                        if (string.IsNullOrEmpty(items.pi_desc))
                            items.pi_desc = string.Empty;
                    }
                }
                else
                    errors.Add("form_poitems", "Enter Purchase Order Items Detail.");
            }
            else
            {
                errors.Add("pur_branch", "Selcet Branch.");
                errors.Add("pur_supplier", "Select Supplier.");
                errors.Add("pur_odate", "Enter Purchase Order Date.");
                errors.Add("pur_type", "Select Order Type.");
                errors.Add("pur_total", "Enter Purchase Order Items Detail.");
                errors.Add("form_poitems", "Enter Purchase Order Items Detail.");
                errors.Add("item_name", "Item Price Should be Greater than 0.");
                errors.Add("item_price", "Item Price Should be Greater than 0.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidUpdatePO(PurchaseOrderAndItems data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data != null)
            {
                if (data.purchaseOrders != null)
                {
                    try
                    {
                        if (data.purchaseOrders.pur_branch <= 0)
                        {
                            errors.Add("pur_branch", "Selcet Branch.");
                        }

                        if (data.purchaseOrders.pur_supplier <= 0)
                        {
                            errors.Add("pur_supplier", "Select Supplier.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_type))
                        {
                            errors.Add("pur_type", "Select Order Type.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_odate))
                        {
                            errors.Add("pur_odate", "Enter Purchase Order Date.");
                        }
                        else
                        {
                            if (!DateTime.TryParse(data.purchaseOrders.pur_odate.ToString(), out DateTime _out))
                                errors.Add("pur_odate", "Purchase Order Date is not in Correct Format.");
                        }

                        if (!int.TryParse(data.purchaseOrders.pur_validity.ToString(), out int _out2))
                            data.purchaseOrders.pur_validity = 0;

                        if (!int.TryParse(data.purchaseOrders.pur_pay_terms.ToString(), out int _out3))
                            data.purchaseOrders.pur_pay_terms = 0;

                        if (!string.IsNullOrEmpty(data.purchaseOrders.pur_qdate))
                        {
                            if (!DateTime.TryParse(data.purchaseOrders.pur_qdate.ToString(), out DateTime _out4))
                                errors.Add("pur_odate", "Quotation Date is not in Correct Format.");
                        }
                        else
                            data.purchaseOrders.pur_qdate = DateTime.Now.ToString();

                        if (!string.IsNullOrEmpty(data.purchaseOrders.pur_type))
                        {
                            if (data.purchaseOrders.pur_type == "Purchase Invoice" || data.purchaseOrders.pur_type == "GRN Regular")
                            {
                                if (string.IsNullOrEmpty(data.purchaseOrders.pur_sup_invoice))
                                    errors.Add("pur_sup_invoice", "Enter Supplier Purchase Invoice.");
                            }
                        }

                        if (!string.IsNullOrEmpty(data.purchaseOrders.pur_ship_4))
                        {
                            if (!EmailValidation.isValidEmail(data.purchaseOrders.pur_ship_4))
                            {
                                errors.Add("pur_ship_4", "Ship To Email is not in Correct Format.");
                            }
                        }

                        if (!string.IsNullOrEmpty(data.purchaseOrders.pur_bill_4))
                        {
                            if (!EmailValidation.isValidEmail(data.purchaseOrders.pur_bill_4))
                            {
                                errors.Add("pur_bill_4", "Bill To Email is not in Correct Format.");
                            }
                        }

                        if (!string.IsNullOrEmpty(data.purchaseOrders.pur_buy_4))
                        {
                            if (!EmailValidation.isValidEmail(data.purchaseOrders.pur_buy_4))
                            {
                                errors.Add("pur_buy_4", "Buyer Email is not in Correct Format.");
                            }
                        }

                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_account))
                            data.purchaseOrders.pur_account = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_notes))
                            data.purchaseOrders.pur_notes = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_enqno))
                            data.purchaseOrders.pur_enqno = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_quono))
                            data.purchaseOrders.pur_quono = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_buy_1))
                            data.purchaseOrders.pur_buy_1 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_buy_2))
                            data.purchaseOrders.pur_buy_2 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_buy_3))
                            data.purchaseOrders.pur_buy_3 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_buy_4))
                            data.purchaseOrders.pur_buy_4 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseOrders.pur_sup_invoice))
                            data.purchaseOrders.pur_sup_invoice = string.Empty;

                    }
                    catch (Exception ex)
                    {
                        errors.Add("Error : ", " " + ex.Message);
                    }
                }
                else
                {
                    errors.Add("pur_branch", "Selcet Branch.");
                    errors.Add("pur_supplier", "Select Supplier.");
                    errors.Add("pur_odate", "Enter Purchase Order Date.");
                    errors.Add("pur_type", "Select Order Type.");
                }
                if (data.purchaseItems != null)
                {
                    int index = 0;
                    foreach (PurchaseOrderItems items in data.purchaseItems)
                    {
                        index++;
                        if (!int.TryParse(items.pi_item.ToString(), out int _out))
                        {
                            errors.Add("item_name" + index, "Select Purchase Item.");
                        }
                        if (string.IsNullOrEmpty(items.pi_uom))
                        {
                            errors.Add("pi_uom" + index, "Select Item UoM.");
                        }
                        if (string.IsNullOrEmpty(items.pi_disc_type))
                        {
                            errors.Add("item_disc_type" + index, "Select Item Discount Type.");
                        }

                        if (isValidDecimal(items.pi_uprice.ToString()))
                        {
                            if (items.pi_uprice <= 0)
                                errors.Add("item_price" + index, "Item Price Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_price" + index, "Item Price is Not in Correct Format.");

                        if (isValidDecimal(items.pi_oqty.ToString()))
                        {
                            if (items.pi_oqty <= 0)
                                errors.Add("item_qty" + index, "Item Qty Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_qty" + index, "Item Qty is Not in Correct Format.");

                        if (isValidDecimal(items.pi_total.ToString()))
                        {
                            if (items.pi_total <= 0)
                                errors.Add("item_total" + index, "Item Total Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_total" + index, "Item Total is Not in Correct Format.");

                        if (!isValidDecimal(items.pi_disc.ToString()))
                        {
                            errors.Add("item_disc" + index, "Item Discount is Not in Correct Format.");
                        }
                        if (!isValidDecimal(items.pi_disc_value.ToString()))
                        {
                            errors.Add("item_disc_value" + index, "Item Disc. Value is Not in Correct Format.");
                        }
                        if (isValidDecimal(items.pi_net.ToString()))
                        {
                            if (items.pi_net <= 0)
                                errors.Add("item_net" + index, "Item Net Amount Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_net" + index, "Item Net Amount is Not in Correct Format.");

                        if (!isValidDecimal(items.pi_vat.ToString()))
                        {
                            errors.Add("item_vat" + index, "Item VAT Amount is Not in Correct Format.");
                        }


                        if (!string.IsNullOrEmpty(data.purchaseOrders.pur_type))
                        {
                            if (data.purchaseOrders.pur_type == "Purchase Invoice" || data.purchaseOrders.pur_type == "GRN Regular")
                            {
                                if (string.IsNullOrEmpty(items.pi_batch))
                                    errors.Add("item_batch" + index, index + "Enter Item Batch No#.");

                                if (string.IsNullOrEmpty(items.pi_edate))
                                {
                                    errors.Add("item_expiry" + index, index + "Enter Item Batch Expiry Date.");
                                }
                                else
                                {
                                    if (!DateTime.TryParse(items.pi_edate.ToString(), out DateTime _out6))
                                        errors.Add("item_expiry" + index, index + "Item Batch Expiry Date is not in Correct Format.");
                                }

                            }
                            else
                            {
                                items.pi_batch = string.Empty;
                                items.pi_edate = DateTime.Now.AddYears(10).ToString();
                            }
                        }

                        if (!isValidDecimal(items.pi_freeQty.ToString()))
                        {
                            errors.Add("item_qty_free" + index, "Item Free Qty is Not in Correct Format.");
                        }
                        else
                        {
                            if (items.pi_freeQty > 0)
                            {
                                if (string.IsNullOrEmpty(items.pi_freeUOM))
                                {
                                    errors.Add("item_uom_free" + index, "Enter Free Qty UoM.");
                                }
                                if (data.purchaseOrders.pur_type == "Purchase Invoice" || data.purchaseOrders.pur_type == "GRN Regular")
                                {
                                    if (string.IsNullOrEmpty(items.pi_freeBatch))
                                    {
                                        errors.Add("item_batch_free" + index, "Enter Free Qty Batch No#.");
                                    }
                                    if (string.IsNullOrEmpty(items.pi_freeExpiry))
                                    {
                                        errors.Add("item_expiry" + index, "Enter Free Item Batch Expiry Date.");
                                    }
                                    else
                                    {
                                        if (!DateTime.TryParse(items.pi_freeExpiry.ToString(), out DateTime _out8))
                                            errors.Add("item_expiry_free" + index, "Free Item Batch Expiry Date is not in Correct Format.");
                                    }
                                }
                            }
                            else
                            {
                                items.pi_freeUOM = items.pi_uom;
                                items.pi_freeBatch = string.Empty;
                                items.pi_freeExpiry = DateTime.Now.AddYears(10).ToString();
                            }

                        }
                        if (string.IsNullOrEmpty(items.pi_desc))
                            items.pi_desc = string.Empty;
                    }
                }
                else
                    errors.Add("form_poitems", "Enter Purchase Order Items Detail.");
            }
            else
            {
                errors.Add("pur_branch", "Selcet Branch.");
                errors.Add("pur_supplier", "Select Supplier.");
                errors.Add("pur_odate", "Enter Purchase Order Date.");
                errors.Add("pur_type", "Select Order Type.");
                errors.Add("pur_total", "Enter Purchase Order Items Detail.");
                errors.Add("form_poitems", "Enter Purchase Order Items Detail.");
                errors.Add("item_name", "Item Price Should be Greater than 0.");
                errors.Add("item_price", "Item Price Should be Greater than 0.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidPurchaseRequestInsert(PurchaseRequestsAndItems data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (data.purchaseRequests != null)
                {
                    try
                    {
                        if (data.purchaseRequests.purq_branch <= 0)
                        {
                            errors.Add("purq_branch", "Select Branch.");
                        }

                        if (data.purchaseRequests.purq_supplier <= 0)
                        {
                            errors.Add("purq_supplier", "Select Supplier.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_type))
                        {
                            errors.Add("purq_type", "Select Request Type.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_odate))
                        {
                            errors.Add("purq_odate", "Enter Purchase Request Date.");
                        }
                        else
                        {
                            if (!DateTime.TryParse(data.purchaseRequests.purq_odate.ToString(), out DateTime _out))
                                errors.Add("purq_odate", "Purchase Request Date is not in Correct Format.");
                        }

                        if (!int.TryParse(data.purchaseRequests.purq_validity.ToString(), out int _out2))
                            data.purchaseRequests.purq_validity = 0;

                        if (!int.TryParse(data.purchaseRequests.purq_pay_terms.ToString(), out int _out3))
                            data.purchaseRequests.purq_pay_terms = 0;

                        if (!string.IsNullOrEmpty(data.purchaseRequests.purq_qdate))
                        {
                            if (!DateTime.TryParse(data.purchaseRequests.purq_qdate.ToString(), out DateTime _out4))
                                errors.Add("purq_qdate", "Quotation Date is not in Correct Format.");
                        }
                        else
                            data.purchaseRequests.purq_qdate = DateTime.Now.ToString();

                        if (!string.IsNullOrEmpty(data.purchaseRequests.purq_type))
                        {
                            if (data.purchaseRequests.purq_type == "Purchase Invoice" || data.purchaseRequests.purq_type == "GRN Regular")
                            {
                                if (string.IsNullOrEmpty(data.purchaseRequests.purq_sup_invoice))
                                    errors.Add("purq_sup_invoice", "Enter Supplier Purchase Invoice.");
                            }
                        }

                        if (!string.IsNullOrEmpty(data.purchaseRequests.purq_ship_4))
                        {
                            if (!EmailValidation.isValidEmail(data.purchaseRequests.purq_ship_4))
                            {
                                errors.Add("purq_ship_4", "Ship To Email is not in Correct Format.");
                            }
                        }

                        if (!string.IsNullOrEmpty(data.purchaseRequests.purq_bill_4))
                        {
                            if (!EmailValidation.isValidEmail(data.purchaseRequests.purq_bill_4))
                            {
                                errors.Add("purq_bill_4", "Bill To Email is not in Correct Format.");
                            }
                        }

                        if (!string.IsNullOrEmpty(data.purchaseRequests.purq_buy_4))
                        {
                            if (!EmailValidation.isValidEmail(data.purchaseRequests.purq_buy_4))
                            {
                                errors.Add("purq_buy_4", "Buyer Email is not in Correct Format.");
                            }
                        }

                        if (isValidDecimal(data.purchaseRequests.purq_total.ToString()))
                        {
                            if (data.purchaseRequests.purq_total <= 0)
                                errors.Add("purq_total", "Total Amount Should be Greater than 0.");
                        }
                        else
                            errors.Add("purq_total", "Total Amount is Not in Correct Format.");

                        if (isValidDecimal(data.purchaseRequests.purq_net.ToString()))
                        {
                            if (data.purchaseRequests.purq_net <= 0)
                                errors.Add("purq_net", "Net Amount Should be Greater than 0.");
                        }
                        else
                            errors.Add("purq_net", "Net Amount is Not in Correct Format.");

                        if (!isValidDecimal(data.purchaseRequests.purq_vat.ToString()))
                        {
                            errors.Add("purq_vat", "VAT Amount is Not in Correct Format.");
                        }

                        if (!isValidDecimal(data.purchaseRequests.purq_disc_val.ToString()))
                        {
                            errors.Add("purq_disc_val", "Discount Amount is Not in Correct Format.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_account))
                            data.purchaseRequests.purq_account = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_notes))
                            data.purchaseRequests.purq_notes = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_enqno))
                            data.purchaseRequests.purq_enqno = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_quono))
                            data.purchaseRequests.purq_quono = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_buy_1))
                            data.purchaseRequests.purq_buy_1 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_buy_2))
                            data.purchaseRequests.purq_buy_2 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_buy_3))
                            data.purchaseRequests.purq_buy_3 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_buy_4))
                            data.purchaseRequests.purq_buy_4 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_sup_invoice))
                            data.purchaseRequests.purq_sup_invoice = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        errors.Add("Error : ", " " + ex.Message);
                    }
                }
                else
                {
                    errors.Add("purq_branch", "Select Branch.");
                    errors.Add("purq_supplier", "Select Supplier.");
                    errors.Add("purq_odate", "Enter Purchase Request Date.");
                    errors.Add("purq_type", "Select Request Type.");
                }

                if (data.purchaseRequestItems != null)
                {
                    int index = 0;

                    foreach (PurchaseRequestItems items in data.purchaseRequestItems)
                    {
                        index++;
                        if (!int.TryParse(items.prqi_item.ToString(), out int _out))
                        {
                            errors.Add("item_name" + index, "Select Purchase Item.");
                        }
                        if (string.IsNullOrEmpty(items.prqi_uom))
                        {
                            errors.Add("prqi_uom" + index, "Select Item UoM.");
                        }
                        if (string.IsNullOrEmpty(items.prqi_disc_type))
                        {
                            errors.Add("item_disc_type" + index, "Select Item Discount Type.");
                        }

                        if (isValidDecimal(items.prqi_uprice.ToString()))
                        {
                            if (items.prqi_uprice <= 0)
                                errors.Add("item_price" + index, "Item Price Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_price" + index, "Item Price is Not in Correct Format.");

                        if (isValidDecimal(items.prqi_oqty.ToString()))
                        {
                            if (items.prqi_oqty <= 0)
                                errors.Add("item_qty" + index, "Item Qty Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_qty" + index, "Item Qty is Not in Correct Format.");

                        if (isValidDecimal(items.prqi_total.ToString()))
                        {
                            if (items.prqi_total <= 0)
                                errors.Add("item_total" + index, "Item Total Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_total" + index, "Item Total is Not in Correct Format.");

                        if (!isValidDecimal(items.prqi_disc.ToString()))
                        {
                            errors.Add("item_disc" + index, "Item Discount is Not in Correct Format.");
                        }
                        if (!isValidDecimal(items.prqi_disc_value.ToString()))
                        {
                            errors.Add("item_disc_value" + index, "Item Disc. Value is Not in Correct Format.");
                        }
                        if (isValidDecimal(items.prqi_net.ToString()))
                        {
                            if (items.prqi_net <= 0)
                                errors.Add("item_net" + index, "Item Net Amount Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_net" + index, "Item Net Amount is Not in Correct Format.");

                        if (!isValidDecimal(items.prqi_vat.ToString()))
                        {
                            errors.Add("item_vat" + index, "Item VAT Amount is Not in Correct Format.");
                        }


                        if (!string.IsNullOrEmpty(data.purchaseRequests.purq_type))
                        {
                            if (data.purchaseRequests.purq_type == "Purchase Invoice" || data.purchaseRequests.purq_type == "GRN Regular")
                            {
                                if (string.IsNullOrEmpty(items.prqi_batch))
                                    errors.Add("item_batch" + index, "Enter Item Batch No#.");

                                if (string.IsNullOrEmpty(items.prqi_edate))
                                {
                                    errors.Add("item_expiry" + index, "Enter Item Batch Expiry Date.");
                                }
                                else
                                {
                                    if (!DateTime.TryParse(items.prqi_edate.ToString(), out DateTime _out6))
                                        errors.Add("item_expiry" + index, "Item Batch Expiry Date is not in Correct Format.");
                                }

                            }
                            else
                            {
                                items.prqi_batch = string.Empty;
                                items.prqi_edate = DateTime.Now.AddYears(10).ToString();
                            }
                        }

                        if (!isValidDecimal(items.prqi_freeQty.ToString()))
                        {
                            errors.Add("item_qty_free" + index, "Item Free Qty is Not in Correct Format.");
                        }
                        else
                        {
                            if (items.prqi_freeQty > 0)
                            {
                                if (string.IsNullOrEmpty(items.prqi_freeUOM))
                                {
                                    errors.Add("item_uom_free" + index, "Enter Free Qty UoM.");
                                }
                                if (data.purchaseRequests.purq_type == "Purchase Invoice" || data.purchaseRequests.purq_type == "GRN Regular")
                                {
                                    if (string.IsNullOrEmpty(items.prqi_freeBatch))
                                    {
                                        errors.Add("item_batch_free" + index, "Enter Free Qty Batch No#.");
                                    }
                                    if (string.IsNullOrEmpty(items.prqi_freeExpiry))
                                    {
                                        errors.Add("item_expiry" + index, "Enter Free Item Batch Expiry Date.");
                                    }
                                    else
                                    {
                                        if (!DateTime.TryParse(items.prqi_freeExpiry.ToString(), out DateTime _out8))
                                            errors.Add("item_expiry_free" + index, "Free Item Batch Expiry Date is not in Correct Format.");
                                    }
                                }
                            }
                            else
                            {
                                items.prqi_freeUOM = items.prqi_uom;
                                items.prqi_freeBatch = string.Empty;
                                items.prqi_freeExpiry = DateTime.Now.AddYears(10).ToString();
                            }

                        }
                        if (string.IsNullOrEmpty(items.prqi_desc))
                            items.prqi_desc = string.Empty;
                    }
                }
                else
                    errors.Add("form_pritems", "Enter Purchase Request Items Detail.");
            }
            else
            {
                errors.Add("purq_branch", "Selcet Branch.");
                errors.Add("purq_supplier", "Select Supplier.");
                errors.Add("purq_odate", "Enter Purchase Request Date.");
                errors.Add("purq_type", "Select Request Type.");
                errors.Add("purq_total", "Enter Purchase Request Items Detail.");
                errors.Add("form_poitems", "Enter Purchase Request Items Detail.");
                errors.Add("item_name", "Item Price Should be Greater than 0.");
                errors.Add("item_price", "Item Price Should be Greater than 0.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidPurchaseRequestUpdate(PurchaseRequestsAndItems data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();

            if (data != null)
            {
                if (data.purchaseRequests != null)
                {
                    try
                    {
                        if (data.purchaseRequests.purq_branch <= 0)
                        {
                            errors.Add("purq_branch", "Selcet Branch.");
                        }

                        if (data.purchaseRequests.purq_supplier <= 0)
                        {
                            errors.Add("purq_supplier", "Select Supplier.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_type))
                        {
                            errors.Add("purq_type", "Select Request Type.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_odate))
                        {
                            errors.Add("purq_odate", "Enter Purchase Request Date.");
                        }
                        else
                        {
                            if (!DateTime.TryParse(data.purchaseRequests.purq_odate.ToString(), out DateTime _out))
                                errors.Add("purq_odate", "Purchase Request Date is not in Correct Format.");
                        }

                        if (!int.TryParse(data.purchaseRequests.purq_validity.ToString(), out int _out2))
                            data.purchaseRequests.purq_validity = 0;

                        if (!int.TryParse(data.purchaseRequests.purq_pay_terms.ToString(), out int _out3))
                            data.purchaseRequests.purq_pay_terms = 0;

                        if (!string.IsNullOrEmpty(data.purchaseRequests.purq_qdate))
                        {
                            if (!DateTime.TryParse(data.purchaseRequests.purq_qdate.ToString(), out DateTime _out4))
                                errors.Add("purq_odate", "Quotation Date is not in Correct Format.");
                        }
                        else
                            data.purchaseRequests.purq_qdate = DateTime.Now.ToString();

                        if (!string.IsNullOrEmpty(data.purchaseRequests.purq_type))
                        {
                            if (data.purchaseRequests.purq_type == "Purchase Invoice" || data.purchaseRequests.purq_type == "GRN Regular")
                            {
                                if (string.IsNullOrEmpty(data.purchaseRequests.purq_sup_invoice))
                                    errors.Add("purq_sup_invoice", "Enter Supplier Purchase Invoice.");
                            }
                        }

                        if (!string.IsNullOrEmpty(data.purchaseRequests.purq_ship_4))
                        {
                            if (!EmailValidation.isValidEmail(data.purchaseRequests.purq_ship_4))
                            {
                                errors.Add("purq_ship_4", "Ship To Email is not in Correct Format.");
                            }
                        }

                        if (!string.IsNullOrEmpty(data.purchaseRequests.purq_bill_4))
                        {
                            if (!EmailValidation.isValidEmail(data.purchaseRequests.purq_bill_4))
                            {
                                errors.Add("purq_bill_4", "Bill To Email is not in Correct Format.");
                            }
                        }

                        if (!string.IsNullOrEmpty(data.purchaseRequests.purq_buy_4))
                        {
                            if (!EmailValidation.isValidEmail(data.purchaseRequests.purq_buy_4))
                            {
                                errors.Add("purq_buy_4", "Buyer Email is not in Correct Format.");
                            }
                        }

                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_account))
                            data.purchaseRequests.purq_account = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_notes))
                            data.purchaseRequests.purq_notes = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_enqno))
                            data.purchaseRequests.purq_enqno = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_quono))
                            data.purchaseRequests.purq_quono = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_buy_1))
                            data.purchaseRequests.purq_buy_1 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_buy_2))
                            data.purchaseRequests.purq_buy_2 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_buy_3))
                            data.purchaseRequests.purq_buy_3 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_buy_4))
                            data.purchaseRequests.purq_buy_4 = string.Empty;
                        if (string.IsNullOrEmpty(data.purchaseRequests.purq_sup_invoice))
                            data.purchaseRequests.purq_sup_invoice = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        errors.Add("Error : ", " " + ex.Message);
                    }
                }
                else
                {
                    errors.Add("purq_branch", "Selcet Branch.");
                    errors.Add("purq_supplier", "Select Supplier.");
                    errors.Add("purq_odate", "Enter Purchase Request Date.");
                    errors.Add("purq_type", "Select Request Type.");
                }

                if (data.purchaseRequestItems != null)
                {
                    int index = 0;

                    foreach (PurchaseRequestItems items in data.purchaseRequestItems)
                    {
                        index++;
                        if (!int.TryParse(items.prqi_item.ToString(), out int _out))
                        {
                            errors.Add("item_name" + index, "Select Purchase Item.");
                        }
                        if (string.IsNullOrEmpty(items.prqi_uom))
                        {
                            errors.Add("prqi_uom" + index, "Select Item UoM.");
                        }
                        if (string.IsNullOrEmpty(items.prqi_disc_type))
                        {
                            errors.Add("item_disc_type" + index, "Select Item Discount Type.");
                        }

                        if (isValidDecimal(items.prqi_uprice.ToString()))
                        {
                            if (items.prqi_uprice <= 0)
                                errors.Add("item_price" + index, "Item Price Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_price" + index, "Item Price is Not in Correct Format.");

                        if (isValidDecimal(items.prqi_oqty.ToString()))
                        {
                            if (items.prqi_oqty <= 0)
                                errors.Add("item_qty" + index, "Item Qty Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_qty" + index, "Item Qty is Not in Correct Format.");

                        if (isValidDecimal(items.prqi_total.ToString()))
                        {
                            if (items.prqi_total <= 0)
                                errors.Add("item_total" + index, "Item Total Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_total" + index, "Item Total is Not in Correct Format.");

                        if (!isValidDecimal(items.prqi_disc.ToString()))
                        {
                            errors.Add("item_disc" + index, "Item Discount is Not in Correct Format.");
                        }
                        if (!isValidDecimal(items.prqi_disc_value.ToString()))
                        {
                            errors.Add("item_disc_value" + index, "Item Disc. Value is Not in Correct Format.");
                        }
                        if (isValidDecimal(items.prqi_net.ToString()))
                        {
                            if (items.prqi_net <= 0)
                                errors.Add("item_net" + index, "Item Net Amount Should be Greater than 0.");
                        }
                        else
                            errors.Add("item_net" + index, "Item Net Amount is Not in Correct Format.");

                        if (!isValidDecimal(items.prqi_vat.ToString()))
                        {
                            errors.Add("item_vat" + index, "Item VAT Amount is Not in Correct Format.");
                        }


                        if (!string.IsNullOrEmpty(data.purchaseRequests.purq_type))
                        {
                            if (data.purchaseRequests.purq_type == "Purchase Invoice" || data.purchaseRequests.purq_type == "GRN Regular")
                            {
                                if (string.IsNullOrEmpty(items.prqi_batch))
                                    errors.Add("item_batch" + index, index + "Enter Item Batch No#.");

                                if (string.IsNullOrEmpty(items.prqi_edate))
                                {
                                    errors.Add("item_expiry" + index, index + "Enter Item Batch Expiry Date.");
                                }
                                else
                                {
                                    if (!DateTime.TryParse(items.prqi_edate.ToString(), out DateTime _out6))
                                        errors.Add("item_expiry" + index, index + "Item Batch Expiry Date is not in Correct Format.");
                                }
                            }
                            else
                            {
                                items.prqi_batch = string.Empty;
                                items.prqi_edate = DateTime.Now.AddYears(10).ToString();
                            }
                        }

                        if (!isValidDecimal(items.prqi_freeQty.ToString()))
                        {
                            errors.Add("item_qty_free" + index, "Item Free Qty is Not in Correct Format.");
                        }
                        else
                        {
                            if (items.prqi_freeQty > 0)
                            {
                                if (string.IsNullOrEmpty(items.prqi_freeUOM))
                                {
                                    errors.Add("item_uom_free" + index, "Enter Free Qty UoM.");
                                }
                                if (data.purchaseRequests.purq_type == "Purchase Invoice" || data.purchaseRequests.purq_type == "GRN Regular")
                                {
                                    if (string.IsNullOrEmpty(items.prqi_freeBatch))
                                    {
                                        errors.Add("item_batch_free" + index, "Enter Free Qty Batch No#.");
                                    }
                                    if (string.IsNullOrEmpty(items.prqi_freeExpiry))
                                    {
                                        errors.Add("item_expiry" + index, "Enter Free Item Batch Expiry Date.");
                                    }
                                    else
                                    {
                                        if (!DateTime.TryParse(items.prqi_freeExpiry.ToString(), out DateTime _out8))
                                            errors.Add("item_expiry_free" + index, "Free Item Batch Expiry Date is not in Correct Format.");
                                    }
                                }
                            }
                            else
                            {
                                items.prqi_freeUOM = items.prqi_uom;
                                items.prqi_freeBatch = string.Empty;
                                items.prqi_freeExpiry = DateTime.Now.AddYears(10).ToString();
                            }
                        }

                        if (string.IsNullOrEmpty(items.prqi_desc))
                            items.prqi_desc = string.Empty;
                    }
                }
                else
                    errors.Add("form_EditPurchaseRequest", "Enter Purchase Request Items Detail.");
            }
            else
            {
                errors.Add("purq_branch", "Selcet Branch.");
                errors.Add("purq_supplier", "Select Supplier.");
                errors.Add("purq_odate", "Enter Purchase Request Date.");
                errors.Add("purq_type", "Select Request Type.");
                errors.Add("purq_total", "Enter Purchase Request Items Detail.");
                errors.Add("form_EditPurchaseRequest", "Enter Purchase Request Items Detail.");
                errors.Add("item_name", "Item Price Should be Greater than 0.");
                errors.Add("item_price", "Item Price Should be Greater than 0.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidGRN(GRN_and_Items data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data != null)
            {
                if (data.grn != null)
                {
                    try
                    {
                        if (data.grn.pr_branch <= 0)
                        {
                            errors.Add("pr_branch", "Selcet Branch.");
                        }

                        if (data.grn.pr_PurchaseOrder <= 0)
                        {
                            errors.Add("pr_PurchaseOrder", "Select Purchase Order.");
                        }

                        if (string.IsNullOrEmpty(data.grn.pr_date))
                        {
                            errors.Add("pr_date", "Enter GRN Date.");
                        }
                        else
                        {
                            if (!DateTime.TryParse(data.grn.pr_date.ToString(), out DateTime _out))
                                errors.Add("pur_odate", "GRN Date is not in Correct Format.");
                        }

                        if (string.IsNullOrEmpty(data.grn.pr_supplier_inv_date))
                        {
                            errors.Add("pr_supplier_inv_date", "Enter Supplier GRN Date.");
                        }
                        else
                        {
                            if (!DateTime.TryParse(data.grn.pr_supplier_inv_date.ToString(), out DateTime _out))
                                errors.Add("pr_supplier_inv_date", "Supplier GRN Date is not in Correct Format.");
                        }

                        if (string.IsNullOrEmpty(data.grn.pr_notes))
                            data.grn.pr_notes = string.Empty;
                        data.grn.pr_supplier = 0;
                        if (string.IsNullOrEmpty(data.grn.pr_status))
                            data.grn.pr_status = "New";
                    }
                    catch (Exception ex)
                    {
                        errors.Add("Error : ", " " + ex.Message);
                    }
                }
                else
                {
                    errors.Add("prr_branch", "Selcet Branch.");
                    errors.Add("pr_date", "Enter Purchase Order Date.");
                    errors.Add("pr_PurchaseOrder", "Select Purchase Order.");
                    errors.Add("pr_supplier_inv", "Enter Supplier GRN No.#.");
                }
                if (data.grn_items != null)
                {
                    int index = 0;
                    foreach (GRN_ITEMS items in data.grn_items)
                    {
                        if (items.pir_received > 0)
                        {
                            index++;
                            items.pir_dmadeby = data.grn.pr_madeby;
                            items.pir_idate = data.grn.pr_date;
                            if (string.IsNullOrEmpty(items.pir_status))
                                items.pir_status = "New";

                            if (!int.TryParse(items.pir_pur_item.ToString(), out int _out))
                            {
                                errors.Add("pir_item" + index, "Select GRN Item.");
                            }
                            if (!int.TryParse(items.pir_branch.ToString(), out int _out3))
                            {
                                errors.Add("pir_branch" + index, "Select Item Branch.");
                            }
                            if (string.IsNullOrEmpty(items.pir_grnno))
                            {
                                errors.Add("pir_grnno" + index, "Enter Supplier GRN.");
                            }
                            if (string.IsNullOrEmpty(items.pir_ddate))
                            {
                                errors.Add("pir_ddate" + index, "Enter GRN Date.");
                            }
                            else
                            {
                                if (!DateTime.TryParse(items.pir_ddate.ToString(), out DateTime _out6))
                                    errors.Add("item_expiry" + index, "GRN Date is not in Correct Format.");
                            }
                            if (string.IsNullOrEmpty(items.pir_edate))
                            {
                                errors.Add("pir_edate" + index, "Enter Batch Expiry Date.");
                            }
                            else
                            {
                                if (!DateTime.TryParse(items.pir_edate.ToString(), out DateTime _out6))
                                    errors.Add("pir_edate" + index, "Batch Expiry Date is not in Correct Format.");
                            }
                            if (!int.TryParse(items.pir_purchase.ToString(), out int _out2))
                            {
                                errors.Add("pir_purchase" + index, "Select GRN Item.");
                            }

                            if (string.IsNullOrEmpty(items.pir_batchno))
                            {
                                errors.Add("pir_batchno" + index, "Enter GRN Item Batch.");
                            }

                            if (string.IsNullOrEmpty(items.pir_uom))
                            {
                                errors.Add("pir_uom" + index, "Select GRN Item UoM.");
                            }

                            if (isValidDecimal(items.pir_uprice.ToString()))
                            {
                                if (items.pir_uprice <= 0)
                                    errors.Add("pir_uprice" + index, "Item Price Should be Greater than 0.");
                            }
                            else
                                errors.Add("pir_uprice" + index, "Item Price is Not in Correct Format.");


                            if (!isValidDecimal(items.pir_free_qty.ToString()))
                            {
                                errors.Add("pir_free_qty" + index, "Item Free Qty is Not in Correct Format.");
                            }
                            else
                            {
                                if (items.pir_free_qty > 0)
                                {
                                    if (string.IsNullOrEmpty(items.pir_fuom))
                                    {
                                        errors.Add("pir_fuom" + index, "Enter Free Qty UoM.");
                                    }
                                    if (string.IsNullOrEmpty(items.pir_freeBatch))
                                    {
                                        errors.Add("pir_freeBatch" + index, "Enter Free Qty Batch No#.");
                                    }
                                    if (string.IsNullOrEmpty(items.pir_freeExpiry))
                                    {
                                        errors.Add("pir_freeExpiry" + index, "Enter Free Item Batch Expiry Date.");
                                    }
                                    else
                                    {
                                        if (!DateTime.TryParse(items.pir_freeExpiry.ToString(), out DateTime _out8))
                                            errors.Add("pir_freeExpiry" + index, "Free Item Batch Expiry Date is not in Correct Format.");
                                    }
                                }
                                else
                                {
                                    items.pir_fuom = items.pir_uom;
                                    items.pir_freeBatch = string.Empty;
                                    items.pir_freeExpiry = DateTime.Now.AddYears(10).ToString();
                                }

                            }
                        }

                    }

                    if (index == 0)
                    {
                        errors.Add("form_poitems", "Enter Atleast One GRN Detail.");
                    }
                }
                else
                    errors.Add("form_poitems", "Enter Atleast One GRN Detail..");
            }
            else
            {
                errors.Add("prr_branch", "Selcet Branch.");
                errors.Add("pr_date", "Enter Purchase Order Date.");
                errors.Add("pr_PurchaseOrder", "Select Purchase Order.");
                errors.Add("pr_supplier_inv", "Enter Supplier GRN No.#.");
                errors.Add("form_poitems", "Enter Atleast One GRN Detail.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidUpdateGRN(GRN_and_Items data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data != null)
            {
                if (data.grn != null)
                {
                    try
                    {
                        if (data.grn.prId <= 0)
                        {
                            errors.Add("prId", "GRN code is no correct .");
                        }
                        if (string.IsNullOrEmpty(data.grn.pr_date))
                        {
                            errors.Add("pr_date", "Enter GRN Date.");
                        }
                        else
                        {
                            if (!DateTime.TryParse(data.grn.pr_date.ToString(), out DateTime _out))
                                errors.Add("pur_odate", "GRN Date is not in Correct Format.");
                        }

                        if (string.IsNullOrEmpty(data.grn.pr_supplier_inv_date))
                        {
                            errors.Add("pr_supplier_inv_date", "Enter Supplier GRN Date.");
                        }
                        else
                        {
                            if (!DateTime.TryParse(data.grn.pr_supplier_inv_date.ToString(), out DateTime _out))
                                errors.Add("pr_supplier_inv_date", "Supplier GRN Date is not in Correct Format.");
                        }
                    }
                    catch (Exception ex)
                    {
                        errors.Add("Error : ", " " + ex.Message);
                    }
                }
                else
                {
                    errors.Add("prr_branch", "Selcet Branch.");
                    errors.Add("pr_date", "Enter Purchase Order Date.");
                    errors.Add("pr_PurchaseOrder", "Select Purchase Order.");
                    errors.Add("pr_supplier_inv", "Enter Supplier GRN No.#.");
                }
                if (data.grn_items != null)
                {
                    int index = 0;
                    int count_ = 0;
                    foreach (GRN_ITEMS items in data.grn_items)
                    {
                        index++;
                        if (items.pir_received > 0)
                        {
                            count_++;
                        }
                        items.pir_dmadeby = data.grn.pr_madeby;
                        items.pir_idate = data.grn.pr_date;

                        if (!int.TryParse(items.pir_pur_item.ToString(), out int _out))
                        {
                            errors.Add("pir_item" + index, "Select GRN Item.");
                        }
                        if (string.IsNullOrEmpty(items.pir_grnno))
                        {
                            errors.Add("pir_grnno" + index, "Enter Supplier GRN.");
                        }
                        if (string.IsNullOrEmpty(items.pir_ddate))
                        {
                            errors.Add("pir_ddate" + index, "Enter GRN Date.");
                        }
                        else
                        {
                            if (!DateTime.TryParse(items.pir_ddate.ToString(), out DateTime _out6))
                                errors.Add("item_expiry" + index, "GRN Date is not in Correct Format.");
                        }
                        if (string.IsNullOrEmpty(items.pir_edate))
                        {
                            errors.Add("pir_edate" + index, "Enter Batch Expiry Date.");
                        }
                        else
                        {
                            if (!DateTime.TryParse(items.pir_edate.ToString(), out DateTime _out6))
                                errors.Add("pir_edate" + index, "Batch Expiry Date is not in Correct Format.");
                        }


                        if (string.IsNullOrEmpty(items.pir_batchno))
                        {
                            errors.Add("pir_batchno" + index, "Enter GRN Item Batch.");
                        }

                        if (string.IsNullOrEmpty(items.pir_uom))
                        {
                            errors.Add("pir_uom" + index, "Select GRN Item UoM.");
                        }

                        if (isValidDecimal(items.pir_uprice.ToString()))
                        {
                            if (items.pir_uprice <= 0)
                                errors.Add("pir_uprice" + index, "Item Price Should be Greater than 0.");
                        }
                        else
                            errors.Add("pir_uprice" + index, "Item Price is Not in Correct Format.");


                        if (!isValidDecimal(items.pir_free_qty.ToString()))
                        {
                            errors.Add("pir_free_qty" + index, "Item Free Qty is Not in Correct Format.");
                        }
                        else
                        {
                            if (items.pir_free_qty > 0)
                            {
                                if (string.IsNullOrEmpty(items.pir_fuom))
                                {
                                    errors.Add("pir_fuom" + index, "Enter Free Qty UoM.");
                                }
                                if (string.IsNullOrEmpty(items.pir_freeBatch))
                                {
                                    errors.Add("pir_freeBatch" + index, "Enter Free Qty Batch No#.");
                                }
                                if (string.IsNullOrEmpty(items.pir_freeExpiry))
                                {
                                    errors.Add("pir_freeExpiry" + index, "Enter Free Item Batch Expiry Date.");
                                }
                                else
                                {
                                    if (!DateTime.TryParse(items.pir_freeExpiry.ToString(), out DateTime _out8))
                                        errors.Add("pir_freeExpiry" + index, "Free Item Batch Expiry Date is not in Correct Format.");
                                }
                            }
                            else
                            {
                                items.pir_fuom = items.pir_uom;
                                items.pir_freeBatch = string.Empty;
                                items.pir_freeExpiry = DateTime.Now.AddYears(10).ToString();
                            }

                        }


                    }

                    if (count_ == 0)
                    {
                        errors.Add("form_poitems", "Enter Atleast One GRN Detail.");
                    }
                }
                else
                    errors.Add("form_poitems", "Enter Atleast One GRN Detail..");
            }
            else
            {
                errors.Add("prr_branch", "Selcet Branch.");
                errors.Add("pr_date", "Enter Purchase Order Date.");
                errors.Add("pr_PurchaseOrder", "Select Purchase Order.");
                errors.Add("pr_supplier_inv", "Enter Supplier GRN No.#.");
                errors.Add("form_poitems", "Enter Atleast One GRN Detail.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidPurchaseInvoice(purchaseInvoiceWithItems data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data != null)
            {
                if (data.purchaseInvoice != null)
                {
                    try
                    {
                        if (data.purchaseInvoice.pinv_supplier <= 0)
                        {
                            errors.Add("pinv_supplier", "Selcet Supplier.");
                        }

                        if (data.purchaseInvoice.pinv_branch <= 0)
                        {
                            errors.Add("pr_branch", "Selcet Branch.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseInvoice.pinv_grnIds))
                        {
                            errors.Add("pinv_grnId", "Select GRN.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseInvoice.pinv_idate))
                        {
                            errors.Add("pinv_idate", "Enter Invoice Date.");
                        }
                        else
                        {
                            if (!DateTime.TryParse(data.purchaseInvoice.pinv_idate.ToString(), out DateTime _out))
                                errors.Add("pinv_idate", "GRN Date is not in Correct Format.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseInvoice.pinv_invno))
                        {
                            errors.Add("pinv_invno", "Enter Supplier Invoice No.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseInvoice.pinv_notes))
                            data.purchaseInvoice.pinv_notes = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        errors.Add("Error : ", " " + ex.Message);
                    }
                }
                else
                {
                    errors.Add("pr_branch", "Selcet Branch.");
                    errors.Add("pinv_supplier", "Selcet Supplier.");
                    errors.Add("pinv_grnId", "Select GRN.");
                    errors.Add("pinv_idate", "Enter Invoice Date.");
                    errors.Add("pinv_invno", "Enter Supplier Invoice No.");
                }

                if (data.purchaseInvoiceItems != null)
                {
                    int index = 0;

                    foreach (PurchaseInvoiceItems items in data.purchaseInvoiceItems)
                    {
                        index++;

                        if (!int.TryParse(items.pit_preceived.ToString(), out int _out))
                        {
                            errors.Add("pir_item" + index, "Select GRN Item.");
                        }

                        if (string.IsNullOrEmpty(items.pit_notes))
                        {
                            items.pit_notes = string.Empty;
                        }
                        if (string.IsNullOrEmpty(items.pr_code))
                        {
                            errors.Add("pr_code" + index, "GRN Code Is not Correct");
                        }


                        if (!isValidDecimal(items.pit_total.ToString()))
                        {
                            errors.Add("pit_total" + index, "GRN Total is Not in Correct Format.");
                        }


                        if (!isValidDecimal(items.pit_disc_val.ToString()))
                        {
                            errors.Add("pit_disc_val" + index, "GRN Discount is Not in Correct Format.");
                        }


                        if (!isValidDecimal(items.pit_net.ToString()))
                        {
                            errors.Add("pit_net" + index, "GRN NET is Not in Correct Format.");
                        }


                        if (!isValidDecimal(items.pit_vat.ToString()))
                        {
                            errors.Add("pit_vat" + index, "GRN VAT is Not in Correct Format.");
                        }


                        if (!isValidDecimal(items.pit_net_vat.ToString()))
                        {
                            errors.Add("pit_net_vat" + index, "GRN Net + VAT is Not in Correct Format.");
                        }


                    }

                    if (index == 0)
                    {
                        errors.Add("form_poitems", "Enter Atleast One GRN Detail.");
                    }
                    else
                    {

                    }
                }
                else
                    errors.Add("form_poitems", "Enter Atleast One GRN Detail..");
            }
            else
            {
                errors.Add("pr_branch", "Selcet Branch.");
                errors.Add("pinv_supplier", "Selcet Supplier.");
                errors.Add("pinv_grnId", "Select GRN.");
                errors.Add("pinv_idate", "Enter Invoice Date.");
                errors.Add("pinv_invno", "Enter Supplier Invoice No.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidPurchaseReturn(PurchaseReturnWithItems data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data != null)
            {
                if (data.purchaseReturn != null)
                {
                    try
                    {
                        if (data.purchaseReturn.por_supplier <= 0)
                        {
                            errors.Add("por_supplier", "Selcet Supplier.");
                        }

                        if (data.purchaseReturn.por_branch <= 0)
                        {
                            errors.Add("por_branch", "Selcet Branch.");
                        }

                        if (data.purchaseReturn.por_purId <= 0)
                        {
                            errors.Add("por_purId", "Select Purchase Order.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseReturn.por_odate))
                        {
                            errors.Add("por_odate", "Enter Invoice Date.");
                        }
                        else
                        {
                            if (!DateTime.TryParse(data.purchaseReturn.por_odate.ToString(), out DateTime _out))
                                errors.Add("por_odate", "GRN Date is not in Correct Format.");
                        }

                        if (string.IsNullOrEmpty(data.purchaseReturn.por_notes))
                            data.purchaseReturn.por_notes = string.Empty;
                    }
                    catch (Exception ex)
                    {
                        errors.Add("Error : ", " " + ex.Message);
                    }
                }
                else
                {
                    errors.Add("por_supplier", "Selcet Supplier.");
                    errors.Add("por_branch", "Selcet Branch.");
                    errors.Add("por_purId", "Select Purchase Order.");
                    errors.Add("por_odate", "Enter Invoice Date.");
                }

                if (data.purchaseReturnItems != null)
                {
                    int index = 0;

                    foreach (PurchaseReturnItems items in data.purchaseReturnItems)
                    {
                        index++;

                        if (!int.TryParse(items.pire_purchase.ToString(), out int _out))
                        {
                            errors.Add("pire_purchase" + index, "Select Purchase Order.");
                        }
                        if (!int.TryParse(items.pire_ibId.ToString(), out int _out2))
                        {
                            errors.Add("pire_ibId" + index, "Select Return Items.");
                        }

                        if (string.IsNullOrEmpty(items.pire_edate))
                        {
                            errors.Add("pire_edate" + index, "Return Items Expiry Not Valid.");
                        }
                        if (string.IsNullOrEmpty(items.pire_batch))
                        {
                            errors.Add("pire_batch" + index, "Return Items Expiry Not Valid.");
                        }

                        if (string.IsNullOrEmpty(items.pire_uom))
                        {
                            errors.Add("pire_uom" + index, "Select Return Items UoM.");
                        }

                        if (string.IsNullOrEmpty(items.pire_desc))
                        {
                            items.pire_desc = string.Empty;
                        }


                        if (!isValidDecimal(items.pire_oqty.ToString()))
                        {
                            errors.Add("pire_oqty" + index, "Enter Return Qty is Not in Correct Format.");
                        }

                        if (!isValidDecimal(items.pire_uprice.ToString()))
                        {
                            errors.Add("pire_uprice" + index, "Enter Return Item Cost.");
                        }


                    }

                    if (index == 0)
                    {
                        errors.Add("form_poitems", "Enter Atleast One GRN Detail.");
                    }
                    else
                    {

                    }
                }
                else
                    errors.Add("form_poitems", "Enter Atleast One GRN Detail..");
            }
            else
            {
                errors.Add("pr_branch", "Selcet Branch.");
                errors.Add("pinv_supplier", "Selcet Supplier.");
                errors.Add("pinv_grnId", "Select GRN.");
                errors.Add("pinv_idate", "Enter Invoice Date.");
                errors.Add("pinv_invno", "Enter Supplier Invoice No.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidStockQtyAdjustment(StockQtyAdjustment_List data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data != null)
            {
                int index = 0;

                foreach (BusinessEntities.Accounts.MaterialManagement.StockQtyAdjustment items in data.stockQtyAdjustment_list)
                {
                    index++;

                    if (!int.TryParse(items.iqa_branch.ToString(), out int _out))
                    {
                        errors.Add("iqa_branch" + index, "Select Branch.");
                    }
                    if (!int.TryParse(items.iqa_item.ToString(), out int _out2))
                    {
                        errors.Add("iqa_item" + index, "Select Adjusted Item.");
                    }
                    if (string.IsNullOrEmpty(items.iqa_account))
                    {
                        errors.Add("iqa_account" + index, "Select Post To Account.");
                    }
                    if (!int.TryParse(items.ibId.ToString(), out int _out4))
                    {
                        errors.Add("item_batch" + index, "Select Item Batch.");
                    }

                    if (string.IsNullOrEmpty(items.iqa_date))
                    {
                        errors.Add("iqa_date" + index, "Date is Not Valid.");
                    }


                    if (!isValidDecimal(items.iqa_adj.ToString()))
                    {
                        errors.Add("iqa_adj" + index, "Enter Adjusted Qty is Not in Correct Format.");
                    }

                    if (!isValidDecimal(items.iqa_uprice.ToString()))
                    {
                        errors.Add("iqa_uprice" + index, "Enter Adjusted Item Cost.");
                    }


                }

                if (index == 0)
                {
                    errors.Add("iqa_branch" + index, "Select Branch.");
                    errors.Add("iqa_item" + index, "Select Adjusted Item.");
                    errors.Add("iqa_account" + index, "Select Post To Account.");
                    errors.Add("item_batch" + index, "Select Item Batch.");
                    errors.Add("iqa_date" + index, "Date is Not Valid.");
                    errors.Add("iqa_adj" + index, "Enter Adjusted Qty is Not in Correct Format.");
                    errors.Add("iqa_uprice" + index, "Enter Adjusted Item Cost.");

                }

            }
            else
            {
                errors.Add("iqa_branch", "Select Branch.");
                errors.Add("iqa_item", "Select Adjusted Item.");
                errors.Add("iqa_account", "Select Post To Account.");
                errors.Add("item_batch", "Select Item Batch.");
                errors.Add("iqa_date", "Date is Not Valid.");
                errors.Add("iqa_adj", "Enter Adjusted Qty is Not in Correct Format.");
                errors.Add("iqa_uprice", "Enter Adjusted Item Cost.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidMaterialConsumption(MaterialConsumptionList data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data != null)
            {
                int index = 0;

                foreach (BusinessEntities.Accounts.MaterialManagement.MaterialConsumption items in data.materialConsumptionList)
                {
                    index++;

                    if (!int.TryParse(items.scr_branch.ToString(), out int _out))
                    {
                        errors.Add("scr_branch" + index, "Select Branch.");
                    }
                    if (!int.TryParse(items.scr_doctor.ToString(), out int _out2))
                    {
                        errors.Add("scr_doctor" + index, "Select Doctor.");
                    }
                    if (!int.TryParse(items.scr_room.ToString(), out int _out3))
                    {
                        errors.Add("scr_room" + index, "Select Room.");
                    }
                    if (!int.TryParse(items.scr_item.ToString(), out int _out4))
                    {
                        errors.Add("scr_item" + index, "Select Material Consumption Item.");
                    }
                    if (!int.TryParse(items.scr_ibId.ToString(), out int _out5))
                    {
                        errors.Add("item_batch" + index, "Select Item Batch.");
                    }
                    if (string.IsNullOrEmpty(items.scr_batch))
                    {
                        errors.Add("item_batch" + index, "Select Item Batch.");
                    }
                    if (string.IsNullOrEmpty(items.scr_uom))
                    {
                        errors.Add("scr_uom" + index, "Select Item UoM.");
                    }

                    if (!isValidDecimal(items.scr_qty.ToString()))
                    {
                        errors.Add("item_qty" + index, "Consumed Qty is Not in Correct Format.");
                    }
                    else
                    {
                        if (items.scr_qty < 0)
                            errors.Add("item_qty" + index, "Consumed Qty Should be More than 0.");
                    }

                }

                if (index == 0)
                {
                    errors.Add("scr_branch" + index, "Select Branch.");
                    errors.Add("scr_doctor" + index, "Select Doctor.");
                    errors.Add("scr_room" + index, "Select Room.");
                    errors.Add("scr_item" + index, "Select Material Consumption Item.");
                    errors.Add("item_batch" + index, "Select Item Batch.");
                    errors.Add("item_batch" + index, "Select Item Batch.");
                    errors.Add("scr_uom" + index, "Select Item UoM.");
                    errors.Add("item_qty" + index, "Consumed Qty is Not in Correct Format.");
                    errors.Add("item_qty" + index, "Consumed Qty Should be More than 0.");


                }

            }
            else
            {
                errors.Add("scr_branch", "Select Branch.");
                errors.Add("scr_doctor", "Select Doctor.");
                errors.Add("scr_room", "Select Room.");
                errors.Add("scr_item", "Select Material Consumption Item.");
                errors.Add("item_batch", "Select Item Batch.");
                errors.Add("item_batch", "Select Item Batch.");
                errors.Add("scr_uom", "Select Item UoM.");
                errors.Add("item_qty", "Consumed Qty is Not in Correct Format.");
                errors.Add("item_qty", "Consumed Qty Should be More than 0.");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidUpdateMaterialConsumption(BusinessEntities.Accounts.MaterialManagement.MaterialConsumption items, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (items != null)
            {
                int index = 0;
                index++;

                if (!int.TryParse(items.scr_branch.ToString(), out int _out))
                {
                    errors.Add("scr_branch" + index, "Select Branch.");
                }
                else
                {
                    if (items.scr_branch <= 0)
                        errors.Add("scr_branch" + index, "Select Branch.");

                }
                if (!int.TryParse(items.scr_doctor.ToString(), out int _out2))
                {
                    errors.Add("scr_doctor" + index, "Select Doctor.");
                }
                else
                {
                    if (items.scr_doctor <= 0)
                        errors.Add("scr_doctor" + index, "Select Doctor.");

                }
                if (!int.TryParse(items.scr_room.ToString(), out int _out3))
                {
                    errors.Add("scr_room" + index, "Select Room.");
                }
                else
                {
                    if (items.scr_room <= 0)
                        errors.Add("scr_room" + index, "Select Room.");

                }
                if (!int.TryParse(items.scr_item.ToString(), out int _out4))
                {
                    errors.Add("scr_item" + index, "Select Material Consumption Item.");
                }
                else
                {
                    if (items.scr_item <= 0)
                        errors.Add("scr_item" + index, "Select Material Consumption Item.");

                }
                if (!int.TryParse(items.scr_ibId.ToString(), out int _out5))
                {
                    errors.Add("item_batch" + index, "Select Item Batch.");
                }
                if (string.IsNullOrEmpty(items.scr_batch))
                {
                    errors.Add("item_batch" + index, "Select Item Batch.");
                }
                if (string.IsNullOrEmpty(items.scr_uom))
                {
                    errors.Add("scr_uom" + index, "Select Item UoM.");
                }

                if (!isValidDecimal(items.scr_qty.ToString()))
                {
                    errors.Add("item_qty" + index, "Consumed Qty is Not in Correct Format.");
                }
                else
                {
                    if (items.scr_qty < 0)
                        errors.Add("item_qty" + index, "Consumed Qty Should be More than 0.");
                }

            }
            else
            {
                errors.Add("scr_branch", "Select Branch.");
                errors.Add("scr_doctor", "Select Doctor.");
                errors.Add("scr_room", "Select Room.");
                errors.Add("scr_item", "Select Material Consumption Item.");
                errors.Add("item_batch", "Select Item Batch.");
                errors.Add("item_batch", "Select Item Batch.");
                errors.Add("scr_uom", "Select Item UoM.");
                errors.Add("item_qty", "Consumed Qty is Not in Correct Format.");
                errors.Add("item_qty", "Consumed Qty Should be More than 0.");

            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidDirectPayment(BusinessEntities.Accounts.MaterialManagement.DirectPayment items, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (items != null)
            {
                int index = 0;
                index++;
                if (string.IsNullOrEmpty(items.dp_date))
                {
                    errors.Add("dp_date", "Enter Payment Date.");
                }
                else
                {
                    if (!DateTime.TryParse(items.dp_date.ToString(), out DateTime _out3))
                        errors.Add("dp_date", "Payment Date is Not Valid.");
                }
                if (!int.TryParse(items.dp_branch.ToString(), out int _out))
                {
                    errors.Add("dp_branch", "Select Branch.");
                }
                else
                {
                    if (items.dp_branch <= 0)
                        errors.Add("dp_branch", "Select Branch.");

                }
                if (string.IsNullOrEmpty(items.dp_debit))
                {
                    errors.Add("dp_debit", "Select Debit A/C.");
                }
                //if (string.IsNullOrEmpty(items.dp_credit))
                //{
                //    errors.Add("dp_credit", "Select Credit A/C.");
                //}

                if (items.dp_cash == 0 && items.dp_cc == 0 && items.dp_bt == 0 && items.dp_chq == 0)
                {
                    errors.Add("dp_cash", "Select At Least One Payment Mode.");
                }

                if (items.dp_bt > 0)
                {
                    if (string.IsNullOrEmpty(items.dp_bt_bank))
                        errors.Add("dp_bt_bank", "Select Bank Transfer Account");                    
                }
                else
                {
                    items.dp_bt_bank = string.Empty;
                }
                
                if (items.dp_chq > 0)
                {
                    if (string.IsNullOrEmpty(items.dp_chq_no))
                        errors.Add("dp_chq_no", "Enter Cheque No.");
                    if (string.IsNullOrEmpty(items.dp_chq_bank))
                        errors.Add("dp_chq_bank", "Select Cheque Bank.");
                    if (string.IsNullOrEmpty(items.dp_chq_date))
                    {
                        errors.Add("dp_chq_date", "Enter Cheque Date.");
                    }
                    else
                    {
                        if (!DateTime.TryParse(items.dp_chq_date.ToString(), out DateTime _out3))
                            errors.Add("dp_chq_date", "Cheque Date is Not Valid.");
                    }
                }
                else
                {
                    items.dp_chq_no = string.Empty;
                    items.dp_chq_bank = string.Empty;
                    items.dp_chq_date = DateTime.Now.ToString();
                }
                if (string.IsNullOrEmpty(items.dp_to))
                {
                    items.dp_to = string.Empty;
                }
                if (string.IsNullOrEmpty(items.dp_notes))
                {
                    items.dp_notes = string.Empty;
                }

            }
            else
            {
                errors.Add("dp_date", "Enter Payment Date.");
                errors.Add("dp_branch", "Select Branch.");
                errors.Add("dp_debit", "Select Debit A/C.");
                errors.Add("dp_credit", "Select Credit A/C.");
                errors.Add("dp_cash", "Select At Least One Payment Mode.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidAdvancePayment(BusinessEntities.Accounts.MaterialManagement.Payment items, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (items != null)
            {
                if (string.IsNullOrEmpty(items.pay_date))
                {
                    errors.Add("pay_date", "Enter Payment Date.");
                }
                else
                {
                    if (!DateTime.TryParse(items.pay_date.ToString(), out DateTime _out3))
                        errors.Add("pay_date", "Payment Date is Not Valid.");
                }
                if (!int.TryParse(items.pay_branch.ToString(), out int _out))
                {
                    errors.Add("pay_branch", "Select Branch.");
                }
                else
                {
                    if (items.pay_branch <= 0)
                        errors.Add("pay_branch", "Select Branch.");

                }
                if (!int.TryParse(items.pay_supplier.ToString(), out int _out2))
                {
                    errors.Add("pay_supplier", "Select Supplier.");
                }
                else
                {
                    if (items.pay_supplier <= 0)
                        errors.Add("pay_supplier", "Select Supplier.");

                }
                if (items.pay_cash == 0 && items.pay_cc == 0 && items.pay_bt == 0 && items.pay_chq == 0)
                {
                    errors.Add("pay_cash", "Select At Least One Payment Mode.");
                }
                if (string.IsNullOrEmpty(items.pay_type.ToString()))
                {
                    errors.Add("pay_type", "Select Payment Type");
                }
                else
                {
                    if (items.pay_type == "Refund")
                    {
                        if (!int.TryParse(items.pay_advance.ToString(), out int _out4))
                        {
                            errors.Add("pay_advance", "Select Refund Against.");
                        }
                        else
                        {
                            if (items.pay_advance <= 0)
                                errors.Add("pay_advance", "Select Refund Against.");

                        }
                        items.pay_refunded = (items.pay_cash + items.pay_cc + items.pay_bt + items.pay_chq);
                    }
                }

                if (items.pay_cash > 0)
                {
                    if (string.IsNullOrEmpty(items.pay_cash_bank))
                        errors.Add("pay_cash_bank", "Select Cash Account.");
                }
                else
                {
                    items.pay_cash_bank = string.Empty;
                }

                if (items.pay_cc > 0)
                {
                    if (string.IsNullOrEmpty(items.pay_cc_bank))
                        errors.Add("pay_cc_bank", "Select Credit Card Account.");
                }
                else
                {
                    items.pay_cc_bank = string.Empty;
                }

                if (items.pay_bt > 0)
                {
                    if (string.IsNullOrEmpty(items.pay_bt_bank))
                        errors.Add("pay_cc_bank", "Select Transfer Account.");
                }
                else
                {
                    items.pay_bt_bank = string.Empty;
                }

                if (items.pay_chq > 0)
                {
                    if (string.IsNullOrEmpty(items.pay_chq_no))
                        errors.Add("pay_chq_no", "Enter Cheque No.");
                    if (string.IsNullOrEmpty(items.pay_chq_bank))
                        errors.Add("pay_chq_bank", "Select Cheque Bank.");
                    if (string.IsNullOrEmpty(items.pay_chq_date))
                    {
                        errors.Add("pay_chq_date", "Enter Cheque Date.");
                    }
                    else
                    {
                        if (!DateTime.TryParse(items.pay_chq_date.ToString(), out DateTime _out3))
                            errors.Add("pay_chq_date", "Cheque Date is Not Valid.");
                    }
                }
                else
                {
                    items.pay_chq_no = string.Empty;
                    items.pay_chq_bank = string.Empty;
                    items.pay_chq_date = DateTime.Now.ToString();
                }

                if (string.IsNullOrEmpty(items.pay_notes))
                {
                    items.pay_notes = string.Empty;
                }

            }
            else
            {
                errors.Add("pay_date", "Enter Payment Date.");
                errors.Add("pay_branch", "Select Branch.");
                errors.Add("pay_supplier", "Select Supplier.");
                errors.Add("pay_type", "Select Payment Type");
                errors.Add("pay_cash", "Select At Least One Payment Mode.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidPayment(BusinessEntities.Accounts.MaterialManagement.Payment items, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (items != null)
            {
                if (string.IsNullOrEmpty(items.pay_date))
                {
                    errors.Add("pay_date", "Enter Payment Date.");
                }
                else
                {
                    if (!DateTime.TryParse(items.pay_date.ToString(), out DateTime _out3))
                        errors.Add("pay_date", "Payment Date is Not Valid.");
                }
                if (!int.TryParse(items.pay_branch.ToString(), out int _out))
                {
                    errors.Add("pay_branch", "Select Branch.");
                }
                else
                {
                    if (items.pay_branch <= 0)
                        errors.Add("pay_branch", "Select Branch.");

                }
                if (!int.TryParse(items.pay_invoice.ToString(), out int _out4))
                {
                    errors.Add("pay_invoice", "Select Purchase Invoice.");
                }
                else
                {
                    if (items.pay_invoice <= 0)
                        errors.Add("pay_invoice", "Select Purchase Invoice.");

                }
                if (!int.TryParse(items.pay_supplier.ToString(), out int _out2))
                {
                    errors.Add("pay_supplier", "Select Supplier.");
                }
                else
                {
                    if (items.pay_supplier <= 0)
                        errors.Add("pay_supplier", "Select Supplier.");

                }
                if (items.pay_cash == 0 && items.pay_cc == 0 && items.pay_bt == 0 && items.pay_chq == 0 && items.pay_allocated == 0)
                {
                    errors.Add("pay_cash", "Select At Least One Payment Mode.");
                }

                if (string.IsNullOrEmpty(items.pay_type.ToString()))
                {
                    items.pay_type = "Invoice";
                }
                items.pay_cash_bank = string.Empty;
                items.pay_cc_bank = string.Empty;
                if (items.pay_bt > 0)
                {
                    if (string.IsNullOrEmpty(items.pay_bt_bank))
                        errors.Add("pay_bt_bank", "Select Transfer Account.");
                }
                else
                {
                    items.pay_bt_bank = string.Empty;
                }

                if (items.pay_chq > 0)
                {
                    if (string.IsNullOrEmpty(items.pay_chq_no))
                        errors.Add("pay_chq_no", "Enter Cheque No.");
                    if (string.IsNullOrEmpty(items.pay_chq_bank))
                        errors.Add("pay_chq_bank", "Select Cheque Bank.");
                    if (string.IsNullOrEmpty(items.pay_chq_date))
                    {
                        errors.Add("pay_chq_date", "Enter Cheque Date.");
                    }
                    else
                    {
                        if (!DateTime.TryParse(items.pay_chq_date.ToString(), out DateTime _out3))
                            errors.Add("pay_chq_date", "Cheque Date is Not Valid.");
                    }
                }
                else
                {
                    items.pay_chq_no = string.Empty;
                    items.pay_chq_bank = string.Empty;
                    items.pay_chq_date = DateTime.Now.ToString();
                }

                if (string.IsNullOrEmpty(items.pay_notes))
                {
                    items.pay_notes = string.Empty;
                }

            }
            else
            {
                errors.Add("pay_date", "Enter Payment Date.");
                errors.Add("pay_branch", "Select Branch.");
                errors.Add("pay_supplier", "Select Supplier.");
                errors.Add("pay_cash", "Select At Least One Payment Mode.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidDirectStockTransfer(DirectStockTransferList data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data.directStockTransferList != null && data.directStockTransferList.Count > 0)
            {
                int index = 0;

                foreach (BusinessEntities.Accounts.MaterialManagement.DirectStockTransfer items in data.directStockTransferList)
                {
                    index++;

                    if (!int.TryParse(items.std_from_branch.ToString(), out int _out))
                    {
                        errors.Add("std_from_branch" + index, "Select From Branch.");
                    }

                    if (!int.TryParse(items.std_to_branch.ToString(), out int _out2))
                    {
                        errors.Add("std_to_branch" + index, "Select To Branch.");
                    }

                    if (!int.TryParse(items.std_itemId.ToString(), out int _out4))
                    {
                        errors.Add("std_itemId" + index, "Select Direct Transfer Item.");
                    }

                    if (!int.TryParse(items.std_ibId.ToString(), out int _out5))
                    {
                        errors.Add("item_batch" + index, "Select Direct Transfer Item Batch.");
                    }
                    if (string.IsNullOrEmpty(items.std_item_batch))
                    {
                        errors.Add("item_batch" + index, "Select Item Batch.");
                    }
                    if (string.IsNullOrEmpty(items.std_ouom))
                    {
                        errors.Add("std_ouom" + index, "Select Item UoM.");
                    }

                    if (!isValidDecimal(items.std_oqty.ToString()))
                    {
                        errors.Add("item_qty" + index, "Transfer Qty is Not in Correct Format.");
                    }
                    else
                    {
                        if (items.std_oqty < 0)
                            errors.Add("item_qty" + index, "Transfer Qty Should be More than 0.");
                    }

                }

                if (index == 0)
                {
                    errors.Add("std_from_branch" + index, "Select From Branch.");
                    errors.Add("std_to_branch" + index, "Select To Branch.");
                    errors.Add("std_itemId" + index, "Select Direct Transfer Item.");
                    errors.Add("item_batch" + index, "Select Direct Transfer Item Batch.");
                    errors.Add("std_ouom" + index, "Select Item UoM.");
                    errors.Add("item_qty" + index, "Transfer Qty is Not in Correct Format.");
                }

            }
            else
            {
                errors.Add("std_from_branch", "Select From Branch.");
                errors.Add("std_to_branch", "Select To Branch.");
                errors.Add("std_itemId", "Select Direct Transfer Item.");
                errors.Add("item_batch", "Select Direct Transfer Item Batch.");
                errors.Add("std_ouom", "Select Item UoM.");
                errors.Add("item_qty", "Transfer Qty is Not in Correct Format.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidDirectStockTransfer_Update(DirectStockTransfer items, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (items != null)
            {
                int index = 0;
                index++;

                if (!int.TryParse(items.std_from_branch.ToString(), out int _out))
                {
                    errors.Add("std_from_branch" + index, "Select From Branch.");
                }
                if (!int.TryParse(items.std_to_branch.ToString(), out int _out2))
                {
                    errors.Add("std_to_branch" + index, "Select To Branch.");
                }
                if (!int.TryParse(items.std_itemId.ToString(), out int _out4))
                {
                    errors.Add("std_itemId" + index, "Select Direct Transfer Item.");
                }
                if (!int.TryParse(items.std_ibId.ToString(), out int _out5))
                {
                    errors.Add("item_batch" + index, "Select Direct Transfer Item Batch.");
                }
                if (string.IsNullOrEmpty(items.std_item_batch))
                {
                    errors.Add("item_batch" + index, "Select Item Batch.");
                }
                if (string.IsNullOrEmpty(items.std_ouom))
                {
                    errors.Add("std_ouom" + index, "Select Item UoM.");
                }
                if (!isValidDecimal(items.std_oqty.ToString()))
                {
                    errors.Add("item_qty" + index, "Transfer Qty is Not in Correct Format.");
                }
                else
                {
                    if (items.std_oqty < 0)
                        errors.Add("item_qty" + index, "Transfer Qty Should be more than 0.");
                }
                if (index == 0)
                {
                    errors.Add("std_from_branch" + index, "Select From Branch.");
                    errors.Add("std_to_branch" + index, "Select To Branch.");
                    errors.Add("std_itemId" + index, "Select Direct Transfer Item.");
                    errors.Add("item_batch" + index, "Select Direct Transfer Item Batch.");
                    errors.Add("std_ouom" + index, "Select Item UoM.");
                    errors.Add("item_qty" + index, "Transfer Qty is Not in Correct Format.");
                }
            }
            else
            {
                errors.Add("std_from_branch", "Select From Branch.");
                errors.Add("std_to_branch", "Select To Branch.");
                errors.Add("std_itemId", "Select Direct Transfer Item.");
                errors.Add("item_batch", "Select Direct Transfer Item Batch.");
                errors.Add("std_ouom", "Select Item UoM.");
                errors.Add("item_qty", "Transfer Qty is Not in Correct Format.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidStockTransferRequest(StockTransferRequestList data, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (data.stockTransferRequestList != null && data.stockTransferRequestList.Count > 0)
            {
                int index = 0;

                foreach (BusinessEntities.Accounts.MaterialManagement.StockTransferRequest items in data.stockTransferRequestList)
                {
                    index++;

                    if (!int.TryParse(items.str_from_branch.ToString(), out int _out))
                    {
                        errors.Add("str_from_branch" + index, "Select From Branch.");
                    }

                    if (!int.TryParse(items.str_request_branch.ToString(), out int _out2))
                    {
                        errors.Add("str_request_branch" + index, "Select To Requested Branch.");
                    }

                    if (!int.TryParse(items.str_itemId.ToString(), out int _out4))
                    {
                        errors.Add("str_itemId" + index, "Select Stock Transfer Item.");
                    }

                    if (string.IsNullOrEmpty(items.str_ouom))
                    {
                        errors.Add("str_ouom" + index, "Select Item UoM.");
                    }

                    if (!isValidDecimal(items.str_oqty.ToString()))
                    {
                        errors.Add("str_oqty" + index, "Transfer Qty is Not in Correct Format.");
                    }
                    else
                    {
                        if (items.str_oqty < 0)
                            errors.Add("str_oqty" + index, "Transfer Qty Should be More than 0.");
                    }

                }

            }
            else
            {
                errors.Add("str_from_branch", "Select From Branch.");
                errors.Add("str_request_branch", "Select Requested Branch.");
                errors.Add("str_itemId", "Select Direct Transfer Item.");
                errors.Add("item_batch", "Select Direct Transfer Item Batch.");
                errors.Add("str_ouom", "Select Item UoM.");
                errors.Add("item_qty", "Transfer Qty is Not in Correct Format.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidStockTransferRequest_Update(StockTransferRequest items, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (items != null)
            {
                int index = 0;
                index++;

                if (!int.TryParse(items.str_from_branch.ToString(), out int _out))
                {
                    errors.Add("str_from_branch" + index, "Select From Branch.");
                }
                if (!int.TryParse(items.str_request_branch.ToString(), out int _out2))
                {
                    errors.Add("str_request_branch" + index, "Select Requesting Branch.");
                }
                if (!int.TryParse(items.str_itemId.ToString(), out int _out4))
                {
                    errors.Add("str_itemId" + index, "Select Transfer Item.");
                }                
                if (string.IsNullOrEmpty(items.str_ouom))
                {
                    errors.Add("str_ouom" + index, "Select Item UoM.");
                }
                if (!isValidDecimal(items.str_oqty.ToString()))
                {
                    errors.Add("str_oqty" + index, "Transfer Qty is Not in Correct Format.");
                }
                else
                {
                    if (items.str_oqty < 0)
                        errors.Add("str_oqty" + index, "Transfer Qty Should be more than 0.");
                }
            }
            else
            {
                errors.Add("str_from_branch","Select From Branch.");
                errors.Add("str_request_branch","Select Requesting Branch.");
                errors.Add("str_itemId","Select Transfer Item.");
                errors.Add("str_ouom","Select Item UoM.");
                errors.Add("str_qty","Transfer Qty is Not in Correct Format.");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }
        public static bool isValidAllocateBatches(StockTransferRequest items, out Dictionary<string, string> errors)
        {
            bool isValid = false;
            errors = new Dictionary<string, string>();
            if (items != null)
            {
                int index = 0;
                index++;

                if (!int.TryParse(items.str_from_branch.ToString(), out int _out))
                {
                    errors.Add("str_from_branch" + index, "Select From Branch.");
                }
                if (!int.TryParse(items.str_request_branch.ToString(), out int _out2))
                {
                    errors.Add("str_request_branch" + index, "Select Requesting Branch.");
                }
                if (!int.TryParse(items.str_itemId.ToString(), out int _out4))
                {
                    errors.Add("str_itemId" + index, "Select Transfer Item.");
                } 
                
                if (string.IsNullOrEmpty(items.str_ouom))
                {
                    errors.Add("str_ouom" + index, "Select Item UoM.");
                }

                if (!isValidDecimal(items.str_oqty.ToString()))
                {
                    errors.Add("str_oqty" + index, "Transfer Qty is Not in Correct Format.");
                }
                else
                {
                    if (items.str_oqty < 0)
                        errors.Add("str_oqty" + index, "Transfer Qty Should be more than 0.");
                }
                
                if (!isValidDecimal(items.str_ibId.ToString()))
                {
                    errors.Add("str_ibId" + index, "Item Batch is Not in Correct Format.");
                }
                else
                {
                    if (items.str_ibId < 0)
                        errors.Add("str_ibId" + index, "Select Item Batch");
                }
            }
            else
            {
                errors.Add("str_from_branch","Select From Branch.");
                errors.Add("str_request_branch","Select Requesting Branch.");
                errors.Add("str_itemId","Select Transfer Item.");
                errors.Add("str_ouom","Select Item UoM.");
                errors.Add("str_qty","Transfer Qty is Not in Correct Format.");
                errors.Add("str_ibId", "Select Item Batch");
            }

            if (errors.Count == 0)
            {
                isValid = true;
            }

            return isValid;
        }

        public static bool isValidDecimal(string val)
        {
            bool successfullyParsed = false;
            decimal out_val = 0;
            successfullyParsed = decimal.TryParse(val, out out_val);
            if (successfullyParsed)
                return true;
            else
                return false;

        }
    }
}
