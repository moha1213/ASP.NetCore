using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Screen : IModel
    {
        [NotMapped]
        public bool isChecked { get; set; }
        public string ScreenTittleAr { get; set; }
        public string ScreenTittleEn { get; set; }
        public string ScreenUrl { get; set; }
        public string ParentScreenID { get; set; }
        public string ClassName { get; set; }

        public List<RoleScreenDetails> ConvertToRoleScreenDetails(List<Screen> screenList, Func<string> GetIdMethod)
        {
            try
            {
                List<RoleScreenDetails> detlist = new List<RoleScreenDetails>();

                foreach (var scrn in screenList)
                {
                    RoleScreenDetails det = new RoleScreenDetails
                    {
                      
                        ScreenID = scrn.Id,
                        Name = scrn.Name,                      
                        ParentScreenID = scrn.ParentScreenID,
                        ScreenTittleAr = scrn.ScreenTittleAr,
                        ScreenTittleEn = scrn.ScreenTittleEn,
                        ScreenUrl = scrn.ScreenUrl,
                        ClassName = scrn.ClassName,
                        isChecked = scrn.isChecked,
                        Description = scrn.Description
                        
                    };
                    detlist.Add(det);
                }
                return detlist;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
