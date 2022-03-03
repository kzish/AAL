using Microsoft.EntityFrameworkCore;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace Globals
{
    public class EsRepository
    {

        private apiTutor ConverAspnetUserObjectToEsModel(string aspnet_user_id)
        {
            var tutor = AppSettings.db.Aspnetusers
                        .Where(i => i.Id == aspnet_user_id)
                        .Include(i => i.MTutor)
                        .Include(i => i.MAspnetUserAvailableTimes)
                        .Include(i => i.MAspnetUserLanguages)
                        .Include(i => i.MMoodleUsers)
                        .Include(i => i.MTutorCourses)
                        .Include(i => i.MTutorEducations)
                        .Include(i => i.MTutorRatings)
                        .Include(i => i.MTutorWorkExperiences)
                        .FirstOrDefault();

            var apiTutor = new apiTutor()
            {
                //_id = tutor.Id,
                AspnetUserId = tutor.Id,
                Firstname = tutor.MTutor.Firstname,
                Surname = tutor.MTutor.Surname,
                Email = tutor.MTutor.Email,
                ImageUrl = tutor.MTutor.ImageUrl,
                CoutryIso = tutor.MTutor.CoutryIso,
                CoutryName = AppSettings.db.MCountries.Find(tutor.MTutor.CoutryIso).CountryName,
                About=tutor.MTutor.About,
                //Languages { get; set; } = new List<Language>();
                //Courses { get; set; } = new List<string>();
                Mobile = tutor.MTutor.Mobile,
                OtherMobile = tutor.MTutor.OtherMobile,
                MobileAvailableOnWhatsapp = tutor.MTutor.MobileAvailableOnWhatsapp,
                ShowEmail = tutor.MTutor.ShowEmail,
            };


           return apiTutor;
        }
        public dynamic IndexTutor(string aspnet_user_id) 
        {
            try
            {

                var tutor = ConverAspnetUserObjectToEsModel(aspnet_user_id);
                
                var indexResponse = AppSettings.EsClient.Index(tutor, i=>i.Index("tutors"));

                dynamic res = new ExpandoObject();
                res.res = "ok";
                res.msg = "document indexed";
                return res;
            }
            catch (Exception ex)
            {
                dynamic err = new ExpandoObject();
                err.res = "err";
                err.msg = ex.Message;
                return err;
            }


        }
    }
}
