using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace testcore13092022.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class jsontestController : ControllerBase
    {
       [HttpGet]
       [Route("jsontest")]
        public dynamic testjson()
        {
            var data = new List<Root>();


        
            using (StreamReader r = new StreamReader("test.json"))
            {
                string json = r.ReadToEnd();
                data = JsonSerializer.Deserialize<List<Root>>(json);
                Console.WriteLine("dataaaaa.....", data);
            }               
            //string h="";
            //List<string> itemOUT = new List<string>();
            //List<string> eve = new List<string>();
            //List<string> datas = new List<string>();

            //string eventkey = "sec_web-usr-rqst_rjct_scs";
            //string j = "";
            //string frond = "";
            //string msg = "";
            //string desc = "";
            
            if (data != null && data.Count>0)
            {
                List<Root> datazz = data.FindAll(i => i.sub_module_name == "Roles" && i.events!=null  );
                List<Event> data1 = datazz[0].events.FindAll(x => x.event_key == "sec_rol_crt_scs");

                return data1;
                //var ddd = datazz.FindAll(i => i.ev);

                //foreach (var check in data)
                //{


                //    h = check.events.ToString();

                //    var evnts = check.events;
                //    Console.WriteLine("output..........", h);

                //    Console.WriteLine("output..........", check.events);
                //    string ss = "";
                //    foreach (var d in evnts)
                //    {
                //        ss = d.event_name;
                //        if(d.event_key==eventkey)
                //        {
                //            j = d.event_key;
                //            frond=d.frontend_key;
                //            msg = d.message;
                //            desc = d.event_description;
                //            datas.Add(desc);
                //            datas.Add(msg);
                //            datas.Add(frond);


                //        }
                                               
                //    }
               //itemOUT.Add(datazz);
                    
                //}
                //eve.Add(h);

              

            }

            return "tdfgd";
        }




        public class Event
        {
            public string event_name { get; set; }
            public string event_key { get; set; }
            public string message { get; set; }
            public string event_description { get; set; }
            public string message_ar { get; set; }
            public string event_description_ar { get; set; }
            public string frontend_key { get; set; }
            public bool success { get; set; }
            public List<Reason> reasons { get; set; }
            public string event_descriptioon { get; set; }
        }

        public class Reason
        {
            public string reson_id { get; set; }
            public string reason { get; set; }
        }

        public class Root
        {
            public string module_id { get; set; }
            public string module { get; set; }
            public string sub_module_id { get; set; }
            public string sub_module_name { get; set; }
            public List<Event> events { get; set; }
        }


    }

}
