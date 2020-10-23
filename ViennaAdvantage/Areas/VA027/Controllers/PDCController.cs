using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using VA027.Models;
using VAdvantage.Utility;


namespace VA027.Controllers
{
    public class PDCController : Controller
    {
        /// <summary>
        /// Get Document Base Type from Document Type
        /// </summary>
        /// <param name="fields">string fields</param>
        /// <returns>Data in JSON Format</returns>
        public JsonResult GetDocBaseType(String fields)
        {
            string retJSON = "";
            if (Session["ctx"] != null)
            {
                Ctx ctx = Session["ctx"] as Ctx;
                PDCModel paymodel = new PDCModel();
                retJSON = JsonConvert.SerializeObject(paymodel.GetDocBaseType(ctx, fields));
            }
            return Json(retJSON, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get Business Partner Data
        /// </summary>
        /// <param name="fields">string fields</param>
        /// <returns>Data in JSON Format</returns>
        public JsonResult GetBPData(String fields)
        {
            string retJSON = "";
            if (Session["ctx"] != null)
            {
                Ctx ctx = Session["ctx"] as Ctx;
                PDCModel paymodel = new PDCModel();
                retJSON = JsonConvert.SerializeObject(paymodel.GetBPData(ctx, fields));
            }
            return Json(retJSON, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get Order Data
        /// </summary>
        /// <param name="fields">string fields</param>
        /// <returns>Data in JSON Format</returns>
        public JsonResult GetOrderData(String fields)
        {
            string retJSON = "";
            if (Session["ctx"] != null)
            {
                Ctx ctx = Session["ctx"] as Ctx;
                PDCModel paymodel = new PDCModel();
                retJSON = JsonConvert.SerializeObject(paymodel.GetOrderData(ctx, fields));
            }
            return Json(retJSON, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get InvoicePayschedule Data
        /// </summary>
        /// <param name="fields">C_INVOICEPAYSCHEDULE_ID</param>
        /// <returns>Data in JSON Format</returns>
        public JsonResult GetInvoicePayscheduleData(String fields)
        {
            string retJSON = "";
            if (Session["ctx"] != null)
            {
                Ctx ctx = Session["ctx"] as Ctx;
                PDCModel paymodel = new PDCModel();
                retJSON = JsonConvert.SerializeObject(paymodel.GetInvoicePayscheduleData(ctx, fields));
            }
            return Json(retJSON, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get OrderPaySchedule data
        /// </summary>
        /// <param name="fields">VA009_ORDERPAYSCHEDULE_ID</param>
        /// <returns>>Data in JSON Format</returns>
        public JsonResult GetOrderPayScheduleData(String fields)
        {
            string retJSON = "";
            if (Session["ctx"] != null)
            {
                Ctx ctx = Session["ctx"] as Ctx;
                PDCModel paymodel = new PDCModel();
                retJSON = JsonConvert.SerializeObject(paymodel.GetOrderPayScheduleData(ctx, fields));
            }
            return Json(retJSON, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get BankAccount Currency
        /// </summary>
        /// <param name="fields">C_BankAccount_ID</param>
        /// <returns>Data in JSON Format</returns>
        public JsonResult GetBankAcctCurrency(String fields)
        {
            string retJSON = "";
            if (Session["ctx"] != null)
            {
                Ctx ctx = Session["ctx"] as Ctx;
                PDCModel paymodel = new PDCModel();
                retJSON = JsonConvert.SerializeObject(paymodel.GetBankAcctCurrency(ctx, fields));
            }
            return Json(retJSON, JsonRequestBehavior.AllowGet);
        }
    }
}