using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
using System.Web.Http;
using WebApi.Boilderplate.Helpers;

namespace WebApi.Boilderplate.Controllers
{
    [RoutePrefix("api/v1/bom")]
    public class BOMController : ApiController
    {
        // EXAMPLE: Interfaces you want injected.
        //
        // private readonly IPayloadMapper _payloadMapper;
        // private readonly IMappingRules _mappingRules;

        // EXAMPLE: Inject the requested interfaces from the configured container and
        // store them in the private member variables above for use in this class -
        // provides nice abstraction and separation of components.
        // public BOMController(IPayloadMapper payloadMapper, IMappingRules mappingRules)
        // {
        //     _payloadMapper = payloadMapper;
        //     _mappingRules = mappingRules;
        // }

        
        // TODO: Move these models to separate class library, I leave it here for EXAMPLE purposes.
        public sealed class DetailModel
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }


        [HttpPost]
        [Route("")]     // Restful route will be: HTTP POST api/v2/bom with a JSON body
        public IHttpActionResult PostDetails([FromBody] DetailModel details)
        {
            return Ok(details);
        }

        [HttpGet]
        [Route("{id}")]     // Restful route will be: HTTP GET api/v2/bom/{id}
        public IHttpActionResult GetBom(string id)
        {
            var result = new
            {
                Id = id,
                Result_type = "bom",
                ShortName = "BOM",
                Description = "Bill of Materials",
                SomeArray = new List<dynamic>
                {
                    new 
                    {
                        Result_type = "something",
                        Value = 58.22
                    },
                    new 
                    {
                        Result_type = "something",
                        Value = 97.56
                    }
                }
            };

            return Ok(result);
        }
    }
}
