using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace AAL_ADMIN.Globals
{
    public class Globals
    {
        private static string moodle_ws_token = "402faee3445fee742d7edadb76780439";
        public static string moodle_api_endpoint = $"http://moodle.test/webservice/rest/server.php?wstoken={moodle_ws_token}&moodlewsrestformat=json";
    }
}
