using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models
{
    public class RoleScreenDetails : IModel
    {
        public virtual RoleScreen RoleScreen { get; set; }
        public string RoleScreenID { get; set; }
        [NotMapped]
        public bool isChecked { get; set; }
        public string ScreenTittleAr { get; set; }
        public string ScreenTittleEn { get; set; }
        public string ScreenUrl { get; set; }
        public Guid ScreenID { get; set; }
        public string ParentScreenID { get; set; }
        public string ClassName { get; set; }
        public List<Screen> ConvertToScreen(List<RoleScreenDetails> RoleScreenDetailsList)
        {
            try
            {
                List<Screen> scrnlist = new List<Screen>();

                foreach (var det in RoleScreenDetailsList)
                {
                    Screen scrn = new Screen
                    {                        
                        Name = det.Name,                      
                        ParentScreenID = det.ParentScreenID,
                        ScreenTittleAr = det.ScreenTittleAr,
                        ScreenTittleEn = det.ScreenTittleEn,
                        ScreenUrl = det.ScreenUrl,
                        ClassName = det.ClassName,
                        isChecked = det.isChecked,
                        Description = det.Description
                    };
                    scrnlist.Add(scrn);
                }
                return scrnlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
       
    }
}
