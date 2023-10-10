using DAO;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HR.Controllers
{
    public class ZhaoPController : Controller
    {
        private Major_releaseDAO major_ReleaseDAO = new Major_releaseDAO();
        private Engage_resumeDAO resumeDAO = new Engage_resumeDAO();
        private Public_charDAO public_CharDAO = new Public_charDAO();
        private MajorDAO majorDAO = new MajorDAO();
        private Engage_interviewDAO engage=new Engage_interviewDAO();
        // GET: ZhaoP
        public ActionResult ZYD()
        {
            return View();
        }

        public async Task<ActionResult> ZYDTJf(Major_release major)
        {
            int cg = await major_ReleaseDAO.TianAsync(major);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View(major);
            }
        }


        public ActionResult ZYG()
        {
            return View();
        }

        public async Task<ActionResult> ZYGCX(int pageSize, int currentPage)
        {
            Fenye<Major_release> fenye = await major_ReleaseDAO.SelectAsync(pageSize, currentPage);
            return Json(fenye, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ZYGSc(int id)
        {
            int cg = await major_ReleaseDAO.ScAsync(id);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }

        public async Task<ActionResult> ZYGXiu(int id)
        {
            ViewBag.s = await major_ReleaseDAO.ChaYiAsync(id);
            return View();
        }


        public async Task<ActionResult> ZYGXiuu(Major_release major_Release)
        {
            int cg = await major_ReleaseDAO.Xiu(major_Release);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }


        public ActionResult ZYC()
        {
            return View();
        }

        public async Task<ActionResult> ZYCXiu(int id)
        {
            ViewBag.s = await major_ReleaseDAO.ChaYiAsync(id);
            return View();
        }

        public  ActionResult JLD()
        {
            string engageType = Request.QueryString["engage_type"];
            string majorKindName = Request.QueryString["major_kind_name"];
            string majorName = Request.QueryString["major_name"];

            // 使用参数值进行后续处理

            return View();
        }


        public async Task<ActionResult> JLDCXList(string name)
        {
            IEnumerable<Public_char> ie = await public_CharDAO.SelectListAsync(name);
            return Json(ie, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> JLDTJf(Engage_resume er)
        {
            int cg = await resumeDAO.TianAsync(er);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View(er);
            }
        }


        public ActionResult JLC()
        {
            return View();
        }


        public async Task<ActionResult> JLCCXList(string name)
        {
            IEnumerable<Major> ie = await majorDAO.SelectListAsync(name);
            return Json(ie, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JLCCX()
        {
            string fenl = Request.QueryString["fenl"];
            string namemc = Request.QueryString["namemc"];
            string Gjz = Request.QueryString["Gjz"];
            string qsj = Request.QueryString["qsj"];
            string zsj = Request.QueryString["zsj"];

            return View();
        }

        public async Task<ActionResult> JLCCXf(int pageSize, int currentPage, string Zyf, string Zwm, string Gjc, string Djq, string Djz)
        {
            Fenye<Engage_resume> fenye = await resumeDAO.SelectAsync(pageSize, currentPage,Zyf, Zwm, Gjc, Djq, Djz);
            return Json(fenye, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> JLCXiuu(int id)
        {
            int cg = await resumeDAO.Xiu(id);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }


        public ActionResult JLCX()
        {
            return View();
        }

        public ActionResult JLCflC()
        {
            string fenl = Request.QueryString["fenl"];
            string namemc = Request.QueryString["namemc"];
            string Gjz = Request.QueryString["Gjz"];
            string qsj = Request.QueryString["qsj"];
            string zsj = Request.QueryString["zsj"];

            return View();
        }

        public async Task<ActionResult> JLCXf(int pageSize, int currentPage, string Zyf, string Zwm, string Gjc, string Djq, string Djz)
        {
            Fenye<Engage_resume> fenye = await resumeDAO.SelectAsync2(pageSize, currentPage, Zyf, Zwm, Gjc, Djq, Djz);
            return Json(fenye, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> JLYCXAsync(int id)
        {
            ViewBag.s = await resumeDAO.ChaYiAsync(id);
            return View();
        }


        public ActionResult MSD()
        {
            return View();
        }

        public ActionResult WSCD()
        {
            var file = HttpContext.Request.Files["file"];//获取上传文件对象
                                                         //生成文件名
            string name = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            //获取后缀名
            string ext = file.FileName.Substring(file.FileName.LastIndexOf('.'));
            //相对路径
            string paths = $"~/Uploaders/{DateTime.Now.ToString("yyyy/MM/dd/")}" + name + ext;
            //绝对路径
            string jpath = Server.MapPath(paths);
            //创建上传文件对应的文件夹
            (new FileInfo(jpath)).Directory.Create();
            file.SaveAs(jpath);

            string result = paths.Substring(paths.IndexOf("~") + 1);
            // 返回相对路径
            return Json(new { path = result });
        }

        public ActionResult MSDC()
        {
            string fenl = Request.QueryString["fenl"];
            string namemc = Request.QueryString["namemc"];
            string Gjz = Request.QueryString["Gjz"];
            string qsj = Request.QueryString["qsj"];
            string zsj = Request.QueryString["zsj"];

            return View();
        }

        public async Task<ActionResult> MSDCXf(int pageSize, int currentPage, string Zyf, string Zwm, string Gjc, string Djq, string Djz)
        {
            Fenye<Engage_resume> fenye = await resumeDAO.SelectAsync2(pageSize, currentPage, Zyf, Zwm, Gjc, Djq, Djz);
            return Json(fenye, JsonRequestBehavior.AllowGet);
        }

       

        public async Task<ActionResult> MSDXAsync(int id,string name)
        {
           
                var task1 = resumeDAO.ChaYiAsync(id);
                var task2 = engage.ChaYiAsync(name);
            if(task2 == null)
             {
                ViewBag.s1 = await task1;
                return View();
            }
            else
            {
                await Task.WhenAll(task1, task2);

                ViewBag.s1 = await task1;
                ViewBag.s2 = await task2;

                return View();
            } 
        }


        public async Task<ActionResult> MSDTJf(Engage_interview er,int id)
        {
            await resumeDAO.Xiu2(id);
            int cg = await engage.TianAsync(er);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View(er);
            }
        }

        public ActionResult MSS()
        {
            return View();
        }

        public async Task<ActionResult> MSSCX(int pageSize, int currentPage)
        {
            Fenye<Engage_interview> fenye = await engage.SelectAsync(pageSize, currentPage);
            return Json(fenye, JsonRequestBehavior.AllowGet);
        }


        public async Task<ActionResult> MSSAsync(int id, int idc)
        {
            var task1 = resumeDAO.ChaYiAsync(id);
            var task2 = engage.ChaIDAsync(idc);
           
                await Task.WhenAll(task1, task2);

                ViewBag.s1 = await task1;
                ViewBag.s2 = await task2;
                return View();
            
        }

        public async Task<ActionResult> MSSTJf(string sxr, int zt, int ids, string sxsj, string shenhe, int id)
        {
            int cg = await resumeDAO.Xiu2(zt, id);
            int cg2 = await engage.Xiu2(sxr,zt,sxsj,shenhe,ids);
            if (cg > 0 && cg2 > 0)
            {
                return Content("1");
            }
            else
            {
                return View();
            }
        }


        public ActionResult LUY()
        {
            return View();
        }


        public async Task<ActionResult> LUYCX(int pageSize, int currentPage)
        {
            Fenye<Engage_resume> fenye = await resumeDAO.SelectdAsync(pageSize, currentPage);
            return Json(fenye, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> LUYAsync(int id, int idc)
        {
            var task1 = resumeDAO.ChaYiAsync(id);
            var task2 = engage.ChaXAsync(idc);

            await Task.WhenAll(task1, task2);

            ViewBag.s1 = await task1;
            ViewBag.s2 = await task2;
            return View();

        }

        public async Task<ActionResult> LUYXG(int id,string text)
        {
            int cg = await resumeDAO.Xug(id,text);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LUYS()
        {
            return View();
        }


        public async Task<ActionResult> LUYSCX(int pageSize, int currentPage)
        {
            Fenye<Engage_resume> fenye = await resumeDAO.SelectSAsync(pageSize, currentPage);
            return Json(fenye, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> LUYSAsync(int id, int idc)
        {
            var task1 = resumeDAO.ChaYiAsync(id);
            var task2 = engage.ChaXAsync(idc);

            await Task.WhenAll(task1, task2);

            ViewBag.s1 = await task1;
            ViewBag.s2 = await task2;
            return View();

        }

        public async Task<ActionResult> LUYSXG(int id, string text)
        {
            int cg = await resumeDAO.Xug2(id, text);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View();
            }
        }


        public ActionResult LUYC()
        {
            return View();
        }


        public async Task<ActionResult> LUYCCX(int pageSize, int currentPage)
        {
            Fenye<Engage_resume> fenye = await resumeDAO.SelectCAsync(pageSize, currentPage);
            return Json(fenye, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> LUYCAsync(int id, int idc)
        {
            var task1 = resumeDAO.ChaYiAsync(id);
            var task2 = engage.ChaXAsync(idc);

            await Task.WhenAll(task1, task2);

            ViewBag.s1 = await task1;
            ViewBag.s2 = await task2;
            return View();

        }


    }
}