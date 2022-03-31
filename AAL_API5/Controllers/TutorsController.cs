using Globals;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;
using Serilog;
using SharedModels;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AAL_API.Controllers
{
    [Route("Tutors")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize]
    public class TutorsController : Controller
    {
        dbContext db = new dbContext();

        private const int array_limit = 15;

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db.Dispose();
        }

        public TutorsController()
        {
        }

        [HttpGet("FetchTutors")]
        public JsonResult FetchTutors(string search_param,
            string selected_timeperiod_sunday,
            string selected_timeperiod_monday,
            string selected_timeperiod_tuesday,
            string selected_timeperiod_wednesday,
            string selected_timeperiod_thursday,
            string selected_timeperiod_friday,
            string selected_timeperiod_saturday,
            string selected_countries, 
            string selected_languages, 
            int page = 1)
        {
            //
            var list_countries = new List<string>();
            var list_languages = new List<string>();
            //
            var list_selected_timeperiod_sunday = new List<string>();
            var list_selected_timeperiod_monday = new List<string>();
            var list_selected_timeperiod_tuesday = new List<string>();
            var list_selected_timeperiod_wednesday = new List<string>();
            var list_selected_timeperiod_thursday = new List<string>();
            var list_selected_timeperiod_friday = new List<string>();
            var list_selected_timeperiod_saturday = new List<string>();
            //
            if (!string.IsNullOrEmpty(selected_countries)) list_countries = selected_countries.Split(',').ToList();
            if (!string.IsNullOrEmpty(selected_languages)) list_languages = selected_languages.Split(',').ToList();
            //
            if (!string.IsNullOrEmpty(selected_timeperiod_sunday)) list_selected_timeperiod_sunday = selected_timeperiod_sunday.Split(',').ToList(); 
            if (!string.IsNullOrEmpty(selected_timeperiod_monday)) list_selected_timeperiod_monday = selected_timeperiod_monday.Split(',').ToList(); 
            if (!string.IsNullOrEmpty(selected_timeperiod_tuesday)) list_selected_timeperiod_tuesday = selected_timeperiod_tuesday.Split(',').ToList(); 
            if (!string.IsNullOrEmpty(selected_timeperiod_wednesday)) list_selected_timeperiod_wednesday = selected_timeperiod_wednesday.Split(',').ToList(); 
            if (!string.IsNullOrEmpty(selected_timeperiod_thursday)) list_selected_timeperiod_thursday = selected_timeperiod_thursday.Split(',').ToList(); 
            if (!string.IsNullOrEmpty(selected_timeperiod_friday)) list_selected_timeperiod_friday = selected_timeperiod_friday.Split(',').ToList(); 
            if (!string.IsNullOrEmpty(selected_timeperiod_saturday)) list_selected_timeperiod_saturday = selected_timeperiod_saturday.Split(',').ToList(); 

            page--;//page starts at 0
            try
            {
                
               

                var db_language_names = db.MLanguages.Where(i => list_languages.Contains(i.Iso)).Select(i => i.LanguageName).ToList();

                var queryContainer = new QueryContainer();
                //
                queryContainer &= Query<apiTutor>.Term(t => t.Active, 1);//must be active always
                //
                if (list_languages.Count > 0)
                {
                    queryContainer &= Query<apiTutor>.Terms(t => t.Name("languages").Field("languages.lang").Terms(db_language_names));//languages
                }
                //
                if (list_countries.Count > 0)
                {
                    queryContainer &= Query<apiTutor>.Terms(t => t.Name("countries").Field("coutryIso").Terms(list_countries));//countries
                }
                //
                queryContainer &= Query<apiTutor>.MultiMatch(
                    m=>m.Fields(
                    f=>f.Field("about") //tutor about
                    .Field("courses.description")//courses.description
                    .Field("courses.title"))//courses.title
                .Query(search_param));

                //sunday time periods
                if (list_selected_timeperiod_sunday.Count > 0)
                {
                    var the_terms = new List<string>();
                    foreach (var item in list_selected_timeperiod_sunday)
                    {
                        if (!the_terms.Contains(item.ToLower()))
                        {
                            the_terms.Add(item.ToLower());
                        }
                    }
                    queryContainer &= Query<apiTutor>.Bool(
                        m => m.Must(
                                mm => mm.Match(
                                    f => f.Field("availableTimes.weekday").Query("Sunday")
                                ),
                                mm => mm.Terms(
                                    f => f.Field("availableTimes.timePeriod").Terms(the_terms)
                                )
                            )
                        );

                }
                //monday time periods
                if (list_selected_timeperiod_monday.Count > 0)
                {
                    var the_terms = new List<string>();
                    foreach (var item in list_selected_timeperiod_monday)
                    {
                        if (!the_terms.Contains(item.ToLower()))
                        {
                            the_terms.Add(item.ToLower());
                        }
                    }
                    queryContainer &= Query<apiTutor>.Bool(
                        m => m.Must(
                                mm => mm.Match(
                                    f => f.Field("availableTimes.weekday").Query("Monday")
                                ),
                                mm => mm.Terms(
                                    f => f.Field("availableTimes.timePeriod").Terms(the_terms)
                                )
                            )
                        );
                }
                //tuesday time periods
                if (list_selected_timeperiod_tuesday.Count > 0)
                {
                    var the_terms = new List<string>();
                    foreach (var item in list_selected_timeperiod_tuesday)
                    {
                        if (!the_terms.Contains(item.ToLower()))
                        {
                            the_terms.Add(item.ToLower());
                        }
                    }
                    queryContainer &= Query<apiTutor>.Bool(
                        m => m.Must(
                                mm => mm.Match(
                                    f => f.Field("availableTimes.weekday").Query("Tuesday")
                                ),
                                mm => mm.Terms(
                                    f => f.Field("availableTimes.timePeriod").Terms(the_terms)
                                )
                            )
                        );
                }
                //wednesday time periods
                if (list_selected_timeperiod_wednesday.Count > 0)
                {
                    var the_terms = new List<string>();
                    foreach (var item in list_selected_timeperiod_wednesday)
                    {
                        if (!the_terms.Contains(item.ToLower()))
                        {
                            the_terms.Add(item.ToLower());
                        }
                    }
                    queryContainer &= Query<apiTutor>.Bool(
                        m => m.Must(
                                mm => mm.Match(
                                    f => f.Field("availableTimes.weekday").Query("Wednesday")
                                ),
                                mm => mm.Terms(
                                    f => f.Field("availableTimes.timePeriod").Terms(the_terms)
                                )
                            )
                        );
                }
                //thursday time periods
                if (list_selected_timeperiod_thursday.Count > 0)
                {
                    var the_terms = new List<string>();
                    foreach (var item in list_selected_timeperiod_thursday)
                    {
                        if (!the_terms.Contains(item.ToLower()))
                        {
                            the_terms.Add(item.ToLower());
                        }
                    }
                    queryContainer &= Query<apiTutor>.Bool(
                        m => m.Must(
                                mm => mm.Match(
                                    f => f.Field("availableTimes.weekday").Query("Thursday")
                                ),
                                mm => mm.Terms(
                                    f => f.Field("availableTimes.timePeriod").Terms(the_terms)
                                )
                            )
                        );
                }
                //friday time periods
                if (list_selected_timeperiod_friday.Count > 0)
                {
                    var the_terms = new List<string>();
                    foreach (var item in list_selected_timeperiod_friday)
                    {
                        if (!the_terms.Contains(item.ToLower()))
                        {
                            the_terms.Add(item.ToLower());
                        }
                    }
                    queryContainer &= Query<apiTutor>.Bool(
                        m => m.Must(
                                mm => mm.Match(
                                    f => f.Field("availableTimes.weekday").Query("Friday")
                                ),
                                mm => mm.Terms(
                                    f => f.Field("availableTimes.timePeriod").Terms(the_terms)
                                )
                            )
                        );
                }
                //saturday time periods
                if (list_selected_timeperiod_saturday.Count > 0)
                {
                    var the_terms = new List<string>();
                    foreach (var item in list_selected_timeperiod_saturday)
                    {
                        if (!the_terms.Contains(item.ToLower()))
                        {
                            the_terms.Add(item.ToLower());
                        }
                    }
                    queryContainer &= Query<apiTutor>.Bool(
                        m => m.Must(
                                mm => mm.Match(
                                    f => f.Field("availableTimes.weekday").Query("Saturday")
                                ), 
                                mm=>mm.Terms(
                                    f => f.Field("availableTimes.timePeriod").Terms(the_terms)
                                )
                            )
                        );
                }
                //
                var searchRequest = new SearchRequest<apiTutor>("tutors")
                {
                    Query = queryContainer
                };

                var searchResponse = AppSettings.EsClient.Search<apiTutor>(searchRequest);

                return Json(new
                {
                    res = "ok",
                    tutors = searchResponse.Documents,
                    total_tutors = searchResponse.Total,
                    items_per_page = array_limit,
                    es = searchResponse
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Json(new
                {
                    res = "err",
                    msg = ex.Message
                });
            }
        }

        [HttpGet("GetImage/{file_name}")]
        public async Task<IActionResult> GetImage(string file_name)
        {
            try
            {
                var filePath = System.IO.Path.Combine(AppSettings.profile_pictures_folder, file_name);
                var memory = new MemoryStream();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                    stream.Dispose();
                }
                memory.Position = 0;
                return File(memory.ToArray(), "image/jpg");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return NotFound();
            }
        }

        [HttpGet("FetchCountries")]
        public JsonResult FetchCountries()
        {
            try
            {
                var countries = db.MCountries.ToList();
                return Json(new
                {
                    res = "ok",
                    countries = countries,
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Json(new
                {
                    res = "err",
                    msg = ex.Message
                });
            }
        }

        [HttpGet("FetchLanguages")]
        public JsonResult FetchLanguages()
        {
            try
            {
                var languages = db.MLanguages.ToList();
                return Json(new
                {
                    res = "ok",
                    languages = languages,
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Json(new
                {
                    res = "err",
                    msg = ex.Message
                });
            }
        }


        [HttpGet("FetchTimePeriods")]
        public JsonResult FetchTimePeriods()
        {
            try
            {
                var time_periods = db.ETimePeriods.OrderBy(i => i.Sequence).ToList();
                return Json(new
                {
                    res = "ok",
                    time_periods = time_periods,
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return Json(new
                {
                    res = "err",
                    msg = ex.Message
                });
            }
        }

    }
}
