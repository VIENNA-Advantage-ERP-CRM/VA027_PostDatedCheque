﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VAdvantage.Utility;
using VAdvantage.Model;
using System.Data;
using VAdvantage.DataBase;
using System.Data.SqlClient;

namespace VA027.Models
{
    public class PDCModel
    {
        /// <summary>
        /// Get Document Base Type from Document Type
        /// </summary>
        /// <param name="ctx">Context</param>
        /// <param name="fields">string fields</param>
        /// <returns>Dictionary, Document Type Data</returns>
        public Dictionary<string, object> GetDocBaseType(Ctx ctx, string fields)
        {
            if (fields != null)
            {
                Dictionary<string, object> retDic = null;
                string _sql = "";
                string[] paramValue = fields.ToString().Split(',');
                //Assign parameter value
                string tableName = Util.GetValueOfString(paramValue[0].ToString());
                int record_ID = Util.GetValueOfInt(paramValue[1]);
                //End Assign parameter
                if (tableName == "C_Invoice")
                {
                    _sql = "SELECT DOC.DOCBASETYPE FROM C_INVOICE INV INNER JOIN C_DOCTYPE DOC ON "
                             + "INV.C_DOCTYPE_ID=DOC.C_DOCTYPE_ID WHERE INV.ISACTIVE='Y' AND INV.C_INVOICE_ID= " + record_ID;
                }
                else if (tableName == "C_Order")
                {
                    _sql = "SELECT DOC.DOCBASETYPE, ORD.ISSOTRX, ORD.ISRETURNTRX, ORD.GRANDTOTAL FROM C_ORDER ORD "
                            + " INNER JOIN C_DOCTYPE DOC ON ORD.C_DOCTYPE_ID=DOC.C_DOCTYPE_ID WHERE ORD.ISACTIVE='Y' AND ORD.C_ORDER_ID=" + record_ID;
                }
                else
                {
                    _sql = "SELECT DOC.DOCBASETYPE FROM C_DOCTYPE DOC WHERE DOC.ISACTIVE ='Y' AND DOC.C_DocType_ID=" + record_ID;
                }

                DataSet ds = DB.ExecuteDataset(_sql);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    retDic = new Dictionary<string, object>();
                    retDic["DocBaseType"] = Util.GetValueOfString(ds.Tables[0].Rows[0]["DOCBASETYPE"]);
                    if (tableName == "C_Order")
                    {
                        retDic["IsSOTrx"] = Util.GetValueOfString(ds.Tables[0].Rows[0]["ISSOTRX"]);
                        retDic["IsReturnTrx"] = Util.GetValueOfString(ds.Tables[0].Rows[0]["ISRETURNTRX"]);
                        retDic["GrandTotal"] = Util.GetValueOfDecimal(ds.Tables[0].Rows[0]["GRANDTOTAL"]);
                    }
                }
                return retDic;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get Invoice Data
        /// </summary>
        /// <param name="ctx">Context</param>
        /// <param name="fields">string fields</param>
        /// <returns>Dictionary, Business Partner Data</returns>
        public Dictionary<String, Object> GetBPData(Ctx ctx, string fields)
        {
            string sql;
            string[] paramValue = fields.Split(',');
            string table = paramValue[0];
            int record_ID = Util.GetValueOfInt(paramValue[1]);
            Dictionary<String, Object> retDic = null;
            if (table.Equals("C_Order") || table.Equals("C_Invoice"))
            {
                sql = "SELECT C_BPartner_ID, C_Bpartner_Location_ID"
                   + " FROM " + table + " WHERE " + table + "_ID = " + record_ID;
            }
            
            //Calls from Business Partner
            else { 
                sql= "SELECT p.C_BPartner_ID, l.C_Bpartner_Location_ID FROM C_Bpartner p  " +
                    "Inner JOIN C_BPartner_Location l ON(p.C_BPartner_ID = l.C_BPartner_ID  AND l.IsActive = 'Y') " +
                    "WHERE p.C_BPartner_ID = " + record_ID;
            }
            DataSet ds = DB.ExecuteDataset(sql, null, null);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                retDic = new Dictionary<string, object>();
                retDic["C_BPartner_ID"] = Util.GetValueOfInt(ds.Tables[0].Rows[0]["C_BPartner_ID"]);
                retDic["C_BPartner_Location_ID"] = Util.GetValueOfInt(ds.Tables[0].Rows[0]["C_BPartner_Location_ID"]);
            }
            return retDic;
        }

        /// <summary>
        /// Get Order Data
        /// </summary>
        /// <param name="ctx">Context</param>
        /// <param name="fields">>string fields</param>
        /// <returns>Dictionary, Order Data</returns>
        public Dictionary<String, Object> GetOrderData(Ctx ctx, string fields)
        {
            string[] paramValue = fields.Split(',');
            bool countVA009 = Util.GetValueOfBool(paramValue[0]);
            int C_Order_ID = Util.GetValueOfInt(paramValue[1]);
            Dictionary<String, Object> retDic = null;
            string sql = "SELECT C_Currency_ID, C_ConversionType_ID FROM C_Order WHERE C_Order_ID = " + C_Order_ID;

            DataSet ds = DB.ExecuteDataset(sql, null, null);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                retDic = new Dictionary<string, object>();

                retDic["C_Currency_ID"] = Util.GetValueOfInt(ds.Tables[0].Rows[0]["C_Currency_ID"]);
                retDic["C_ConversionType_ID"] = Util.GetValueOfInt(ds.Tables[0].Rows[0]["C_ConversionType_ID"]);
            }
            return retDic;
        }

        /// <summary>
        /// Get InvoicePayschedule Data
        /// </summary>
        /// <param name="ctx">Context</param>
        /// <param name="field"> C_INVOICEPAYSCHEDULE_ID </param>
        /// <returns>Dictionary, InvoicePayschedule Data</returns>
        public Dictionary<String, Object> GetInvoicePayscheduleData(Ctx ctx, string field)
        {
            int C_INVOICEPAYSCHEDULE_ID = Util.GetValueOfInt(field);
            Dictionary<String, Object> retDic = null;
            string sql = "SELECT i.IsReturnTrx, ii.DueAmt FROM c_invoice i INNER JOIN C_InvoicePaySchedule ii" +
                " ON i.c_invoice_Id = ii.c_invoice_Id WHERE ii.C_InvoicePaySchedule_ID =" + C_INVOICEPAYSCHEDULE_ID;
            //return Util.GetValueOfDecimal(DB.ExecuteScalar(sql, null, null));     
            DataSet ds = DB.ExecuteDataset(sql, null, null);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                retDic = new Dictionary<string, object>();

                retDic["IsReturnTrx"] = Util.GetValueOfString(ds.Tables[0].Rows[0]["IsReturnTrx"]);
                retDic["DueAmt"] = Util.GetValueOfDecimal(ds.Tables[0].Rows[0]["DueAmt"]);
            }
            return retDic;
        }

        /// <summary>
        /// Get amount of orderpayschedule
        /// </summary>
        /// <param name="ctx">Context</param>
        /// <param name="field">VA009_ORDERPAYSCHEDULE_ID</param>
        /// <returns>dueamt</returns>
        public Decimal GetOrderPayScheduleData(Ctx ctx , string field)
        {
          Decimal dueamt=  Util.GetValueOfDecimal(DB.ExecuteScalar("SELECT DueAmt FROM VA009_ORDERPAYSCHEDULE WHERE VA009_ORDERPAYSCHEDULE_ID=" + Util.GetValueOfInt(field),null,null));
            return dueamt;
        }

        /// <summary>
        /// Get currency of BankAccount
        /// </summary>
        /// <param name="ctx">Context</param>
        /// <param name="field">C_BankAccount_ID</param>
        /// <returns>Currency_ID</returns>
        public int GetBankAcctCurrency(Ctx ctx, string field)
        {
            int Currency_ID = Util.GetValueOfInt(DB.ExecuteScalar("SELECT C_Currency_ID FROM C_BankAccount WHERE C_BankAccount_ID = " + Util.GetValueOfInt(field),null,null));
            return Currency_ID;
        }     
    }
}
