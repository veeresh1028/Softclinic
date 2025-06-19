using BusinessEntities;
using BusinessLogicLayer.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BusinessEntities.EClaims.ClaimSubmissionRequest;
using static BusinessEntities.Reports.Resubmission;

namespace ClinicSoft.Areas.Reports.Controllers
{
    public class InsRemittanceReportController : Controller
    {
        // GET: Reports/InsRemittanceReport
        int PageId = (int)Pages.InsuranceClaimsOutstandingReport;

        [HttpGet]
        public ActionResult InsRemittanceReport()
        {
            int Action = (int)Actions.Read;

            if (PageControl.haveAccess(PageId, Action))
            {
                DataSet ds = BusinessLogicLayer.Reports.Resubmission.GetResubmissFilters();

                SelectList insCompanylist = Models.Helper.ToSelectList(ds.Tables[0], "ecic_code", "ecic_name");
                ViewBag.InsComList = insCompanylist;

                SelectList denailList = Models.Helper.ToSelectList(ds.Tables[1], "dc_code", "dc_details");
                ViewBag.DenailList = denailList;

                SelectList branchList = Models.Helper.ToSelectList(ds.Tables[2], "set_permit_no", "set_company");
                ViewBag.BranchList = branchList;
                return View();
            }
            else
            {
                return RedirectToAction("UnAuthorizedAccess", "Authentication", new { area = "Authentication" });
            }
        }

        [HttpGet]
        public JsonResult GetTransactionClaimsActivityData(filesdownload_filter filter)
        {
            List<TransactionClaimActivtyDetail> data = BusinessLogicLayer.Reports.Resubmission.GetTransactionClaimsActivityData(filter);
            var jsonResult = Json(data, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpGet]
        public JsonResult GetDownloadClaimsData(filesdownload_filter filter)
        {
            List<downloadFilesDetail> data = BusinessLogicLayer.Reports.Resubmission.GetDownloadClaimsData(filter);
            var jsonResult = Json(data, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}