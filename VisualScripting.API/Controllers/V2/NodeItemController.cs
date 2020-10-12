using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VisualScripting.API.DataContracts;
using VisualScripting.API.DataContracts.Requests;
using VisualScripting.Services.Contracts;
using S = VisualScripting.Services.Model;

namespace VisualScripting.API.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/scriplets")]
    [ApiController]
    public class NodeItemController
    {
        private readonly IScripletService _service;
        private readonly IMapper _mapper;

#pragma warning disable CS1591
        public NodeItemController(IScripletService service, IMapper mapper)
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
        /// <param name="scripletId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{scripletId}/nodes/{id}")]
        public async Task<NodeItem> Get(string scripletId, int id)
        {
            var data = await _service.GetAsync(scripletId);
            if (data == null)
                return null;

            var scriplet = _mapper.Map<Scriplet>(data);
            NodeItem nodeItem;
            if (scriplet.Items.TryGetValue(id, out nodeItem))
                return nodeItem;

            return null;
        }
        #endregion

        #region POST
        /// <summary>
        /// Creates a node item.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="scripletId"></param>
        /// <param name="value"></param>
        /// <returns>A newly created node item.</returns>
        /// <response code="201">Returns the newly created item.</response>
        /// <response code="204">If the item is null.</response>
        [HttpPost("{scripletId}/nodes")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(NodeItem))]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(NodeItem))]
        public async Task<NodeItem> CreateNodeItem(string scripletId, [FromBody]NodeItemCreationRequest value)
        {

            //TODO: include exception management policy according to technical specifications
            if (value == null)
                throw new ArgumentNullException("value");

            if (value.NodeItem == null)
                throw new ArgumentNullException("value.NodeItem");

            var data = await _service.GetAsync(scripletId);
            if (data == null)
                return null;

            var scriplet = _mapper.Map<Scriplet>(data);
            var nodeItem = _mapper.Map<S.NodeItem>(value.NodeItem);
            var nodeItemId = scriplet.ItemCounter;

            nodeItem.Id = nodeItemId;
            value.NodeItem.Id = nodeItemId;

            var result = await _service.UpdateSetAsync(scripletId, 
                new Dictionary<string, object>() 
                { 
                    [$"Items.{nodeItemId}"] = nodeItem,
                    ["ItemCounter"] = nodeItemId + 1
                });

            return result ? value.NodeItem : null;
        }
        #endregion

        #region PUT
        /// <summary>
        /// Updates a node item in a scriplet entity.
        /// </summary>
        /// <remarks>
        /// No remarks.
        /// </remarks>
        /// <param name="scripletId"></param>
        /// <param name="parameter"></param>
        /// <returns>
        /// Returns a boolean notifying if the node item has been updated properly.
        /// </returns>
        /// <response code="200">Returns a boolean notifying if the node item has been updated properly.</response>
        [HttpPut("{scripletId}/nodes")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<bool> UpdateNodeItem(string scripletId, [FromBody]NodeItemUpdateRequest parameter)
        {
            if (parameter == null)
                throw new ArgumentNullException("parameter");

            var changes = new Dictionary<string, object>();
            foreach (var pair in parameter.NameValuePairs)
                changes.Add($"Items.{parameter.Id}.{pair.Key}", pair.Value);

            var result = await _service.UpdateSetAsync(scripletId, changes);
            return result;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// Deletes a node item in a scriplet entity.
        /// </summary>
        /// <remarks>
        /// No remarks.
        /// </remarks>
        /// <param name="scripletId">Scriplet Id</param>
        /// <param name="id">Node Item Id</param>
        /// <returns>
        /// Boolean notifying if the nod item has been deleted properly.
        /// </returns>
        /// <response code="200">Boolean notifying if the node item has been deleted properly.</response>
        [HttpDelete("{scripletId}/nodes/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<bool> DeleteNodeItem(string scripletId, int id)
        {
            return await _service.UpdateUnsetAsync(scripletId, 
                new Dictionary<string, object>() 
                { 
                    [$"Items.{id}"] = null
                });
        }
        #endregion
    }
}
