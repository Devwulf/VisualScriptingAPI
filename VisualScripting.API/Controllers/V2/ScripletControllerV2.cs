using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VisualScripting.API.DataContracts;
using VisualScripting.API.DataContracts.Requests;
using VisualScripting.Services.Contracts;
using S = VisualScripting.Services.Model;

namespace VisualScripting.API.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/scriplets")]
    [ApiController]
    public class ScripletControllerV2 : Controller
    {
        private readonly IScripletService _service;
        private readonly IMapper _mapper;

#pragma warning disable CS1591
        public ScripletControllerV2(IScripletService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
#pragma warning restore CS1591

        #region GET
        /// <summary>
        /// Comments and descriptions can be added to every endpoint using XML comments.
        /// </summary>
        /// <remarks>
        /// XML comments included in controllers will be extracted and injected in Swagger/OpenAPI file.
        /// </remarks>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<Scriplet> Get(string id)
        {
            var data = await _service.GetAsync(id);

            if (data != null)
                return _mapper.Map<Scriplet>(data);
            else
                return null;
        }
        #endregion

        #region POST
        /// <summary>
        /// Creates a scriplet.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="value"></param>
        /// <returns>A newly created scriplet.</returns>
        /// <response code="201">Returns the newly created item.</response>
        /// <response code="204">If the item is null.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Scriplet))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Scriplet))]
        public async Task<Scriplet> CreateScriplet([FromBody]ScripletCreationRequest value)
        {

            //TODO: include exception management policy according to technical specifications
            if (value == null)
                throw new ArgumentNullException("value");

            if (value == null)
                throw new ArgumentNullException("value.Scriplet");


            var data = await _service.CreateAsync(_mapper.Map<S.Scriplet>(value.Scriplet));

            if (data != null)
                return _mapper.Map<Scriplet>(data);
            else
                return null;

        }
        #endregion

        #region PUT
        /// <summary>
        /// Updates an scriplet entity.
        /// </summary>
        /// <remarks>
        /// No remarks.
        /// </remarks>
        /// <param name="parameter"></param>
        /// <returns>
        /// Returns a boolean notifying if the scriplet has been updated properly.
        /// </returns>
        /// <response code="200">Returns a boolean notifying if the scriplet has been updated properly.</response>
        [HttpPut()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<bool> UpdateScriplet([FromBody]UpdateRequest parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException("parameter");

            return await _service.UpdateFieldsAsync(parameter.Id, parameter.NameValuePairs);
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Deletes an scriplet entity.
        /// </summary>
        /// <remarks>
        /// No remarks.
        /// </remarks>
        /// <param name="id">Scriplet Id</param>
        /// <returns>
        /// Boolean notifying if the scriplet has been deleted properly.
        /// </returns>
        /// <response code="200">Boolean notifying if the scriplet has been deleted properly.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<bool> DeleteScriplet(string id)
        {
            return await _service.DeleteAsync(id);
        }
        #endregion

        // TODO: Create a separate controller for nodes that uses the same ScripletService
    }
}