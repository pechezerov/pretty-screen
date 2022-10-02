﻿using Autonoma.API.Main.Contracts.DataPoint;
using Autonoma.API.Main.Queries.DataPoint;
using Autonoma.API.Queries;
using Autonoma.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Autonoma.API.Main.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataPointsController : ControllerBase
    {
        private readonly IQueryHandlerAsync<DataPointByIdQuery, DataPointByIdQueryResult> _dataPointByIdHandler;
        private readonly IQueryHandlerAsync<DataPointListQuery, DataPointListQueryResult> _dataPointListHandler;
        private readonly IQueryHandlerAsync<DataPointUpdateQuery, DataPointUpdateQueryResult> _dataPointUpdateHandler;
        private readonly IQueryHandlerAsync<DataPointUpdateListQuery, DataPointUpdateQueryResult> _dataPointUpdateListHandler;

        public DataPointsController(
            IQueryHandlerAsync<DataPointByIdQuery, DataPointByIdQueryResult> dataPointByIdHandler,
            IQueryHandlerAsync<DataPointListQuery, DataPointListQueryResult> dataPointListHandler,
            IQueryHandlerAsync<DataPointUpdateQuery, DataPointUpdateQueryResult> dataPointUpdateHandler,
            IQueryHandlerAsync<DataPointUpdateListQuery, DataPointUpdateQueryResult> dataPointUpdateListHandler)
        {
            _dataPointByIdHandler = dataPointByIdHandler;
            _dataPointListHandler = dataPointListHandler;
            _dataPointUpdateHandler = dataPointUpdateHandler;
            _dataPointUpdateListHandler = dataPointUpdateListHandler;
        }

        // GET api/v1/[controller]/123
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(DataPointByIdQueryResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DataPointById(int id)
        {
            var query = new DataPointByIdQuery(id);
            return Ok(await _dataPointByIdHandler.ExecuteAsync(query));
        }

        // POST api/v1/[controller]/list
        [HttpPost]
        [Route("[controller]/list")]
        [ProducesResponseType(typeof(DataPointListQueryResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DataPointList(DataPointListQuery query)
        {
            return Ok(await _dataPointListHandler.ExecuteAsync(query));
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(typeof(DataPointUpdateQueryResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDataPoint(int id, DataValue data)
        {
            return Ok(await _dataPointUpdateHandler.ExecuteAsync(new DataPointUpdateQuery(id, data)));
        }

        [HttpPut]
        [Route("updateList")]
        [ProducesResponseType(typeof(DataPointUpdateQueryResult), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateDataPoints([FromBody] DataPointUpdateListQuery query)
        {
            return Ok(await _dataPointUpdateListHandler.ExecuteAsync(query));
        }
    }
}
