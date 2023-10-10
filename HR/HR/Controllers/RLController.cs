using DAO;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HR.Controllers
{
    public class RLController : Controller
    {
        // GET: RL
        private Engage_resumeDAO resumeDAO = new Engage_resumeDAO();
        private Human_fileDAO human_File = new Human_fileDAO();
        private Second_kindDAO second_KindDAO = new Second_kindDAO();
        private Third_kindDAO third_KindDAO = new Third_kindDAO();

        public ActionResult RL()
        {
            return View();
        }

        public async Task<ActionResult> RLDJ(int id)
        {
            ViewBag.s = await resumeDAO.ChaYiAsync(id);
            return View();
        }

        public async Task<ActionResult> RLTJf(Human_file human)
        {
            int a = int.Parse(human.human_id);
           int aa=  await resumeDAO.Xiuss(a);
            int cg = await human_File.TianAsync(human);
            if (aa>0&&cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View(human);
            }
        }


        public ActionResult RLFH()
        {
            return View();
        }


        public async Task<ActionResult> RLFHCX(int pageSize, int currentPage)
        {
            Fenye<Human_file> fenye = await human_File.SelectdAsync(pageSize, currentPage);
            return Json(fenye, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> RLFHXiu(int id)
        {
            ViewBag.s = await human_File.ChaYiAsync(id);
            return View();
        }

        public async Task<ActionResult> RLFHXiuF(int id,string time)
        {
            int cg = await human_File.Xiuss(id,time);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View();
            }
        }


        public ActionResult RLCX()
        {
            return View();
        }

        public async Task<ActionResult> JLCCXList(string name)
        {
            IEnumerable<Second_kind> ie = await second_KindDAO.SelectListAsync(name);
            return Json(ie, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> JLCCXLister(string name)
        {
            IEnumerable<Third_kind> ie = await third_KindDAO.SelectListAsync(name);
            return Json(ie, JsonRequestBehavior.AllowGet);
        }


        public ActionResult RLCXList()
        {
            string fl = Request.QueryString["fl"];
            string mc = Request.QueryString["mc"];
            string yi = Request.QueryString["yi"];
            string er = Request.QueryString["er"];
            string sa = Request.QueryString["sa"];
            string qsj = Request.QueryString["qsj"];
            string zsj = Request.QueryString["zsj"];

            return View();
        }


        public async Task<ActionResult> RLCXListCX(string yi, string er, string sa, string fl, string mc, string qsj, string zsj, int pageSize, int currentPage)
        {
            Fenye<Human_file> fenye = await human_File.SelectListAsync(yi,er,sa,fl,mc,qsj,zsj,pageSize, currentPage);
            return Json(fenye, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> RLCXListCXid(int id)
        {
            ViewBag.s = await human_File.ChaYiidAsync(id);
            return View();
        }


        public ActionResult RLBG()
        {
            return View();
        }

        public ActionResult RLBGList()
        {
            string fl = Request.QueryString["fl"];
            string mc = Request.QueryString["mc"];
            string yi = Request.QueryString["yi"];
            string er = Request.QueryString["er"];
            string sa = Request.QueryString["sa"];
            string qsj = Request.QueryString["qsj"];
            string zsj = Request.QueryString["zsj"];

            return View();
        }


        public async Task<ActionResult> RLBGListCXid(int id)
        {
            ViewBag.s = await human_File.ChaYiidAsync(id);
            return View();
        }

        public async Task<ActionResult> RLBGXiuF(Human_file human)
        {
            int cg = await human_File.XiuList(human);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View(human);
            }
        }


    }
}