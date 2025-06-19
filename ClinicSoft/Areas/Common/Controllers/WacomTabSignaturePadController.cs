using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicSoft.Areas.Common.Controllers
{
    public class WacomTabSignaturePadController : Controller
    {
        // GET: Common/WacomTabSignaturePad
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult WacomTabSignaturePad(BusinessEntities.Common.eSignature data)
        {
            return PartialView("WacomTabSignaturePad", data);
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

                String St = data.txtSignature;

                int pFrom = St.IndexOf("base64_image:>") + "base64_image:>".Length;
                int pTo = St.LastIndexOf("<");

                String result = St.Substring(pFrom, pTo - pFrom);
                byte[] imageBytes = Convert.FromBase64String(result);
                string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                string path = Path.Combine(file_path, filename);

                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(imageBytes, 0, imageBytes.Length))
                {
                    using (System.Drawing.Bitmap bi = new System.Drawing.Bitmap(ms))
                    {
                        bi.Save(path);
                    }
                }

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
    }
}