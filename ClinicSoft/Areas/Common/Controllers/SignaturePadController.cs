using BusinessEntities;
using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Common.Controllers
{
    #region eSignature
    public class SignaturePadController : Controller
    {
        // GET: Common/SignaturePad
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SignaturePad(BusinessEntities.Common.eSignature data)
        {
            return PartialView("SignaturePad", data);
        }
        // upload: eSignature
        [HttpPost]
        public ActionResult UploadSignature(BusinessEntities.Common.eSignature data)
        {
            bool isInserted = false;

            if (!string.IsNullOrEmpty(data.eSign))
            {
                string file_path = Server.MapPath("~/images/patient_photos/");

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("yyyy"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("yyyy"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("MMMM"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("MMMM"));
                }

                if (!Directory.Exists(Path.Combine(file_path, DateTime.Now.ToString("dd"))))
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                    Directory.CreateDirectory(file_path);
                }
                else
                {
                    file_path = Path.Combine(file_path, DateTime.Now.ToString("dd"));
                }

                string[] contents = data.eSign.Split(',');
                string base64 = contents[1].ToString(); //data:image/png;base64
                string[] filedata = contents[0].Split('/');
                string ext = filedata[1].ToString().Replace("base64", "").Replace(";", "").Trim();

                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + "." + ext;
                string path = Path.Combine(file_path, filename);
                System.IO.File.WriteAllBytes(path, Convert.FromBase64String(base64.ToString()));

                if (System.IO.File.Exists(path))
                {
                    data.eSign = path.Replace(Server.MapPath("~/"), "");
                    int madeBy = PageControl.getLoggedinId();
                    isInserted = BusinessLogicLayer.Common.eSignature.UploadSignature(data, madeBy);
                }
            }


            if (isInserted)
            {
                return Json(new { isInserted = true, isSuccess = true, message = "Done" }, JsonRequestBehavior.AllowGet);

            }
            else
            {
                return Json(new { isInserted = false, isSuccess = true, message = "Signature Already Exists!" }, JsonRequestBehavior.AllowGet);
            }


        }

        // Get: eSignature
        [HttpGet]
        public JsonResult GetSignature(int ? appId, string person,string form)
        {
            if (PageControl.getLoggedinId() > 0)
            {
               
                List<BusinessEntities.Common.eSignature> data = BusinessLogicLayer.Common.eSignature.GetSignature(appId, person, form);                
                var jsonResult = Json(data, JsonRequestBehavior.AllowGet);
                jsonResult.MaxJsonLength = int.MaxValue;
                return jsonResult;
                
            }
            else
            {
                return Json(new { isAuthorized = false, message = "UnAuthorised Access!" }, JsonRequestBehavior.AllowGet);
            }
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;
            TempData["error"] = filterContext;
            filterContext.Result = RedirectToAction("Error", "Error", new { area = "Common" });
        }
    }

    #endregion eSignature
}