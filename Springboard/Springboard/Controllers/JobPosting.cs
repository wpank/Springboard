
    using System;  
    using System.Collections.Generic;  
    using System.Linq;  
    using System.Web;  
    using System.Web.Mvc;  
      
    namespace MvcApplication3.Controllers  
    {  
        public class FormCollectionController : Controller  
        {  
            string _Name, _EmailID, _Address;  
            long _MobileN0;  
            //  
            //  
            // GET: /FormCollection/  
      
            public ActionResult Index()  
            {  
                return View();  
            }  
      
            public ActionResult NewRecord()  
            {  
                return View();  
            }  
      
            public ActionResult Insert(FormCollection Fc)  
            {  
                using (MVC_PracticeEntities objContext = new MVC_PracticeEntities())  
                {  
                    tbl_FormCollectionUse Tbl = new tbl_FormCollectionUse();  
                    //  
                    Tbl.Name = Fc["TxtName"].ToString();  
                    Tbl.Mobile = Convert.ToInt64(Fc["Mobile"]);  
                    Tbl.EmailID = Fc["TxtEmailID"].ToString();  
                    Tbl.Address = Fc["TxtAddress"].ToString();  
                    //  
                    objContext.AddTotbl_FormCollectionUse(Tbl);  
                    //  
                    int i = objContext.SaveChanges();  
                    if (i > 0)  
                    {  
                        ViewBag.Msg = "Data Saved Suuceessfully.";  
                    }  
                }  
      

                return View();  
            }  
      
        }  
    }  