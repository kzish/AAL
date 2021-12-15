using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using Microsoft.Extensions.Configuration;

namespace Globals
{
    public class Globals
    {
        public static IConfiguration configuration;
        public string resources_folder;
        public string profile_pictures_folder;
        public string moodle_api_endpoint;
    }
}
