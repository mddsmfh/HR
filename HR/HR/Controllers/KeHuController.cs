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
    public class KeHuController : Controller
    {
        private First_kindDAO kindDAO = new First_kindDAO();
        private Second_kindDAO  second_KindDAO = new Second_kindDAO();
        private Third_kindDAO third_KindDAO = new Third_kindDAO();
        private MajorDAO majorDAO = new MajorDAO();
        private Major_kindDAO major_KindDAO = new Major_kindDAO();
        private Public_charDAO public_CharDAO = new Public_charDAO();

        // GET: KeHu
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 进行显示所有I级机构设置信息
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Syzbw()
        {
            IEnumerable<First_kind> ie = await kindDAO.ChaYiAsync();
            return Json(ie, JsonRequestBehavior.AllowGet);
        }

        public ActionResult XiuYi()
        {
            return View();
        }

        public ActionResult Tian()
        {
            return View();
        }

        /// <summary>
        /// 进行添加
        /// </summary>
        /// <param name="first_Kind"></param>
        /// <returns></returns>
        public async Task<ActionResult> Tia(First_kind first_Kind)
        {
            int cg = await kindDAO.TianAsync(first_Kind);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View(first_Kind);
            }
        }

        /// <summary>
        /// 添加成功进入成功视图
        /// </summary>
        /// <returns></returns>
       
        public ActionResult Tiancg()
        {
            return View();
        }

        /// <summary>
        /// 进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Sc(int id)
        {
            int cg = await kindDAO.ScAsync(id);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }

        /// <summary>
        /// 删除成功进入的页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ScYe()
        {
            return View();
        }

        /// <summary>
        /// 进行显示修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Xiu(int id)
        {
            ViewBag.s = await kindDAO.ChaYiAsync(id);
            return View();
        }

        /// <summary>
        /// 进行更改
        /// </summary>
        /// <param name="first_Kind"></param>
        /// <returns></returns>
        public async Task<ActionResult> Xiuu(First_kind first_Kind)
        {
            int cg = await kindDAO.Xiu(first_Kind);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }

        public ActionResult XiuCg()
        {
            return View();
        }

        public ActionResult Eji()
        {
            return View();
        }


        /// <summary>
        /// 进行显示修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> EjiXiu(int id)
        {
            ViewBag.s = await second_KindDAO.ChaYiAsync(id);
            return View();
        }

        /// <summary>
        /// 进行更改
        /// </summary>
        /// <param name="Second_kind"></param>
        /// <returns></returns>
        public async Task<ActionResult> EjiXiuu(Second_kind second_Kind)
        {
            int cg = await second_KindDAO.Xiu(second_Kind);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }

        public ActionResult EjiXiuCg()
        {
            return View();
        }


        /// <summary>
        /// 进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> EjiSc(int id)
        {
            int cg = await second_KindDAO.ScAsync(id);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }

        /// <summary>
        /// 删除成功进入的页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ScYe2()
        {
            return View();
        }

        public ActionResult EjiTJ()
        {
            return View();
        }

        public async Task<ActionResult> EjiTJf(Second_kind second_Kind)
        {
            int cg = await second_KindDAO.TianAsync(second_Kind);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View(second_Kind);
            }
        }

        public ActionResult EjiTJcg()
        {
            return View();
        }

        /// <summary>
        /// 进行显示所有II级机构设置信息
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> EjiCX()
        {
            IEnumerable<Second_kind> ie = await second_KindDAO.SelectAsync();
            return Json(ie, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Esan()
        {
            return View();
        }

        /// <summary>
        /// 进行显示所有III级机构设置信息
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> EsanCX()
        {
            IEnumerable<Third_kind> ie = await third_KindDAO.SelectAsync();
            return Json(ie, JsonRequestBehavior.AllowGet);
        }


        public ActionResult EsanTJ()
        {
            return View();
        }

        public async Task<ActionResult> EsanTJf(Third_kind third_Kind)
        {
            int cg = await third_KindDAO.TianAsync(third_Kind);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View(third_Kind);
            }
        }

        public ActionResult EsanTJcg()
        {
            return View();
        }


        /// <summary>
        /// 进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> EsanSc(int id)
        {
            int cg = await third_KindDAO.ScAsync(id);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }

        /// <summary>
        /// 删除成功进入的页面
        /// </summary>
        /// <returns></returns>
        public ActionResult EsanYe()
        {
            return View();
        }


        /// <summary>
        /// 进行显示修改页面
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> EsanXiu(int id)
        {
            ViewBag.s = await third_KindDAO.ChaYiAsync(id);
            return View();
        }

        /// <summary>
        /// 进行更改
        /// </summary>
        /// <param name="Third_kind"></param>
        /// <returns></returns>
        public async Task<ActionResult> EsanXiuu(Third_kind third_Kind)
        {
            int cg = await third_KindDAO.Xiu(third_Kind);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }

        public ActionResult EsanXiuCg()
        {
            return View();
        }

        public ActionResult ZhiCeng()
        {
            return View();
        }

        /// <summary>
        /// 进行显示职称设置信息
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ZhiCengCX()
        {
            IEnumerable<Public_char> ie = await majorDAO.SelectAsync();
            return Json(ie, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> ZhiCengSc(int id)
        {
            int cg = await majorDAO.ScAsync(id);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }


        /// <summary>
        /// 进行显示职位设置信息
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ZhiWeiSheCX()
        {
            IEnumerable<Major> ie = await majorDAO.SelectsAsync();
            return Json(ie, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> ZhiWeiSheSc(int id)
        {
            int cg = await majorDAO.ScAsyncs(id);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }




        public ActionResult ZhiWei()
        {
            return View();
        }

        /// <summary>
        /// 进行显示职位分类信息  
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> ZhiWeiCX()
        {
            IEnumerable<Major_kind> ie = await major_KindDAO.SelectAsync();
            return Json(ie, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> ZhiWeiSc(int id)
        {
            int cg = await major_KindDAO.ScAsync(id);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }


        public ActionResult ZhiWeiTJ()
        {
            return View();
        }

        /// <summary>
        /// 进行添加
        /// </summary>
        /// <param name="major_Kind"></param>
        /// <returns></returns>
        public async Task<ActionResult> ZhiWeiTJf(Major_kind major_Kind)
        {
            int cg = await major_KindDAO.TianAsync(major_Kind);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View(major_Kind);
            }
        }




        public ActionResult ZhiWeiShe()
        {
            return View();
        }


        public ActionResult ZhiWeiSheTJ()
        {
            return View();
        }

        /// <summary>
        /// 进行添加
        /// </summary>
        /// <param name="major"></param>
        /// <returns></returns>
        public async Task<ActionResult> ZhiWeiSheTJf(Major major)
        {
            int cg = await majorDAO.TianAsync(major);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View(major);
            }
        }

        public ActionResult GonG()
        {
            return View();
        }

        /// <summary>
        /// 进行显示公共属性设置信息
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> GonGCX()
        {
            IEnumerable<Public_char> ie = await public_CharDAO.SelectAsync();
            return Json(ie, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 进行删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult> GonGSc(int id)
        {
            int cg = await public_CharDAO.ScAsync(id);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return Content("0");
            }
        }


        public ActionResult GonGTJ()
        {
            return View();
        }

        /// <summary>
        /// 进行添加
        /// </summary>
        /// <param name="public_Char"></param>
        /// <returns></returns>
        public async Task<ActionResult> GonGTJf(Public_char public_Char)
        {
            int cg = await public_CharDAO.TianAsync(public_Char);
            if (cg > 0)
            {
                return Content("1");
            }
            else
            {
                return View(public_Char);
            }
        }


    }
}