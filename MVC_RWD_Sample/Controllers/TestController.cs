using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_RWD_Sample.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CSS_Animation()
        {
            return View();
        }

        /// <summary>
        /// 支援跨日計算的請假總時數入口
        /// [1]同一天    -> 直接呼叫 Get_OneDay_TotalHours_For_Unit_Hour
        /// [2]共2天     -> 第1天:p_From_DT~18:00，第2天:09:00~p_To_DT
        /// [3]共3天以上 -> 第1天:p_From_DT~18:00，中間每天固定8小時，最後一天:09:00~p_To_DT
        /// </summary>
        public double Get_TotalHours_Without_Holiday_For_Unit_Hour(string country, string fromDate, string toDate, string fromTime, string toTime)
        {
            DateTime tmp_From_DT = new DateTime();
            DateTime tmp_To_DT = new DateTime();
            //===
            int hoursOfHalfDay = 4;
            //===============
            bool is_Valid_DateTime_From = DateTime.TryParse($"{fromDate} {fromTime}", out tmp_From_DT);
            bool is_Valid_DateTime_To = DateTime.TryParse($"{toDate} {toTime}", out tmp_To_DT);
            //===============
            if (is_Valid_DateTime_From && is_Valid_DateTime_To)
            {
                double tmp_TotalHours = 0;
                //===============
                // 同一天，直接用原本的單日計算方式
                if (tmp_From_DT.Date == tmp_To_DT.Date)
                {
                    tmp_TotalHours = Get_OneDay_TotalHours_For_Unit_Hour(tmp_From_DT, tmp_To_DT);
                    return tmp_TotalHours;
                }
                //===============
                // 計算共跨幾天 (含頭尾)
                int tmp_TotalDays = (tmp_To_DT.Date - tmp_From_DT.Date).Days + 1;
                //===============
                // 第1天: p_From_DT ~ 當天18:00
                DateTime tmp_Day1_End_DT = tmp_From_DT.Date.AddHours(18);
                double tmp_Day1_Hours = Get_OneDay_TotalHours_For_Unit_Hour(tmp_From_DT, tmp_Day1_End_DT);
                //===============
                // 最後1天: 當天09:00 ~ p_To_DT
                DateTime tmp_LastDay_Start_DT = tmp_To_DT.Date.AddHours(9);
                double tmp_LastDay_Hours = Get_OneDay_TotalHours_For_Unit_Hour(tmp_LastDay_Start_DT, tmp_To_DT);
                //===============
                tmp_TotalHours = tmp_Day1_Hours + tmp_LastDay_Hours;
                //===============
                // 共3天以上，中間每一天固定8小時
                if (tmp_TotalDays >= 3)
                {
                    int tmp_MiddleDays = tmp_TotalDays - 2;
                    tmp_TotalHours += tmp_MiddleDays * 8;
                }
                //===============
                return tmp_TotalHours;                
            }
            else
            {
                return 0;
            }
        }

        public double Get_OneDay_TotalHours_For_Unit_Hour(DateTime p_From_DT, DateTime p_To_DT)
        {
            double tmp_TotalHours = 0;
            //===============
            // 以 p_From_DT 的日期為基準，組出當天的午休起訖時間
            DateTime tmp_LunchStart_DT = p_From_DT.Date.AddHours(12).AddMinutes(30); // 12:30
            DateTime tmp_LunchEnd_DT = p_From_DT.Date.AddHours(14);                  // 14:00
            //===============
            if (p_From_DT < tmp_LunchStart_DT && p_To_DT > tmp_LunchEnd_DT)
            {
                // 請假區間完整涵蓋午休，扣除 1.5 小時
                tmp_TotalHours = (p_To_DT - p_From_DT).TotalHours - 1.5;
            }
            else if ((p_From_DT > tmp_LunchStart_DT && p_From_DT <= tmp_LunchEnd_DT) && p_To_DT > tmp_LunchEnd_DT)
            {
                // 開始時間落在午休中，結束時間在午休後
                tmp_TotalHours = (p_To_DT - tmp_LunchEnd_DT).TotalHours;
            }
            else if (p_From_DT < tmp_LunchStart_DT && (p_To_DT >= tmp_LunchStart_DT && p_To_DT < tmp_LunchEnd_DT))
            {
                // 開始時間在午休前，結束時間落在午休中
                tmp_TotalHours = (tmp_LunchStart_DT - p_From_DT).TotalHours;
            }
            else if (p_From_DT >= tmp_LunchStart_DT && p_To_DT <= tmp_LunchEnd_DT)
            {
                // 請假區間完全落在午休時段內
                tmp_TotalHours = 0;
            }
            else
            {
                // 兩者皆在午休前，或兩者皆在午休後
                tmp_TotalHours = (p_To_DT - p_From_DT).TotalHours;
            }
            //===============
            //總時數上下限規則:
            //如果總時數>=7.5小時，就直接固定等於8小時。
            //如果總時數<=0小時，就直接固定等於0小時。
            if (tmp_TotalHours >= 7.5)
            {
                tmp_TotalHours = 8;
            }
            else if (tmp_TotalHours <= 0)
            {
                tmp_TotalHours = 0;
            }
            //===============
            return tmp_TotalHours;
        }
    }
}